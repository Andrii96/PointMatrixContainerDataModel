using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionMatrixContainerDataModel.Models.Models;
using PositionMatrixContainerDataModel.Models.Models.Collection;

namespace PositionMatrixContainerDataModel.ClientApplication.Helpers
{
    public static class PMCRandom<T> where T:struct
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
