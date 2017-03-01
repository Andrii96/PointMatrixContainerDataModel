
using System;
using System.Linq;
using PositionMatrixContainerDataModel.ClientApplication.Helpers;
using PositionMatrixContainer.Models.Collection;
using PositionMatrixContainer.Models.Point;


namespace PositionMatrixContainerDataModel.ClientApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();
            Console.ReadLine();
        }

        //A container collection contains 3 containers.  
        //All data points are decimal.  Each matrix contains 100 positions.  
        //Each container contains 2 matrices with the first matrix in each container being XY data and the second matrix in each container being X data. 
        //Position 1 of the XY data contains 50 points.  Position 2 of the XY data contains 200 points.  
        //The other XY positions are empty.  
        //Position 1 and 2 of the X data matrix contain a numerical value, the others do not
        private static void Test1()
        {
            //Creating empty position
            var xyEmptyPosition = new Position<decimal>(PointDimension.Point2D);

            ////Creating positions with 2D points
            var xyPosition1 = new Position<decimal>(PmcRandom<decimal>.GetRandomPoints(PointDimension.Point2D, 50));
            var xyPosition2 = new Position<decimal>(PmcRandom<decimal>.GetRandomPoints(PointDimension.Point2D, 200));

            ////Creating matrix
            var matrix1 = new Matrix<decimal> { xyPosition1, xyPosition2 };
            //Filling matrix with empty position
            for (int i = 0; i < 98; i++)
            {
                matrix1.Add(xyEmptyPosition);
            }

            var xEmptyPosition = new Position<decimal>(PointDimension.Point1D);
            var xPosition1 = new Position<decimal>(PmcRandom<decimal>.GetRandomPoints(PointDimension.Point1D, 40));
            var xPosition2 = new Position<decimal>(PmcRandom<decimal>.GetRandomPoints(PointDimension.Point1D, 30));
            var matrix2 = new Matrix<decimal> { xPosition1, xPosition2 };

            for (int i = 0; i < 98; i++)
            {
                matrix2.Add(xEmptyPosition);
            }
            ////Creating container
            var container = new Container<decimal> {matrix1, matrix2};

            ////Creating containers collection
            var containersCollection = Enumerable.Repeat(container, 3);
            var containers = new Containers<decimal>(containersCollection);
            Console.WriteLine(containers.ToString());
        }

    }
}
