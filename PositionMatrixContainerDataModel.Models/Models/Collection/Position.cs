using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMatrixContainerDataModel.Models.Models.Collection
{
    public class Position<T>:BaseCollection<Point<T>> 
    {
        #region Properties

       // public IList<Point<T>> Points => this.Elements;
        public PointDimension Dimension { get; private set; }

        #endregion

        #region Constructor

        public Position() : base() { }

        //TODO Check type and throw custom exception
        public Position(IEnumerable<Point<T>> points)
        {
            if (!CheckDimensionType(points))
            {
                throw new Exception();
            }
            base.Fill(points);
            Dimension = points.First().PointType;
        }

        public Position(params Point<T>[] points) : this(points.ToList()) { }

        #endregion

        #region Methods
        //TODO throw exception when wrong type
        public override void Add(Point<T> point)
        {
            if (!CheckDimensionType(point))
            {

            }
            base.Add(point);
            
        }

        public override string ToString()
        {
            return string.Join(",", base.Elements);
        }

        #endregion

        #region Helpers

        private bool CheckDimensionType(IEnumerable<Point<T>> points)
        {
            var dimensionType = points.FirstOrDefault()?.PointType;
            return points.All(p => p.PointType == dimensionType);
        }

        private bool CheckDimensionType(Point<T> point)
        {
            if (base.Elements.Count == 0)
            {
                Dimension = point.PointType;
                return true;
            }

            return base.Elements.Last().PointType == point.PointType;
        }


        #endregion
    }
}
