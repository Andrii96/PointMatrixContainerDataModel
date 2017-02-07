using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMatrixContainerDataModel.Models.Exceptions
{
    public class DifferentNumberOfPointsIn3DMatrixPositions:Exception
    {
        #region Properties
        public int PointsNumber { get; set; }

        public override string Message { get; }
        #endregion

        #region Constructor

        public DifferentNumberOfPointsIn3DMatrixPositions(int numberOfPoints)
        {
            PointsNumber = numberOfPoints;

            Message =
                string.Format(
                    "Not all positions in 3D matrix have the same number of points. All positions should have {0} points.",
                    PointsNumber);
        }
        #endregion
    }
}
