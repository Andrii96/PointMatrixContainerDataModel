using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionMatrixContainerDataModel.Models.Exceptions;

namespace PositionMatrixContainerDataModel.Models.Models.Collection
{
    public class Position<T>:BaseCollection<Point<T>> 
    {
        #region Properties

       /// <summary>
       /// Gets position's point type
       /// </summary>
        public PointDimension Dimension { get; private set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor. Initializes position instance
        /// </summary>
        public Position() : base()
        {
         
        }

        /// <summary>
        /// Initializes position instance with point type
        /// </summary>
        /// <param name="type"></param>
        public Position(PointDimension type) : base()
        {
            Dimension = type;
        }

        /// <summary>
        /// Initializes position instance with sequence of points
        /// </summary>
        /// <param name="points">Points sequence</param>
        public Position(IEnumerable<Point<T>> points)
        {
            if (!CheckDimensionType(points))
            {
                throw new DifferentDimensionTypeInPositionException(points.First().PointType);
            }
            base.Fill(points);
            Dimension = points.First().PointType;
        }

        /// <summary>
        /// Initializes position instance with points array
        /// </summary>
        /// <param name="points">points array for position</param>
        public Position(params Point<T>[] points) : this(points.ToList()) { }

        #endregion

        #region Methods
        /// <summary>
        /// Adds new point to position
        /// 
        /// Exceptions:
        /// DifferentDimensionTypeInPositionException
        /// </summary>
        /// <param name="point">point for adding</param>
        public override void Add(Point<T> point)
        {
            if (!CheckDimensionType(point))
            {
                throw new DifferentDimensionTypeInPositionException(point.PointType);
            }
            base.Add(point);
            
        }

        /// <summary>
        /// Represents position as string
        /// </summary>
        /// <returns></returns>
        public override string ToString()=> string.Join(",", base.Elements);

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
