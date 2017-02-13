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
        public void CreateEmptyPosition_ParametrizedConstructor_PositionCreated()
        {
            Position<int> position = new Position<int>(PointDimension.Point3D);

            Assert.IsNotNull(position);
            Assert.IsTrue(position.PositionType == PointDimension.Point3D);
        }

        [TestMethod]
        public void CreatePositionFromPointSequence_PositionCreated()
        {
            List<Point<int>> points = new List<Point<int>> { new Point<int>(1), new Point<int>(2), new Point<int>(3) };
            Position<int> position = new Position<int>(points);

            Assert.IsNotNull(position);
            Assert.IsTrue(position.Count() == 3);
            Assert.AreEqual(position.PositionType, PointDimension.Point1D);
        }


        [TestMethod]
        [ExpectedException(typeof(DifferentDimensionTypeInPositionException))]
        public void CreatePosition_ParametrizedConstructorWithSecuenceOfPoints_CreationFailed()
        {
            List<Point<int>> points = new List<Point<int>> { new Point<int>(1), new Point<int>(2) };
            points.Add(new Point<int>(2, 3));

            new Position<int>(points);
        }

        //[TestMethod]
        //public void Add_AddingPointToPosition_PositionAdded()
        //{
        //    List<Point<int>> points = new List<Point<int>> { new Point<int>(1), new Point<int>(2) };
        //    var position = new Position<int>(points);
        //    position.Add(new Point<int>(3));

        //    Assert.IsTrue(position.Count() == 3);
        //    Assert.IsTrue((position[2] as Point<int>).X == 3);
        //}

        [TestMethod]
        [ExpectedException(typeof(DifferentDimensionTypeInPositionException))]
        public void Add_AddingPointWithDifferentType_ExceptionThrown()
        {
            List<Point<int>> points = new List<Point<int>> { new Point<int>(1), new Point<int>(2) };
            var position = new Position<int>(points);
            position.Add(new Point<int>(3, 4));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_AddNullPoint_ExceptionThrown()
        {
            var position = new Position<int>(PointDimension.Point1D);
            Point<int> point = null;
            position.Add(point);
        }

    }
}
