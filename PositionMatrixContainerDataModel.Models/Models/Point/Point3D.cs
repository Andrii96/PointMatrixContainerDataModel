using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMatrixContainerDataModel.Models.Models
{
    public class Point3D<T> : Point<T> 
    {
        #region Fields

        private readonly T _x;
        private readonly T _y;
        private readonly T _z;

        #endregion

        #region Constructor

        public Point3D(T x,T y,T z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        #endregion

        #region Properties

        public override PointDimension PointType=> PointDimension.Point3D;

        public T X => _x;
        public T Y => _y;
        public T Z => _z;

        #endregion

        #region Methods

        public override string ToString() => $"({X},{Y},{Z})";

        #endregion

    }
}
