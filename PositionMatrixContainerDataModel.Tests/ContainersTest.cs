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
//    public class ContainersTest
//    {
//        private static Containers<int> _containers;

//        [ClassInitialize]
//        public static void SetUp(TestContext context)
//        {
//            var position1 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point2D, 6);
//            var position2 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point1D, 4);

//            var matrix1 = PMCDataModelFactory<int>.CreateMatrix(position1, 5);
//            var matrix2 = PMCDataModelFactory<int>.CreateMatrix(position2, 5);

//            var container1 = new Container<int>(new List<Matrix<int>> {matrix1, matrix2});

//            _containers = PMCDataModelFactory<int>.CreateContainers(container1, 2);
      
//        }

//        [TestMethod]
//        public void DefaultConstructor_ContainersCollectionCreating_ContainersCreated()
//        {
//            Container<int> containers = new Container<int>();
//            Assert.IsNotNull(containers);
//        }

//        [TestMethod]
//        public void Add_ContainerAdding_ContainerAdded()
//        {
//            var position1 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point2D, 3);
//            var position2 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point1D, 5);

//            var matrix1 = PMCDataModelFactory<int>.CreateMatrix(position1, 5);
//            var matrix2 = PMCDataModelFactory<int>.CreateMatrix(position2, 5);

//            var container = new Container<int>(new List<Matrix<int>> { matrix1, matrix2 });

//            _containers.Add(container);

//            Assert.IsTrue(_containers.Count()==3);
//        }

//        [TestMethod]
//        [ExpectedException(typeof (DifferentMatrixSizeException))]
//        public void Add_ContainerAdding_DifferentMatrixExceptionThrown()
//        {
//            var position1 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point2D, 3);
//            var position2 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point1D, 5);

//            var matrix1 = PMCDataModelFactory<int>.CreateMatrix(position1, 3);
//            var matrix2 = PMCDataModelFactory<int>.CreateMatrix(position2, 3);

//            var container = new Container<int>(new List<Matrix<int>> { matrix1, matrix2 });

//            _containers.Add(container);
//        }

//        [TestMethod]
//        [ExpectedException(typeof (DifferentContainersSizeException))]
//        public void Add_ContainerAdding_DifferentContainerSizeExceptionThrown()
//        {
//            var position1 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point2D, 3);
           
//            var matrix1 = PMCDataModelFactory<int>.CreateMatrix(position1, 5); 

//            var container = new Container<int>(new List<Matrix<int>> { matrix1});

//            _containers.Add(container);
//        }

//        [TestMethod]
//        [ExpectedException(typeof (DifferentIndexedMatrixTypeException))]
//        public void Add_ContainerAdding_DifferentIndexedMatrixTypeExceptionThrown()
//        {
//            var position1 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point1D, 6);
//            var position2 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point2D, 4);

//            var matrix1 = PMCDataModelFactory<int>.CreateMatrix(position1, 5);
//            var matrix2 = PMCDataModelFactory<int>.CreateMatrix(position2, 5);

//            var container = new Container<int>(new List<Matrix<int>> { matrix1,matrix2 });

//            _containers.Add(container);
//        }

//        [TestMethod]
//        [ExpectedException(typeof (DifferentNumberOfPointsInIndexed3DMatrixPositionsException))]
//        public void Add_ContainerAdding_DifferentNumberOfPointsInIndexed3DMatrixPositionsExceptionThrown()
//        {
//            var position1 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point3D, 6);
//            var position2 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point1D, 4);
//            var position3 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point3D, 5);
//            var position4 = PMCDataModelFactory<int>.CreatePosition(PointDimension.Point1D, 2);

//            var matrix1 = PMCDataModelFactory<int>.CreateMatrix(position1, 5);
//            var matrix2 = PMCDataModelFactory<int>.CreateMatrix(position2, 5);

//            var matrix3 = PMCDataModelFactory<int>.CreateMatrix(position3, 5);
//            var matrix4 = PMCDataModelFactory<int>.CreateMatrix(position4, 5);

//            var container1 = new Container<int>(new List<Matrix<int>> { matrix1, matrix2 });
//            var container2 = new Container<int>(new List<Matrix<int>> { matrix3, matrix4 });

//            var containers = new Containers<int>();
//            containers.Add(container1);
//            containers.Add(container2);
//        }

//        [TestMethod]
//        [ExpectedException(typeof (ArgumentNullException))]
//        public void Add_AddNullContainer_ExceptionThrown()
//        {
//            _containers.Add(null);
//        }

//    }
//}
