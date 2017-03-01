using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMatrixContainer.UI.Helpers
{
    public class CreationWindowsViewModelInfo
    {
       public string  AmountOfContainers { get; private set; }
       public string  AmountOfMatrices { get; private set; }
       public string  AmountOfPositions { get; private set; }

        public CreationWindowsViewModelInfo(string containersNumber, string matricesNumber, string positionsNumber)
        {
            AmountOfContainers = containersNumber;
            AmountOfMatrices = matricesNumber;
            AmountOfPositions = positionsNumber;
        }
    }
}
