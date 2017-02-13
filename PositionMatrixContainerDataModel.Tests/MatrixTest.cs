//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using PositionMatrixContainerDataModel.Models.Exceptions;
//using PositionMatrixContainerDataModel.Models.Factory;
//using PositionMatrixContainerDataModel.Models.Models;
//using PositionMatrixContainerDataModel.Models.Models.Collection;

//namespace PositionMatrixContainerDataModel.Tests
//{
//    [TestClass]
//    public class MatrixTest
//    {
//        [TestMethod]
//        public void DefaultConstructor_CreatingMatrix_MatrixCreated()
//        {
//            Matrix<int> matrix = new Matrix<int>();

//            Assert.IsNotNull(matrix);
//        }

//        [TestMethod]
//        public void ParametrizedConstructor_CreatingMatrix_MatrixCreated()
//        {
//            var position1 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point2D, 4);
//            var position2 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point2D, 2);

//            Matrix<int> matrix = new Matrix<int>(new List<Position<int>> {position1,position2});

//            Assert.IsNotNull(matrix);
//            Assert.IsTrue(matrix.Count()==2);
//        }

//        [TestMethod]
//        [ExpectedException(typeof(DifferentDimensionTypeInMatrixException))]
//        public void ParametrizedConstructor_CreatingMatrix_DimensionExceptionThrown()
//        {
//            var position1 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point2D, 4);
//            var position2 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point1D, 2);

//            Matrix<int> matrix = new Matrix<int>(new List<Position<int>> { position1, position2 });

//        }

//        [TestMethod]
//        [ExpectedException(typeof(DifferentNumberOfPointsInIndexed3DMatrixPositionsException))]
//        public void ParametrizedConstructor_CreatingMatrix_DifferentAmountOfPointsExceptionThrown()
//        {
//            var position1 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point3D, 4);
//            var position2 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point3D, 2);

//            Matrix<int> matrix = new Matrix<int>(new List<Position<int>> { position1, position2 });

//        }

//        [TestMethod]
//        public void Add_AddingPositionToMatrix_PositionnAdded()
//        {
//            var position1 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point2D, 3);
//            var position2 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point2D, 4);
//            Matrix<int> matrix = PMCDataModelFactory<int>.CreateMatrix(position1, 2);

//            matrix.Add(position2);

//            Assert.IsTrue(matrix.Count()==3);
//        }

//        [TestMethod]
//        [ExpectedException(typeof (ArgumentNullException))]
//        public void Add_AddingNullPosition_ExceptionThrown()
//        {
//            var position1 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point2D, 3);
//            Matrix<int> matrix = PMCDataModelFactory<int>.CreateMatrix(position1, 2);
//            matrix.Add(null);
//        }

//        [TestMethod]
//        [ExpectedException(typeof (DifferentNumberOfPointsInIndexed3DMatrixPositionsException))]
//        public void Add_AddingDifferentLength3DPosition_ExceptionThrown()
//        {
//            var position1 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point3D, 4);
//            var position2 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point3D, 2);

//            Matrix<int> matrix = new Matrix<int>();
//            matrix.Add(position1);
//            matrix.Add(position2);
//        }

//        [TestMethod]
//        [ExpectedException(typeof (DifferentDimensionTypeInMatrixException))]
//        public void Add_AddingDifferentTypePosition_ExceptionThrown()
//        {
//            var position1 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point2D, 4);
//            var position2 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point1D, 2);

//            Matrix<int> matrix = new Matrix<int>();
//            matrix.Add(position1);
//            matrix.Add(position2);
//        }
//    }
//}
