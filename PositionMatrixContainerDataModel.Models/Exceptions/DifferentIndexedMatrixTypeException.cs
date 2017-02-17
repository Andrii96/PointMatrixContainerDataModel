using System;
using System.Runtime.Serialization;
using PositionMatrixContainer.Models.Point;

namespace PositionMatrixContainer.Models.Exceptions
{
    [Serializable]
    public class DifferentIndexedMatrixTypeException:ApplicationException
    {
        #region Properties
        public PointDimension Type1 { get; set; }
        public PointDimension Type2 { get; set; }

        #endregion

        #region Constructor

        public DifferentIndexedMatrixTypeException() : base() { }

        public DifferentIndexedMatrixTypeException(string message) : base(message) { }

        public DifferentIndexedMatrixTypeException(string message, Exception innerException):base(message,innerException) { }

        public DifferentIndexedMatrixTypeException(PointDimension type1, PointDimension type2):this(string.Format(
                    "Each indexed matrix via containers should be the same type. Type {0} and type {1} are different.",
                    type1, type2))
        {
            Type1 = type1;
            Type2 = type2;             
        }

        public DifferentIndexedMatrixTypeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        #endregion
    }
}
