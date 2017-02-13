//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using PositionMatrixContainerDataModel.Models.Factory;
//using PositionMatrixContainerDataModel.Models.Models;
//using PositionMatrixContainerDataModel.Models.Models.Collection;
//using System.Collections.Generic;
//using System.Linq;
//using PositionMatrixContainerDataModel.Models.Exceptions;

//namespace PositionMatrixContainerDataModel.Tests
//{
//    [TestClass]
//    public class ContainerTest
//    {
//        [TestMethod]
//        public void DefaultConstructor_CreatingContainer_ContainerCreated()
//        {
//            Container<int> container = new Container<int>();
//            Assert.IsNotNull(container);
//        }

//        [TestMethod]
//        public void ParametrizedConstructor_CreatingContainer_ContainerCreated()
//        {
//            var position1 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point1D, 2);
//            var position2 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point2D, 4);
//            var matrix1 = PMCDataModelFactory<int>.CreateMatrix(position1, 3);
//            var matrix2 = PMCDataModelFactory<int>.CreateMatrix(position2, 3);

//            Container<int> container = new Container<int>(new List<Matrix<int>> {matrix1, matrix2});

//            Assert.IsNotNull(container);
//            Assert.IsTrue(container.Count()==2);
//        }

//        [TestMethod]
//        [ExpectedException(typeof(DifferentMatrixSizeException))]
//        public void ParametrizedConstructor_CreatingContainer_ContainerCreationFailed()
//        {
//            var position1 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point1D, 2);
//            var position2 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point2D, 4);
//            var matrix1 = PMCDataModelFactory<int>.CreateMatrix(position1, 3);
//            var matrix2 = PMCDataModelFactory<int>.CreateMatrix(position2, 5);

//            Container<int> container = new Container<int>(new List<Matrix<int>> { matrix1, matrix2 });
//        }

//        [TestMethod]
//        public void Add_AddingMatrixToContainer_MatrixAdded()
//        {
//            var position1 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point1D, 2);
//            var position2 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point2D, 4);
//            var matrix1 = PMCDataModelFactory<int>.CreateMatrix(position1, 3);
//            var matrix2 = PMCDataModelFactory<int>.CreateMatrix(position2, 3);

//            Container<int>container = new Container<int>();
//            container.Add(matrix1);
//            container.Add(matrix2);

//            Assert.IsTrue(container.Count()==2);
//        }


//        [TestMethod]
//        [ExpectedException(typeof(DifferentMatrixSizeException))]
//        public void Add_AddingDifferentSizeMatrixToContainer_MatrixAddingFailed()
//        {
//            var position1 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point1D, 2);
//            var position2 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point2D, 4);
//            var matrix1 = PMCDataModelFactory<int>.CreateMatrix(position1, 3);
//            var matrix2 = PMCDataModelFactory<int>.CreateMatrix(position2, 5);

//            Container<int> container = new Container<int>();
//            container.Add(matrix1);
//            container.Add(matrix2);
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ArgumentNullException))]
//        public void Add_AddingNullMatrixToContainer_MatrixAddingFailed()
//        {
//            Container<int> container = new Container<int>();
//            container.Add(null);
//        }
//    }
//}
