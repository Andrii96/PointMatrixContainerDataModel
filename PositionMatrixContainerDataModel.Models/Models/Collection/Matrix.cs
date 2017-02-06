using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMatrixContainerDataModel.Models.Models.Collection
{
    public class Matrix<T>:BaseCollection<Position<T>>
    {
        #region Constructor

        public Matrix() : base(){ }

        //TODO Check types and throw exception when types are incorrect
        public Matrix(IEnumerable<Position<T>> positions)
        {
            if (!CheckMatrixType(positions))
            {
                //Exception
            }

            if (positions.First().Dimension == PointDimension.Point3D && !Check3DMatrixNumberPoint(positions))
            {
                //Exception
            }

             base.Fill(positions);
        }
        #endregion

        #region Methods
        //TODO Throw exception
        public override void Add(Position<T> position)
        {         
            if (!CheckPositionType(position))
            {
                //Exception
                return;
            }
            if (position.Dimension == PointDimension.Point3D && !Check3DMatrixNumberPoint(position))
            {
                //Exception
            }
            base.Add(position);
        }

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
            return Elements.First().Dimension == positionType;
        }

        private bool Check3DMatrixNumberPoint(IEnumerable<Position<T>> positions)
        {
            var pointNumber = positions.FirstOrDefault()?.Count();
            return positions.All(p => p.Count() == pointNumber);
        }

        private bool Check3DMatrixNumberPoint(Position<T> position)
        {
            var pointNumber = Elements.FirstOrDefault()?.Count();
            return position.Count() == pointNumber;
        }

        #endregion


    }
}
