
using System;
using PositionMatrixContainerDataModel.Models.Factory;
using PositionMatrixContainerDataModel.Models.Models;
using PositionMatrixContainerDataModel.Models.Models.Collection;


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
            var XYemptyPosition = PMCDataModelFactory<decimal>.CreatePosition(PointDimension.Point2D, 0);

            //Creating positions with 2D points
            var XYposition1 = PMCDataModelFactory<decimal>.CreatePosition(PointDimension.Point2D, 50);
            var XYposition2 = PMCDataModelFactory<decimal>.CreatePosition(PointDimension.Point2D, 200);

            //Creating matrix
            var matrix1 = new Matrix<decimal> {XYposition1, XYposition2};
            //Filling matrix with empty position
            for (int i = 0; i < 98; i++)
            {
                matrix1.Add(XYemptyPosition);
            }

            var XemptyPosition = PMCDataModelFactory<decimal>.CreatePosition(PointDimension.Point1D, 0);
            var Xposition1 = PMCDataModelFactory<decimal>.CreatePosition(PointDimension.Point1D, 40);
            var Xposition2 = PMCDataModelFactory<decimal>.CreatePosition(PointDimension.Point1D, 30);
            var matrix2 = new Matrix<decimal> {Xposition1, Xposition2};

            for (int i = 0; i < 98; i++)
            {
                matrix2.Add(XemptyPosition);
            }
            //Creating container
            var container = new Container<decimal> {matrix1, matrix2};

            //Creating containers collection
            var containers = PMCDataModelFactory<decimal>.CreateContainers(container, 3);

            Console.WriteLine(containers.ToString());
        }

    }
}
