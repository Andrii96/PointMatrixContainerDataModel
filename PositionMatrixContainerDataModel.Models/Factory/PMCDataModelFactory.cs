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
    public static class PmcDataModelFactory<T> where T:struct
    {
        /// <summary>
        /// Creates position
        /// </summary>
        /// <param name="points">Points for creating position</param>
        /// <returns></returns>
        public static Position<T> CreatePosition(IEnumerable<Point<T>> points)
        {
            return new Position<T>(points);
        }

        /// <summary>
        /// Creates matrix 
        /// </summary>
        /// <param name="positions">Positions for creating matrix</param>
        /// <returns></returns>
        public static Matrix<T> CreateMatrix(IEnumerable<Position<T>> positions)
        {
            return new Matrix<T>(positions);
        }

        /// <summary>
        /// Creates container
        /// </summary>
        /// <param name="matrices">Matrices for creating container</param>
        /// <returns></returns>
        public static Container<T> CreateContainer(IEnumerable<Matrix<T>> matrices)
        {
            return new Container<T>(matrices);
        }

        /// <summary>
        /// Creates containers collection
        /// </summary>
        /// <param name="containers">Container's collection for creating containers</param>
        /// <returns></returns>
        public static Containers<T> CreateContainers(IEnumerable<Container<T>> containers )
        {
            return new Containers<T>(containers);
        }

    }
}
