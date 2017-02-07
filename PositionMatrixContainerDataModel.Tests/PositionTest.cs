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
    }
}
