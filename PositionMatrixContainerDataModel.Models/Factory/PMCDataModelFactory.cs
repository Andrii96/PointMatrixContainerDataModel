using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionMatrixContainerDataModel.Models.Models;
using PositionMatrixContainerDataModel.Models.Models.Collection;

namespace PositionMatrixContainerDataModel.Models.Factory
{
    public static class PMCDataModelFactory<T>
    {
        /// <summary>
        /// Creates position
        /// </summary>
        /// <param name="positionType">Position type</param>
        /// <param name="count">Number of points in position</param>
        /// <returns></returns>
        public static Position<T> CreatePosition(PointDimension positionType, int count)
        {
           Position<T> position = new Position<T>(positionType);
            
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                switch (positionType)
                {
                    case PointDimension.Point1D:
                        position.Add(new Point1D<T>((dynamic)rand.Next()));
                        break;
                    case PointDimension.Point2D:
                        position.Add(new Point2D<T>((dynamic)rand.Next(),(dynamic)rand.Next()));
                        break;
                    case PointDimension.Point3D:
                        position.Add(new Point3D<T>((dynamic)rand.Next(), (dynamic)rand.Next(),(dynamic)rand.Next()));
                        break;
                }
            }
            return position;
        }

        /// <summary>
        /// Creates matrix 
        /// </summary>
        /// <param name="position">Matrix position</param>
        /// <param name="numberOfPositions"> Amount of positions</param>
        /// <returns></returns>
        public static Matrix<T> CreateMatrix(Position<T> position, int numberOfPositions)
        {
            return new Matrix<T>(Enumerable.Repeat(position, numberOfPositions));       
        }

        /// <summary>
        /// Creates container
        /// </summary>
        /// <param name="matrix">Container matrix</param>
        /// <param name="matricesNumber">Amount of matrices in container</param>
        /// <returns></returns>
        public static Container<T> CreateContainer(Matrix<T> matrix, int matricesNumber)
        {
            return new Container<T>(Enumerable.Repeat(matrix,matricesNumber));
        }

        /// <summary>
        /// Creates containers collection
        /// </summary>
        /// <param name="container">Container's container</param>
        /// <param name="containerNumber">Amount of containers in collection</param>
        /// <returns></returns>
        public static Containers<T> CreateContainers(Container<T> container, int containerNumber)
        {
            return new Containers<T>(Enumerable.Repeat(container,containerNumber));
        } 

    }
}
