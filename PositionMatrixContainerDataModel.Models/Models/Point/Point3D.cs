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

        /// <summary>
        /// Initializes 3D point instance
        /// </summary>
        /// <param name="x">x value</param>
        /// <param name="y">y value</param>
        /// <param name="z">z value</param>
        public Point3D(T x,T y,T z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets point type
        /// </summary>
        public override PointDimension PointType=> PointDimension.Point3D;

        /// <summary>
        /// Gets x value
        /// </summary>
        public T X => _x;

        /// <summary>
        /// Gets y value
        /// </summary>
        public T Y => _y;

        /// <summary>
        /// Gets z value
        /// </summary>
        public T Z => _z;

        #endregion

        #region Methods
        /// <summary>
        /// Represents 3D point as string
        /// </summary>
        /// <returns>x,y,z 3D point values as string</returns>
        public override string ToString() => $"({X},{Y},{Z})";

        #endregion

    }
}
