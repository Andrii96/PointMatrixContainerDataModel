using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PositionMatrixContainerDataModel.Models.Models;

namespace PositionMatrixContainerDataModel.Models.Exceptions
{
    [Serializable]
    public class DifferentDimensionTypeInPositionException:ApplicationException
    {
        #region Properties
        public PointDimension PointType { get; set; }
        #endregion

        #region Constructor

        public DifferentDimensionTypeInPositionException() : base() { }

        public DifferentDimensionTypeInPositionException(string message) : base(message) { }

        public DifferentDimensionTypeInPositionException(string message, Exception innerException):base(message,innerException) { }

        public DifferentDimensionTypeInPositionException(PointDimension type):this(string.Format("All points in one position should be of the same type. Not all points have type{0}", type))
        {
            PointType = type;           
        }

        protected DifferentDimensionTypeInPositionException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        #endregion
    }
}
