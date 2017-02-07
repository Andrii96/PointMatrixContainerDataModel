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
        /// <summary>
        /// Initializes 2D point instance
        /// </summary>
        /// <param name="x">x value</param>
        /// <param name="y"> y value</param>
        public Point2D(T x, T y)
        {
            _x = x;
            _y = y;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets point type
        /// </summary>
        public override PointDimension PointType=>PointDimension.Point2D;

        /// <summary>
        /// Gets x value
        /// </summary>
        public T X => _x;

        /// <summary>
        /// Gets y value
        /// </summary>
        public T Y => _y;

        #endregion

        #region Methods
        /// <summary>
        /// Represents 2D point as string
        /// </summary>
        /// <returns>x and y values of the point as string</returns>
        public override string ToString() => $"({X},{Y})";

        #endregion
    }
}
