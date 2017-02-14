using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PositionMatrixContainerDataModel.Models.Exceptions;
using PositionMatrixContainerDataModel.Models.Factory;
using PositionMatrixContainerDataModel.Models.Models;
using PositionMatrixContainerDataModel.Models.Models.Collection;

namespace PositionMatrixContainerDataModel.Tests
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void DefaultConstructor_CreatingMatrix_MatrixCreated()
        {
            Matrix<int> matrix = new Matrix<int>();

            Assert.IsNotNull(matrix);
        }

        [TestMethod]
        public void ParametrizedConstructor_CreatingMatrix_MatrixCreated()
        {
            var position1 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(1, 2),
                new Point<int>(4, 2),
                new Point<int>(3, 2),
                new Point<int>(1, 1)
            };
            var position2 =  new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(2, 2),
                new Point<int>(1, 5)
            };

            Matrix<int> matrix = new Matrix<int>(new List<Position<int>> { position1, position2 });

            Assert.IsNotNull(matrix);
            Assert.IsTrue(matrix.Count() == 2);
        }

        [TestMethod]
        [ExpectedException(typeof(DifferentDimensionTypeInMatrixException))]
        public void ParametrizedConstructor_CreatingMatrix_DimensionExceptionThrown()
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
            Matrix<int> matrix = new Matrix<int>(new List<Position<int>> { position1, position2 });

        }

        [TestMethod]
        [ExpectedException(typeof(DifferentNumberOfPointsInIndexed3DMatrixPositionsException))]
        public void ParametrizedConstructor_CreatingMatrix_DifferentAmountOfPointsExceptionThrown()
        {
            var position1 = new Position<int>(PointDimension.Point3D)
            {
                new Point<int>(1, 2,3),
                new Point<int>(4, 2,4),
                new Point<int>(3, 2,1),
                new Point<int>(1, 1,6)
            };
            var position2 = new Position<int>(PointDimension.Point3D)
            {
                new Point<int>(2, 2, 1),
                new Point<int>(1, 5, 1)
            };
            Matrix<int> matrix = new Matrix<int>(new List<Position<int>> { position1, position2 });

        }

        [TestMethod]
        public void Add_AddingPositionToMatrix_PositionnAdded()
        {
            var position1 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(1, 2),
                new Point<int>(4, 2),
                new Point<int>(3, 2),
                new Point<int>(1, 1)
            };
            var position2 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(2, 2),
                new Point<int>(1, 5),
                new Point<int>(1, 1)
            };

            Matrix<int> matrix = new Matrix<int>(Enumerable.Repeat(position1,2));

            matrix.Add(position2);

            Assert.IsTrue(matrix.Count() == 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_AddingNullPosition_ExceptionThrown()
        {
            var position1 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(1, 2),
                new Point<int>(4, 2),
                new Point<int>(3, 2)
            };
            Matrix<int> matrix = new Matrix<int>(Enumerable.Repeat(position1,2));
            matrix.Add(null);
        }

        [TestMethod]
        [ExpectedException(typeof(DifferentNumberOfPointsInIndexed3DMatrixPositionsException))]
        public void Add_AddingDifferentLength3DPosition_ExceptionThrown()
        {
            var position1 = new Position<int>(PointDimension.Point3D)
            {
                new Point<int>(1, 2,3),
                new Point<int>(4, 2,4),
                new Point<int>(3, 2,1),
                new Point<int>(1, 1,6)
            };
            var position2 = new Position<int>(PointDimension.Point3D)
            {
                new Point<int>(2, 2, 1),
                new Point<int>(1, 5, 1)
            };

            Matrix<int> matrix = new Matrix<int>();
            matrix.Add(position1);
            matrix.Add(position2);
        }

        [TestMethod]
        [ExpectedException(typeof(DifferentDimensionTypeInMatrixException))]
        public void Add_AddingDifferentTypePosition_ExceptionThrown()
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
           
            Matrix<int> matrix = new Matrix<int>();
            matrix.Add(position1);
            matrix.Add(position2);
        }

        [TestMethod]
        public void InsertValue_InsertingValue_ValueInserted()
        {
            var position1 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(1, 2),
                new Point<int>(4, 2),
                new Point<int>(3, 2),
                new Point<int>(1, 1)
            };
            var position2 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(2, 2),
                new Point<int>(1, 5),
                new Point<int>(1, 1)
            };

            Matrix<int> matrix = new Matrix<int>(Enumerable.Repeat(position1, 2));
            matrix.Insert(1,position2);

            Assert.IsTrue(matrix.Count() ==3);
            Assert.IsTrue(matrix[1].Count()==3);

        }

        [TestMethod]
        public void InsertRange_InsertingRange_ExceptionThrown()
        {
            var position1 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(1, 2),
                new Point<int>(4, 2),
                new Point<int>(3, 2),
                new Point<int>(1, 1)
            };
            var position2 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(2, 2),
                new Point<int>(1, 5),
                new Point<int>(1, 1)
            };

            Matrix<int> matrix = new Matrix<int>(Enumerable.Repeat(position1, 2));

            matrix.InsertRange(1,Enumerable.Repeat(position2,3));

            Assert.IsTrue(matrix.Count()==5);
        }
    }
}
