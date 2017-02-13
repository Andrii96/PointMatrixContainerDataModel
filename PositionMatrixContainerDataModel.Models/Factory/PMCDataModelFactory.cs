using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionMatrixContainerDataModel.Models.Exceptions;
using PositionMatrixContainerDataModel.Models.Models;
using PositionMatrixContainerDataModel.Models.Models.Collection;

namespace PositionMatrixContainerDataModel.Models.Factory
{
    public static class PMCDataModelFactory<T> where T:struct
    {
        /// <summary>
        /// Creates position
        /// </summary>
        /// <param name="points">Position type</param>
        /// <returns></returns>
        public static Position<T> CreatePosition(Point<T>[] points)
        {
            return new Position<T>(points.ToList());
        }

        /// <summary>
        /// Creates matrix 
        /// </summary>
        /// <param name="positions">Matrix position</param>
        /// <returns></returns>
        public static Matrix<T> CreateMatrix(Position<T>[] positions)
        {
            return new Matrix<T>(positions.ToList());
        }

        /// <summary>
        /// Creates container
        /// </summary>
        /// <param name="matrices">Container matrix</param>
        /// <returns></returns>
        public static Container<T> CreateContainer(Matrix<T>[] matrices)
        {
            return new Container<T>(matrices.ToList());
        }

        /// <summary>
        /// Creates containers collection
        /// </summary>
        /// <param name="container">Container's container</param>
        /// <param name="containerNumber">Amount of containers in collection</param>
        /// <returns></returns>
        public static Containers<T> CreateContainers(Container<T> container, int containerNumber)
        {
            return new Containers<T>(Enumerable.Repeat(container, containerNumber));
        }

    }
}
