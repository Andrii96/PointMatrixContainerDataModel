using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMatrixContainerDataModel.Models.Models
{
    public class Point2D<T> : Point<T>
    {
        #region Fields

        private readonly T _x;
        private readonly T _y;

        #endregion

        #region Constructor

        public Point2D(T x, T y)
        {
            _x = x;
            _y = y;
        }

        #endregion

        #region Properties

        public override PointDimension PointType=>PointDimension.Point2D;
        public T X => _x;
        public T Y => _y;

        #endregion

        #region Methods

        public override string ToString() => $"({X},{Y})";

        #endregion
    }
}
