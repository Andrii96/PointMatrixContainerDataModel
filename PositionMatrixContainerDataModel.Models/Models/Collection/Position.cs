using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionMatrixContainerDataModel.Models.Exceptions;
using PositionMatrixContainerDataModel.Models.Models.Helpers;

namespace PositionMatrixContainerDataModel.Models.Models.Collection
{
    public class Position<T> : List<Point<T>> where T : struct
    {
        #region Properties

        public PointDimension PositionType { get; private set; }

        #endregion

        #region Constructor

        public Position(PointDimension positionType)
        {
            PositionType = positionType;
        }

        public Position(IEnumerable<Point<T>> points)
        {
            this.AddRange(points);
            PositionType = points.First().PointType;
        }

        #endregion

        #region Methods

        public new void Add(Point<T> point)
        {
            if (point == null)
            {
                throw new ArgumentNullException();
            }
            if (ValidateSingleValue(point))
            {
                base.Add(point);
            }
        }

        public new void AddRange(IEnumerable<Point<T>> points)
        {
            if (ValidateSecuence(points))
            {
                base.AddRange(points);
            }
            else
            {
                throw new DifferentDimensionTypeInPositionException();
            }
        }

        public new void Insert(int index, Point<T> point)
        {
            if (ValidateSingleValue(point))
            {
                base.Insert(index, point);
            }
        }

        public new void InsertRange(int index, IEnumerable<Point<T>> points)
        {
            if (ValidateSecuence(points))
            {
                base.InsertRange(index, points);
            }
            else
            {
                throw new DifferentDimensionTypeInPositionException();
            }
        }

        public new Point<T> this[int index] => this[index];

        public override string ToString() => string.Join(",", this);

        #endregion

        #region Helpers

        private bool CheckPointType(Point<T> point)
        {
            return PositionType == point.PointType;
        }

        private bool CheckPointType(IEnumerable<Point<T>> points)
        {
            var pointType = points.FirstOrDefault()?.PointType;
            return points.All(p => p.PointType == pointType);
        }

        private bool ValidateSingleValue(Point<T> point)
        {
            if (!CheckPointType(point))
            {
                throw new DifferentDimensionTypeInPositionException(point.PointType);
            }
            return true;
        }

        private bool ValidateSecuence(IEnumerable<Point<T>> points)
        {
            if (!CheckPointType(points))
            {
                throw new DifferentDimensionTypeInPositionException();
            }
            return Count == 0 || PositionType == points.First().PointType;
        }


        #endregion
    }

}
