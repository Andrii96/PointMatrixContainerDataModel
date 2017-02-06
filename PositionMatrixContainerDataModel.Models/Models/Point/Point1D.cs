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

        public Point1D(T x)
        {
            _x = x;
        }

        #endregion

        #region Properties

        public T X => _x;

        public override PointDimension PointType => PointDimension.Point1D;

        #endregion

        #region Methods

        public override string ToString() => X.ToString();

        #endregion


    }
}
