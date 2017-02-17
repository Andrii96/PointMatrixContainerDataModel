using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PositionMatrixContainer.Models.Collection;
using System.Collections.Generic;
using System.Linq;
using PositionMatrixContainer.Models.Exceptions;
using PositionMatrixContainer.Models.Point;

namespace PositionMatrixContainerDataModel.Tests
{
    [TestClass]
    public class ContainerTest
    {
        [TestMethod]
        public void DefaultConstructor_CreatingContainer_ContainerCreated()
        {
            Container<int> container = new Container<int>();
            Assert.IsNotNull(container);
        }

        [TestMethod]
        public void ParametrizedConstructor_CreatingContainer_ContainerCreated()
        {
            var position1 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(1, 2),
                new Point<int>(4, 2),
                new Point<int>(3, 2),
                new Point<int>(1, 1)
            };
            var position2 = new Position<int>(PointDimension.Point1D)
            {
                new Point<int>(2),
                new Point<int>(1)
            };
            
            var matrix1 = new Matrix<int>(Enumerable.Repeat(position1,3));
            var matrix2 = new Matrix<int>(Enumerable.Repeat(position2,3)); 

            Container<int> container = new Container<int>(new List<Matrix<int>> { matrix1, matrix2 });

            Assert.IsNotNull(container);
            Assert.IsTrue(container.Count() == 2);
        }

        [TestMethod]
        [ExpectedException(typeof(DifferentMatrixSizeException))]
        public void ParametrizedConstructor_CreatingContainer_ContainerCreationFailed()
        {
            var position1 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(1, 2),
                new Point<int>(4, 2),
                new Point<int>(3, 2),
                new Point<int>(1, 1)
            };
            var position2 = new Position<int>(PointDimension.Point1D)
            {
                new Point<int>(2),
                new Point<int>(1)
            };
            var matrix1 = new Matrix<int>(Enumerable.Repeat(position1, 3));
            var matrix2 = new Matrix<int>(Enumerable.Repeat(position2, 5));

            Container<int> container = new Container<int>(new List<Matrix<int>> { matrix1, matrix2 });
        }

        [TestMethod]
        public void Add_AddingMatrixToContainer_MatrixAdded()
        {
            var position1 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(1, 2),
                new Point<int>(4, 2),
                new Point<int>(3, 2),
                new Point<int>(1, 1)
            };
            var position2 = new Position<int>(PointDimension.Point1D)
            {
                new Point<int>(2),
                new Point<int>(1)
            };
            var matrix1 = new Matrix<int>(Enumerable.Repeat(position1, 3));
            var matrix2 = new Matrix<int>(Enumerable.Repeat(position2, 3));

            Container<int> container = new Container<int>();
            container.Add(matrix1);
            container.Add(matrix2);

            Assert.IsTrue(container.Count() == 2);
        }

        [TestMethod]
        [ExpectedException(typeof(DifferentMatrixSizeException))]
        public void Add_AddingDifferentSizeMatrixToContainer_MatrixAddingFailed()
        {
            var position1 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(1, 2),
                new Point<int>(4, 2),
                new Point<int>(3, 2),
                new Point<int>(1, 1)
            };
            var position2 = new Position<int>(PointDimension.Point1D)
            {
                new Point<int>(2),
                new Point<int>(1)
            };
            var matrix1 = new Matrix<int>(Enumerable.Repeat(position1, 3));
            var matrix2 = new Matrix<int>(Enumerable.Repeat(position2, 5));

            Container<int> container = new Container<int>();
            container.Add(matrix1);
            container.Add(matrix2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_AddingNullMatrixToContainer_MatrixAddingFailed()
        {
            Container<int> container = new Container<int>();
            container.Add(null);
        }

        [TestMethod]
        public void Insert_InsertValue_ValueInserted()
        {
            var position1 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(1, 2),
                new Point<int>(4, 2),
                new Point<int>(3, 2),
                new Point<int>(1, 1)
            };
            var position2 = new Position<int>(PointDimension.Point1D)
            {
                new Point<int>(2),
                new Point<int>(1)
            };
            var matrix1 = new Matrix<int>(Enumerable.Repeat(position1, 3));
            var matrix2 = new Matrix<int>(Enumerable.Repeat(position2, 3));

            Container<int> container = new Container<int>() {matrix1,matrix2};
            container.Insert(1,matrix1);

            Assert.IsTrue(container.Count() == 3);
        }
    }
}
