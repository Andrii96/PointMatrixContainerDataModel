using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionMatrixContainerDataModel.Models.Exceptions;
using PositionMatrixContainerDataModel.Models.Models.Helpers;

namespace PositionMatrixContainerDataModel.Models.Models.Collection
{
    /// <summary>
    /// Represents collection of points
    /// </summary>
    /// <typeparam name="T"> Numeric type parameter</typeparam>
    public class Position<T> : List<Point<T>> where T : struct
    {
        #region Properties

        /// <summary>
        /// Defines position's type
        /// </summary>
        public PointDimension PositionType { get; private set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Instantiates position
        /// </summary>
        /// <param name="positionType">Position type</param>
        public Position(PointDimension positionType)
        {
            PositionType = positionType;
        }

        /// <summary>
        /// Instantiates position
        /// </summary>
        /// <param name="pointsCollection">Points collection</param>
        public Position(IEnumerable<Point<T>> pointsCollection)
        {
            var points = pointsCollection.ToList();

            if (!points.Any())
            {
                throw new ArgumentException();
            }
            this.AddRange(points);
            PositionType = points.First().PointType;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds point to position
        /// </summary>
        /// <param name="point"> Point for adding</param>
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

        /// <summary>
        /// Adds range of points to position
        /// </summary>
        /// <param name="pointsCollection">Points collection for adding</param>
        public new void AddRange(IEnumerable<Point<T>> pointsCollection)
        {
            var points = pointsCollection.ToList();

            if (ValidateSecuence(points))
            {
                base.AddRange(points);
            }
            else
            {
                throw new DifferentDimensionTypeInPositionException();
            }
        }

        /// <summary>
        /// Inserts point at specified index
        /// </summary>
        /// <param name="index">Index number</param>
        /// <param name="point">Point for inserting</param>
        public new void Insert(int index, Point<T> point)
        {
            if (ValidateSingleValue(point))
            {
                base.Insert(index, point);
            }
        }

        /// <summary>
        /// Inserts range of points at specified index
        /// </summary>
        /// <param name="index">Index </param>
        /// <param name="pointsCollection">Range of points for inserting</param>
        public new void InsertRange(int index, IEnumerable<Point<T>> pointsCollection)
        {
            var points = pointsCollection.ToList();

            if (ValidateSecuence(points))
            {
                base.InsertRange(index, points);
            }
            else
            {
                throw new DifferentDimensionTypeInPositionException();
            }
        }

        /// <summary>
        /// Represents position as string
        /// </summary>
        /// <returns></returns>
        public override string ToString() => string.Join(",", this);

        #endregion

        #region Helpers

        private bool CheckPointType(Point<T> point)
        {
            return PositionType == point.PointType;
        }

        private bool CheckPointType(IEnumerable<Point<T>> pointsCollection)
        {
            var points = pointsCollection.ToList();
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

        private bool ValidateSecuence(IEnumerable<Point<T>> pointsCollection)
        {
            var points = pointsCollection.ToList();

            if (!CheckPointType(points))
            {
                throw new DifferentDimensionTypeInPositionException();
            }
            return Count == 0 || PositionType == points.First().PointType;
        }


        #endregion
    }

}
