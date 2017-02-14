
using System;
using System.Collections.Generic;
using System.Linq;
using PositionMatrixContainerDataModel.ClientApplication.Helpers;
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
            var XYemptyPosition =new Position<decimal>(PointDimension.Point2D);

            ////Creating positions with 2D points
            var XYposition1 = PmcDataModelFactory<decimal>.CreatePosition(PMCRandom<decimal>.GetRandomPoints(PointDimension.Point2D, 50));
            var XYposition2 = PmcDataModelFactory<decimal>.CreatePosition(PMCRandom<decimal>.GetRandomPoints(PointDimension.Point2D, 200));

            ////Creating matrix
            var matrix1 = new Matrix<decimal> {XYposition1, XYposition2};
            //Filling matrix with empty position
            for (int i = 0; i < 98; i++)
            {
                matrix1.Add(XYemptyPosition);
            }

            var XemptyPosition = new Position<decimal>(PointDimension.Point1D);
            var Xposition1 = PmcDataModelFactory<decimal>.CreatePosition(PMCRandom<decimal>.GetRandomPoints(PointDimension.Point1D, 40));
            var Xposition2 = PmcDataModelFactory<decimal>.CreatePosition(PMCRandom<decimal>.GetRandomPoints(PointDimension.Point1D, 30));
            var matrix2 = new Matrix<decimal> { Xposition1, Xposition2 };

            for (int i = 0; i < 98; i++)
            {
                matrix2.Add(XemptyPosition);
            }
            ////Creating container
            var container = new Container<decimal> {matrix1, matrix2};

            ////Creating containers collection
            var containersCollection = Enumerable.Repeat(container, 3);
            var containers = PmcDataModelFactory<decimal>.CreateContainers(containersCollection);
            Console.WriteLine(containers.ToString());
        }

    }
}
