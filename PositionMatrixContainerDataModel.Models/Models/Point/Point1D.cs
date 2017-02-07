using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMatrixContainerDataModel.Models.Models
{
    public class Point1D<T> : Point<T> 
    {
        #region Fields
        private readonly T _x;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes 1D Point instance
        /// </summary>
        /// <param name="x"></param>
        public Point1D(T x)
        {
            _x = x;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets 1D point value
        /// </summary>
        public T X => _x;


        /// <summary>
        /// Gets point type 
        /// </summary>
        public override PointDimension PointType => PointDimension.Point1D;

        #endregion

        #region Methods
        /// <summary>
        /// Represents 1D point as string
        /// </summary>
        /// <returns>1D point value as string</returns>
        public override string ToString() => X.ToString();

        #endregion


    }
}
