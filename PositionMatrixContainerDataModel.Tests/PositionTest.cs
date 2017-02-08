using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PositionMatrixContainerDataModel.Models.Exceptions;
using PositionMatrixContainerDataModel.Models.Models;
using PositionMatrixContainerDataModel.Models.Models.Collection;

namespace PositionMatrixContainerDataModel.Tests
{
    [TestClass]
    public class PositionTest
    {
        [TestMethod]
        public void CreatePosition_DefaultConstructor_PositionCreated()
        {
            Position<int> position = new Position<int>();

            Assert.IsNotNull(position);
        }

        [TestMethod]
        public void CreateEmptyPosition_ParametrizedConstructor_PositionCreated()
        {
            Position<int> position = new Position<int>(PointDimension.Point3D);

            Assert.IsNotNull(position);
            Assert.IsTrue(position.Dimension == PointDimension.Point3D);
        }

        [TestMethod]
        public void CreatePositionFromPointSequence_PositionCreated()
        {
            List<Point<int>> points = new List<Point<int>> { new Point1D<int>(1), new Point1D<int>(2), new Point1D<int>(3)};
            Position<int> position = new Position<int>(points);

            Assert.IsNotNull(position);
            Assert.IsTrue(position.Count() == 3);
            Assert.AreEqual(position.Dimension, PointDimension.Point1D);
        }

        [TestMethod]
        [ExpectedException(typeof (NotNumericTypeException))]
        public void CreatePosition_DefaultConstructor_PositionCreationFailed()
        {
            Position<string> position = new Position<string>();
        }

        [TestMethod]
        [ExpectedException(typeof (DifferentDimensionTypeInPositionException))]
        public void CreatePosition_ParametrizedConstructorWithSecuenceOfPoints_CreationFailed()
        {
            List<Point<int>> points = new List<Point<int>> {new Point1D<int>(1), new Point1D<int>(2)};
            points.Add(new Point2D<int>(2,3));

            new Position<int>(points);
        }

        [TestMethod]
        public void Add_AddingPointToPosition_PositionAdded()
        {
            List<Point<int>> points = new List<Point<int>> { new Point1D<int>(1), new Point1D<int>(2) };
            var position = new Position<int>(points);
            position.Add(new Point1D<int>(3));

            Assert.IsTrue(position.Count() == 3);         
            Assert.IsTrue((position[2] as Point1D<int>).X == 3);
        }

        [TestMethod]
        [ExpectedException(typeof(DifferentDimensionTypeInPositionException))]
        public void Add_AddingPointWithDifferentType_ExceptionThrown()
        {
            List<Point<int>> points = new List<Point<int>> { new Point1D<int>(1), new Point1D<int>(2) };
            var position = new Position<int>(points);
            position.Add(new Point2D<int>(3,4));
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void Add_AddNullPoint_ExceptionThrown()
        {
            var position = new Position<int>(PointDimension.Point1D);
            Point1D<int> point = null;
            position.Add(point);
        }

    }
}
