using System;
using System.Runtime.Serialization;
using PositionMatrixContainer.Models.Point;

namespace PositionMatrixContainer.Models.Exceptions
{
    [Serializable]
    public class DifferentDimensionTypeInMatrixException:ApplicationException
    {
        #region Properties
        public PointDimension MatrixType { get; set; }
        #endregion

        #region Constructor

        public DifferentDimensionTypeInMatrixException() : base() { }

        public DifferentDimensionTypeInMatrixException(string message) : base(message) { }

        public DifferentDimensionTypeInMatrixException(string message, Exception innerException):base(message,innerException) { }

        public DifferentDimensionTypeInMatrixException(PointDimension type):this(string.Format("All positions in matrix should be of the same type.{0} type is different.", type))
        {
            MatrixType = type;         
        }

        protected DifferentDimensionTypeInMatrixException(SerializationInfo info,StreamingContext context) : base(info, context) { }
        #endregion
    }
}
