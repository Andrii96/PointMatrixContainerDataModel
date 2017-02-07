using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMatrixContainerDataModel.Models.Models
{
    public abstract class Point<T>:NumericType<T> 
    {
        /// <summary>
        /// Represents point type e.g. 1D,2D,3D
        /// </summary>
        public abstract PointDimension PointType { get; }
    }
}
