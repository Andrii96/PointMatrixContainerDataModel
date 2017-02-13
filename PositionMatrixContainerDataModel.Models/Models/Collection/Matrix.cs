using System;
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

        public Matrix() : base() {}

        public Matrix(IEnumerable<Position<T>> positions)
        {
            this.AddRange(positions);            
        }

        #endregion

        #region Methods

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

        public new void AddRange(IEnumerable<Position<T>> positions)
        {
            if (!CheckMatrixType(positions))
            {
                throw new DifferentDimensionTypeInMatrixException();
            }

            if (ValidateSequence(positions))
            {
                base.AddRange(positions);
            }
        }

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

        public new void InsertRange(int index, IEnumerable<Position<T>> positions)
        {
            if (!CheckMatrixType(positions))
            {
                throw new DifferentDimensionTypeInMatrixException();
            }

            if (ValidateSequence(positions))
            {
                base.InsertRange(index, positions);
            }           
        }

        public new Position<T> this[int index] => this[index]; 

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

        private bool CheckMatrixType(IEnumerable<Position<T>> positions)
        {
            var positionType = positions.FirstOrDefault()?.PositionType;
            return positions.All(p => p.PositionType == positionType);
        }

        private bool CheckPositionType(Position<T> position)
        {
            var positionType = position.PositionType;
            return Count == 0 || this.First().PositionType == positionType;
        }

        private bool Check3DMatrixNumberPoint(IEnumerable<Position<T>> positions)
        {
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

        private bool ValidateSequence(IEnumerable<Position<T>> positions)
        {
            if (!CheckMatrixType(positions))
            {
                throw new DifferentDimensionTypeInMatrixException();
            }
            if (!CheckPositionType(positions.First()))
            {
                throw new DifferentDimensionTypeInPositionException();
            }

            if (positions.First().PositionType == PointDimension.Point3D && !Check3DMatrixNumberPoint(positions.First()))
            {
                throw new DifferentNumberOfPointsInIndexed3DMatrixPositionsException();
            }

            return true;
        }

        #endregion
    }
}

