using System;
using System.Runtime.Serialization;

namespace PositionMatrixContainer.Models.Exceptions
{
    [Serializable]
    public class DifferentMatrixSizeException:ApplicationException
    {
        #region Properties
        public int MatrixSize { get; set; }
        #endregion

        #region Constructor

        public DifferentMatrixSizeException() : base() { }

        public DifferentMatrixSizeException(string message) : base(message) { }

        public DifferentMatrixSizeException(string message, Exception innerException):base(message,innerException) { }

        public DifferentMatrixSizeException(int matrixSize):this(string.Format("All matrices in container should have the same length - {0} elements.", matrixSize))
        {
            MatrixSize = matrixSize;
        }

        protected DifferentMatrixSizeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        #endregion
    }
}
