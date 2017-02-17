using System;
using System.Collections.Generic;
using PositionMatrixContainer.Models.Point;

namespace PositionMatrixContainerDataModel.ClientApplication.Helpers
{
    public static class PmcRandom<T> where T:struct
    {
        public static IEnumerable<Point<T>>  GetRandomPoints(PointDimension pointType, int count)
        {
            List<Point<T>> points = new List<Point<T>>();
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                switch (pointType)
                {
                    case PointDimension.Point1D:
                        points.Add(new Point<T>((dynamic)random.Next()));
                        break;
                    case PointDimension.Point2D:
                        points.Add(new Point<T>((dynamic)random.Next(), (dynamic)random.Next()));
                        break;
                    case PointDimension.Point3D:
                        points.Add(new Point<T>((dynamic)random.Next(), (dynamic)random.Next(), (dynamic)random.Next()));
                        break;
                }
            }
            return points;
        }

    }
}
