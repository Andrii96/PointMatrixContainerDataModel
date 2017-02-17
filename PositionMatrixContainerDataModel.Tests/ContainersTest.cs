using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PositionMatrixContainer.Models.Exceptions;
using PositionMatrixContainer.Models.Collection;
using PositionMatrixContainer.Models.Point;

namespace PositionMatrixContainerDataModel.Tests
{
    [TestClass]
    public class ContainersTest
    {
        private static Containers<int> _containers;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            var position1 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(1, 2),
                new Point<int>(4, 2),
                new Point<int>(3, 2),
                new Point<int>(1, 1),
                new Point<int>(7, 2),
                new Point<int>(1, 9)
            };
            var position2 = new Position<int>(PointDimension.Point1D)
            {
                new Point<int>(2),
                new Point<int>(1),
                new Point<int>(2),
                new Point<int>(1)
            };
           
            var matrix1 = new Matrix<int>(Enumerable.Repeat(position1,5)); 
            var matrix2 = new Matrix<int>(Enumerable.Repeat(position2,5)); 

            var container1 = new Container<int>(new List<Matrix<int>> { matrix1, matrix2 });

            _containers = new Containers<int>(Enumerable.Repeat(container1,2)); 

        }

        [TestMethod]
        public void DefaultConstructor_ContainersCollectionCreating_ContainersCreated()
        {
            Container<int> containers = new Container<int>();
            Assert.IsNotNull(containers);
        }

        [TestMethod]
        public void Add_ContainerAdding_ContainerAdded()
        {
            var position1 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(1, 2),
                new Point<int>(4, 2),
                new Point<int>(3, 2)
            };
            var position2 = new Position<int>(PointDimension.Point1D)
            {
                new Point<int>(2),
                new Point<int>(1),
                new Point<int>(2),
                new Point<int>(1),
                new Point<int>(1)
            };
          

            var matrix1 = new Matrix<int>(Enumerable.Repeat(position1,5)); 
            var matrix2 = new Matrix<int>(Enumerable.Repeat(position2,5)); 

            var container = new Container<int>(new List<Matrix<int>> { matrix1, matrix2 });

            _containers.Add(container);

            Assert.IsTrue(_containers.Count() == 3);
        }

        [TestMethod]
        [ExpectedException(typeof(DifferentMatrixSizeException))]
        public void Add_ContainerAdding_DifferentMatrixExceptionThrown()
        {
            var position1 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(1, 2),
                new Point<int>(4, 2),
                new Point<int>(3, 2)
            };
            var position2 = new Position<int>(PointDimension.Point1D)
            {
                new Point<int>(2),
                new Point<int>(1),
                new Point<int>(2),
                new Point<int>(1),
                new Point<int>(1)
            };


            var matrix1 = new Matrix<int>(Enumerable.Repeat(position1, 3));
            var matrix2 = new Matrix<int>(Enumerable.Repeat(position2, 5));
            

            var container = new Container<int>(new List<Matrix<int>> { matrix1, matrix2 });

            _containers.Add(container);
        }

        [TestMethod]
        [ExpectedException(typeof(DifferentContainersSizeException))]
        public void Add_ContainerAdding_DifferentContainerSizeExceptionThrown()
        {
            var position1 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(1, 2),
                new Point<int>(4, 2),
                new Point<int>(3, 2)
            };
            

            var matrix1 = new Matrix<int>(Enumerable.Repeat(position1,5)); 

            var container = new Container<int>(new List<Matrix<int>> { matrix1 });

            _containers.Add(container);
        }

        [TestMethod]
        [ExpectedException(typeof(DifferentIndexedMatrixTypeException))]
        public void Add_ContainerAdding_DifferentIndexedMatrixTypeExceptionThrown()
        {
            var position1 = new Position<int>(PointDimension.Point1D)
            {
                new Point<int>(1),
                new Point<int>(4),
                new Point<int>(3)
            };
            var position2 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(2,1),
                new Point<int>(1,1),
                new Point<int>(2,2),
                new Point<int>(1,4),
                new Point<int>(1,5),
                new Point<int>(4,3)
            };

            var matrix1 = new Matrix<int>(Enumerable.Repeat(position1,5)); 
            var matrix2 = new Matrix<int>(Enumerable.Repeat(position2, 5)); 

            var container = new Container<int>(new List<Matrix<int>> { matrix1, matrix2 });

            _containers.Add(container);
        }

        [TestMethod]
        [ExpectedException(typeof(DifferentNumberOfPointsInIndexed3DMatrixPositionsException))]
        public void Add_ContainerAdding_DifferentNumberOfPointsInIndexed3DMatrixPositionsExceptionThrown()
        {
            var position1 = new Position<int>(PointDimension.Point3D)
            {
                new Point<int>(1,2,3),
                new Point<int>(4,3,4),
                new Point<int>(3,1,1),
                new Point<int>(1,2,1),
                new Point<int>(4,6,4),
                new Point<int>(3,6,9)
            };

            var position2 = new Position<int>(PointDimension.Point1D)
            {
                new Point<int>(1),
                new Point<int>(4),
                new Point<int>(3),
                new Point<int>(1)
            };

            var position3 = new Position<int>(PointDimension.Point3D)
            {
                new Point<int>(1,2,3),
                new Point<int>(4,3,4),
                new Point<int>(3,1,1),
                 new Point<int>(1,2,1),
                new Point<int>(4,6,4)
            };

            var position4 = new Position<int>(PointDimension.Point1D)
            {
                new Point<int>(1),
                new Point<int>(4)
            };

            var matrix1 = new Matrix<int>(Enumerable.Repeat(position1,5)); 
            var matrix2 = new Matrix<int>(Enumerable.Repeat(position2,5)); 

            var matrix3 = new Matrix<int>(Enumerable.Repeat(position3,5)); 
            var matrix4 = new Matrix<int>(Enumerable.Repeat(position4,5)); 

            var container1 = new Container<int>(new List<Matrix<int>> { matrix1, matrix2 });
            var container2 = new Container<int>(new List<Matrix<int>> { matrix3, matrix4 });

            var containers = new Containers<int>();
            containers.Add(container1);
            containers.Add(container2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_AddNullContainer_ExceptionThrown()
        {
            _containers.Add(null);
        }

        [TestMethod]
        [ExpectedException(typeof (DifferentMatrixSizeException))]
        public void InsertRange_InsertingValue_DifferentMatrixSizeExceptionThrow()
        {
            var position1 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(1, 2),
                new Point<int>(4, 2),
                new Point<int>(3, 2)
            };
            var position2 = new Position<int>(PointDimension.Point1D)
            {
                new Point<int>(2),
                new Point<int>(1),
                new Point<int>(2),
                new Point<int>(1),
                new Point<int>(1)
            };


            var matrix1 = new Matrix<int>(Enumerable.Repeat(position1, 4));
            var matrix2 = new Matrix<int>(Enumerable.Repeat(position2, 4));


            var container = new Container<int>(new List<Matrix<int>> { matrix1, matrix2 });

            _containers.InsertRange(1,Enumerable.Repeat(container,2));
        }

        [TestMethod]
        [ExpectedException(typeof (DifferentContainersSizeException))]
        public void InsertRange_InsertingValue_DifferentContainersSizeExceptionThrow()
        {
            var position1 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(1, 2),
                new Point<int>(4, 2),
                new Point<int>(3, 2)
            };


            var matrix1 = new Matrix<int>(Enumerable.Repeat(position1, 5));

            var container = new Container<int>(new List<Matrix<int>> { matrix1 });

            _containers.InsertRange(1,Enumerable.Repeat(container,7));
        }

        [TestMethod]
        [ExpectedException(typeof(DifferentIndexedMatrixTypeException))]
        public void InsertRange_InsertingContainer_DifferentIndexedMatrixTypeExceptionThrown()
        {
            var position1 = new Position<int>(PointDimension.Point1D)
            {
                new Point<int>(1),
                new Point<int>(4),
                new Point<int>(3)
            };
            var position2 = new Position<int>(PointDimension.Point2D)
            {
                new Point<int>(2,1),
                new Point<int>(1,1),
                new Point<int>(2,2),
                new Point<int>(1,4),
                new Point<int>(1,5),
                new Point<int>(4,3)
            };

            var matrix1 = new Matrix<int>(Enumerable.Repeat(position1, 5));
            var matrix2 = new Matrix<int>(Enumerable.Repeat(position2, 5));

            var container = new Container<int>(new List<Matrix<int>> { matrix1, matrix2 });

            _containers.InsertRange(1,Enumerable.Repeat(container,2));
        }
    }
}
