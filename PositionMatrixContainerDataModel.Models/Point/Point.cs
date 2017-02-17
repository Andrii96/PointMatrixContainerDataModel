
using PositionMatrixContainer.Models.Helpers;

namespace PositionMatrixContainer.Models.Point
{
   /// <summary>
   /// Represents point (1D,2D,3D)
   /// </summary>
   /// <typeparam name="T"></typeparam>
    public class Point<T> : NumericType<T> where T:struct
    {
        #region Fields

            private readonly T? _x;
            private readonly T? _y;
            private readonly T? _z;

        #endregion

        #region Properties

        public T? X => _x;
        public T? Y => _y;
        public T? Z => _z;
        /// <summary>
        /// Gets point's type
        /// </summary>
        public PointDimension PointType { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates instance of 1D point
        /// </summary>
        /// <param name="x"> x value</param>
        public Point(T x)
        {
            _x = x;
            PointType = PointDimension.Point1D;
        }

        /// <summary>
        /// Creates instance of 2D point
        /// </summary>
        /// <param name="x">x value</param>
        /// <param name="y">y value</param>
        public Point(T x, T y)
        {
            _x = x;
            _y = y;
            PointType = PointDimension.Point2D;
        }

        /// <summary>
        /// Creates instance of 3D point
        /// </summary>
        /// <param name="x">x value</param>
        /// <param name="y">y value</param>
        /// <param name="z">z value</param>
        public Point(T x, T y, T z)
        {
            _x = x;
            _y = y;
            _z = z;
            PointType = PointDimension.Point3D;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets string representation of point
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            switch (PointType)
            {
                case PointDimension.Point1D:
                    return $"{_x}";
                case PointDimension.Point2D:
                    return $"({_x},{_y})";
                case PointDimension.Point3D:
                    return $"({_x},{_y},{_z})";
                default:
                    return string.Empty;
            }
        }

        #endregion

    }
}
