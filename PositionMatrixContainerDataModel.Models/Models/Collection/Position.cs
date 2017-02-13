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

        public Position(IEnumerable<Point<T>>  points)
        {
            if (!Validate(points))
            {
                throw new DifferentDimensionTypeInPositionException();
            }
            base.AddRange(points);

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
            if (!Validate(point))
            {
                throw new DifferentDimensionTypeInPositionException(point.PointType);
            }
            base.Add(point);
      
        }

        public new void AddRange(IEnumerable<Point<T>> points)
        {
            if (!Validate(points))
            {
                throw new DifferentDimensionTypeInPositionException();
            }

            if (Count > 0)
            {
                var pointType = points.First().PointType;

                if (this.Any(p => p.PointType != pointType))
                {
                    throw new DifferentDimensionTypeInPositionException();
                }               
            }

            base.AddRange(points);
        }

        public new void Insert(int index, Point<T> point)
        {
            if (!Validate(point))
            {
                throw new DifferentDimensionTypeInPositionException(point.PointType);
            }
            base.Insert(index,point);
        }

        public new void InsertRange(int index, IEnumerable<Point<T>> points)
        {
            if (!Validate(points))
            {
                throw new DifferentDimensionTypeInPositionException();
            }
            if (Count > 0)
            {
                var pointType = points.First().PointType;

                if (this.Any(p => p.PointType != pointType))
                {
                    throw new DifferentDimensionTypeInPositionException();
                }
            }
            base.InsertRange(index,points);
        }

        public new Point<T> this[int index] => this[index];

        public override string ToString()=> string.Join(",", this);

        #endregion

        #region Helpers

        private bool Validate(Point<T> point)
        {
            return PositionType == point.PointType;
        }

        private bool Validate(IEnumerable<Point<T>> points)
        {
            var pointType = points.FirstOrDefault()?.PointType;
            return points.All(p => p.PointType == pointType);
        }

        #endregion
    }








    //public class Position<T>:BaseCollection<Point<T>>
    //{ 
    //    #region Properties

    //   /// <summary>
    //   /// Gets position's point type
    //   /// </summary>
    //    public PointDimension Dimension { get; private set; }

    //    #endregion

    //    #region Constructor
    //    ///// <summary>
    //    ///// Default constructor. Initializes position instance
    //    ///// </summary>
    //    public Position()
    //    {

    //    }

    //    ///// <summary>
    //    ///// Initializes position instance with point type
    //    ///// </summary>
    //    ///// <param name="type"></param>
    //    public Position(PointDimension type) : base()
    //    {
    //        Dimension = type;
    //    }

    //    ///// <summary>
    //    ///// Initializes position instance with sequence of points
    //    ///// </summary>
    //    ///// <param name="points">Points sequence</param>
    //    public Position(IEnumerable<Point<T>> points)
    //    {
    //        if (!CheckDimensionType(points))
    //        {
    //            throw new DifferentDimensionTypeInPositionException(points.First().PointType);
    //        }
    //        Dimension = points.First().PointType;
    //    }

    //    /// <summary>
    //    /// Initializes position instance with points array
    //    /// </summary>
    //    /// <param name="points">points array for position</param>
    //    public Position(params Point<T>[] points) : this(points.ToList()) { }

    //    #endregion

    //    #region Methods
    //    /// <summary>
    //    /// Adds new point to position
    //    /// 
    //    /// Exceptions:
    //    /// DifferentDimensionTypeInPositionException
    //    /// </summary>
    //    /// <param name="point">point for adding</param>
    //    public void Add(Point<T> point)
    //    {
    //        if (point == null)
    //        {
    //            throw new ArgumentNullException();
    //        }
    //        if (!CheckDimensionType(point))
    //        {
    //            throw new DifferentDimensionTypeInPositionException(point.PointType);
    //        }
    //        base.Add(point);           
    //    }

    //    /// <summary>
    //    /// Represents position as string
    //    /// </summary>
    //    /// <returns></returns>
    //    public override string ToString()=> string.Join(",", this.Elements);

    //    #endregion

    //    #region Helpers

    //    private bool CheckDimensionType(IEnumerable<Point<T>> points)
    //    {
    //        var dimensionType = points.FirstOrDefault()?.PointType;
    //        return points.All(p => p.PointType == dimensionType);
    //    }

    //    private bool CheckDimensionType(Point<T> point)
    //    {

    //        if (base.Elements.Count == 0)
    //        {
    //            Dimension = point.PointType;
    //            return true;
    //        }

    //        return base.Elements.Last().PointType == point.PointType;
    //    }


    //    #endregion
    //}
}
