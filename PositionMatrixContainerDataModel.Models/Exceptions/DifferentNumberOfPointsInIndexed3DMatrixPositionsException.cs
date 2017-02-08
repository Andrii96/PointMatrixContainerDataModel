using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PositionMatrixContainerDataModel.Models.Exceptions
{
    [Serializable]
    public class DifferentNumberOfPointsInIndexed3DMatrixPositionsException:ApplicationException
    {
        #region Properties
        public int PointsNumber { get; set; }
        #endregion

        #region Constructor

        public DifferentNumberOfPointsInIndexed3DMatrixPositionsException() : base() { }

        public DifferentNumberOfPointsInIndexed3DMatrixPositionsException(string message) : base(message) { }

        public DifferentNumberOfPointsInIndexed3DMatrixPositionsException(string message, Exception innerException):base(message,innerException) { }

        public DifferentNumberOfPointsInIndexed3DMatrixPositionsException(int numberOfPoints):this(string.Format(
                    "Not all positions in 3D matrix have the same number of points. All positions should have {0} points.",
                    numberOfPoints))
        {
            PointsNumber = numberOfPoints;                
        }

        protected DifferentNumberOfPointsInIndexed3DMatrixPositionsException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        #endregion
    }
}
