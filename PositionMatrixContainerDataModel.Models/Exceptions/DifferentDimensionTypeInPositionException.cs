using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionMatrixContainerDataModel.Models.Models;

namespace PositionMatrixContainerDataModel.Models.Exceptions
{
    public class DifferentDimensionTypeInPositionException:Exception
    {
        #region Properties
        public PointDimension PointType { get; set; }
       
        public override string Message { get; }


        #endregion

        #region Constructor

        public DifferentDimensionTypeInPositionException(PointDimension type)
        {
            PointType = type;
            Message = string.Format("All points in one position should be of the same type. Not all points have type{0}", PointType);
        }

        #endregion
    }
}
