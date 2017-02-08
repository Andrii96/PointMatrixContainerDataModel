using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionMatrixContainerDataModel.Models.Exceptions;

namespace PositionMatrixContainerDataModel.Models.Models.Collection
{
    public class Matrix<T>:BaseCollection<Position<T>>
    {
        #region Constructor
        /// <summary>
        /// Default constructor. Initializes matrix instance.
        /// </summary>
        public Matrix() : base(){ }

        /// <summary>
        /// Iniitializes matrix instance with position sequence
        /// 
        /// Exceptions:
        /// DifferentDimensionTypeInPositionException,
        /// DifferentNumberOfPointsIn3DMatrixPositions
        /// </summary>
        /// <param name="positions"></param>
        public Matrix(IEnumerable<Position<T>> positions)
        {
            if (!CheckMatrixType(positions))
            {
                throw new DifferentDimensionTypeInMatrixException(positions.First().Dimension);
            }

            if (positions.First().Dimension == PointDimension.Point3D && !Check3DMatrixNumberPoint(positions))
            {
                throw new DifferentNumberOfPointsInIndexed3DMatrixPositionsException(positions.First().Count());
            }

             base.Fill(positions);
        }
        #endregion

        #region Methods

        /// <summary>
        /// Adds new position to matrix.
        /// 
        /// Exceptions:
        /// DifferentDimensionTypeInMatrixException,
        /// DifferentNumberOfPointsIn3DMatrixPositions
        /// </summary>
        /// <param name="position">position for adding</param>
        public override void Add(Position<T> position)
        {
            if (position == null)
            {
                throw new ArgumentNullException();
            }      
            if (!CheckPositionType(position))
            {
                throw new DifferentDimensionTypeInMatrixException(position.Dimension);
            }
            if (position.Dimension == PointDimension.Point3D && !Check3DMatrixNumberPoint(position))
            {
                throw new DifferentNumberOfPointsInIndexed3DMatrixPositionsException(Elements.First().Count());
            }
            base.Add(position);
        }

        /// <summary>
        /// Represents matrix as string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            base.Elements.ForEach(p=> 
            {
                sb.Append(p.ToString());
                sb.Append(Environment.NewLine);
            });
            return sb.ToString();
        }

        #endregion

        #region Helpers

        private bool CheckMatrixType(IEnumerable<Position<T>> positions)
        {
            var positionType = positions.FirstOrDefault()?.Dimension;
            return positions.All(p => p.Dimension == positionType);
        }

        private bool CheckPositionType(Position<T> position)
        {
            var positionType = position.Dimension;
            return Elements.Count == 0 || Elements.First().Dimension == positionType;
        }

        private bool Check3DMatrixNumberPoint(IEnumerable<Position<T>> positions)
        {
            var pointNumber = positions.FirstOrDefault()?.Count();
            return positions.All(p => p.Count() == pointNumber);
        }

        private bool Check3DMatrixNumberPoint(Position<T> position)
        {
            var pointNumber = Elements.FirstOrDefault()?.Count();
            return Elements.Count == 0 || position.Count() == pointNumber;
        }

        #endregion


    }
}
