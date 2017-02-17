using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PositionMatrixContainer.Models.Exceptions;
using PositionMatrixContainer.Models.Point;

namespace PositionMatrixContainerDataModel.Tests
{
    [TestClass]
    public class PointTest
    {
        [TestMethod]
        public void Create1DPoint_PointCreated()
        {
            Point<int> point1D = new Point<int>(2);

            Assert.IsNotNull(point1D);
            Assert.IsTrue(point1D.X == 2);
        }

        [TestMethod]
        public void Create2DPoint_PointCreated()
        {
            Point<int> point2D = new Point<int>(2, 4);

            Assert.IsNotNull(point2D);
            Assert.IsTrue(point2D.X == 2);
            Assert.IsTrue(point2D.Y == 4);
        }

        [TestMethod]
        public void Create3DPoint_PointCreated()
        {
            Point<int> point3D = new Point<int>(2, 4, 5);

            Assert.IsNotNull(point3D);
            Assert.IsTrue(point3D.X == 2);
            Assert.IsTrue(point3D.Y == 4);
            Assert.IsTrue(point3D.Z == 5);
        }

        [TestMethod]
        [ExpectedException(typeof(NotNumericTypeException))]
        public void Create1DPoint_CreationFailed()
        {
            Point<char> point = new Point<char>('d');
        }
    }
}
