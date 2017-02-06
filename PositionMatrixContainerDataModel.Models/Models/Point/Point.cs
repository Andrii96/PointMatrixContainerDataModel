using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMatrixContainerDataModel.Models.Models
{
    public abstract class Point<T>:NumericType<T> 
    {
        public abstract PointDimension PointType { get; }
    }
}
