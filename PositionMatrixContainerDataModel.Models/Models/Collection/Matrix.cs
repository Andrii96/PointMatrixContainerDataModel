using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionMatrixContainerDataModel.Models.Exceptions;

namespace PositionMatrixContainerDataModel.Models.Models.Collection
{
    public class Matrix<T> : List<Position<T>> where T : struct
    {
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public Matrix() : base() {}

        /// <summary>
        /// Instantiates matrix with position collection
        /// </summary>
        /// <param name="positionCollection"> Positinons</param>
        public Matrix(IEnumerable<Position<T>> positionCollection)
        {
            var positions = positionCollection.ToList();
            if (!positions.Any())
            {
                throw new ArgumentException();
            }
            this.AddRange(positions);            
        }

        #endregion

        #region Methods
        /// <summary>
        /// Adds new position to matrix
        /// </summary>
        /// <param name="position">Position for adding</param>
        public new void Add(Position<T> position)
        {
            if (position == null)
            {
                throw new ArgumentNullException();
            }

            if (ValidateSingleValue(position))
            {
                base.Add(position);
            }            
        }

        /// <summary>
        /// Adds range of positions to matrix
        /// </summary>
        /// <param name="positionCollection">Position collection for adding</param>
        public new void AddRange(IEnumerable<Position<T>> positionCollection)
        {
            var positions = positionCollection.ToList();

            if (!CheckMatrixType(positions))
            {
                throw new DifferentDimensionTypeInMatrixException();
            }

            if (ValidateSequence(positions))
            {
                base.AddRange(positions);
            }
        }

        /// <summary>
        /// Inserts position to matrix at specified position
        /// </summary>
        /// <param name="index">Index</param>
        /// <param name="position">Position for inserting</param>
        public new void Insert(int index, Position<T> position)
        {
            if (position == null)
            {
                throw new ArgumentNullException();
            }
            if (ValidateSingleValue(position))
            {
                base.Insert(index, position);
            }           
        }

        /// <summary>
        /// Inserts range of positions at specified position
        /// </summary>
        /// <param name="index">Index</param>
        /// <param name="positionCollection">Position collection for inserting</param>
        public new void InsertRange(int index, IEnumerable<Position<T>> positionCollection)
        {
            var positions = positionCollection.ToList();

            if (!CheckMatrixType(positions))
            {
                throw new DifferentDimensionTypeInMatrixException();
            }

            if (ValidateSequence(positions))
            {
                base.InsertRange(index, positions);
            }           
        }

        /// <summary>
        /// String representation of Matrix
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            this.ForEach(p =>
            {
                sb.Append(p.ToString());
                sb.Append(Environment.NewLine);
            });
            return sb.ToString();
        }

        #endregion

        #region Helpers

        private bool CheckMatrixType(IEnumerable<Position<T>> positionCollection)
        {
            var positions = positionCollection.ToList();
            var positionType = positions.FirstOrDefault()?.PositionType;
            return positions.All(p => p.PositionType == positionType);
        }

        private bool CheckPositionType(Position<T> position)
        {
            var positionType = position.PositionType;
            return Count == 0 || this.First().PositionType == positionType;
        }

        private bool Check3DMatrixNumberPoint(IEnumerable<Position<T>> positionCollection)
        {
            var positions = positionCollection.ToList();
            var pointNumber = positions.FirstOrDefault()?.Count();
            return positions.All(p => p.Count() == pointNumber);
        }

        private bool Check3DMatrixNumberPoint(Position<T> position)
        {
            var pointNumber = this.FirstOrDefault()?.Count();
            return Count == 0 || position.Count() == pointNumber;
        }

        private bool ValidateSingleValue(Position<T> position)
        {
            if (!CheckPositionType(position))
            {
                throw new DifferentDimensionTypeInMatrixException(position.PositionType);
            }
            if (position.PositionType == PointDimension.Point3D && !Check3DMatrixNumberPoint(position))
            {
                throw new DifferentNumberOfPointsInIndexed3DMatrixPositionsException();
            }
            return true;
        }

        private bool ValidateSequence(IEnumerable<Position<T>> positionCollection)
        {
            var positions = positionCollection.ToList();

            if (!CheckMatrixType(positions))
            {
                throw new DifferentDimensionTypeInMatrixException();
            }
            if (!CheckPositionType(positions.First()))
            {
                throw new DifferentDimensionTypeInPositionException();
            }

            if (positions.First().PositionType == PointDimension.Point3D)
            {
                if (Count == 0 && !Check3DMatrixNumberPoint(positions))
                {
                    throw new DifferentNumberOfPointsInIndexed3DMatrixPositionsException();
                }else if (Count > 0 && !Check3DMatrixNumberPoint(positions.First()))
                {
                    throw new DifferentNumberOfPointsInIndexed3DMatrixPositionsException();
                }
            }
            return true;
        }

        #endregion
    }
}

