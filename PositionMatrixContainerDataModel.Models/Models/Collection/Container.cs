using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PositionMatrixContainerDataModel.Models.Exceptions;

namespace PositionMatrixContainerDataModel.Models.Models.Collection
{
    public class Container<T> : List<Matrix<T>> where T : struct
    {
        #region Constructor

        public Container() : base() { }

        public Container(IEnumerable<Matrix<T>> matrices)
        {
            this.AddRange(matrices);
        }

        #endregion

        #region Methods

        public new void Add(Matrix<T> matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException();
            }
            if (ValidateSingleValue(matrix))
            {
                base.Add(matrix);
            }           
        }

        public new void AddRange(IEnumerable<Matrix<T>> matrices)
        {
            if (matrices == null)
            {
                throw new ArgumentNullException();
            }

            if (ValidateSecuence(matrices))
            {
                base.AddRange(matrices);
            }
            else
            {
                throw new DifferentMatrixSizeException();
            }
           
        }

        public new void Insert(int index, Matrix<T> matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException();
            }
            if (ValidateSingleValue(matrix))
            {
                base.Insert(index,matrix);
            }
        }

        public new void InsertRange(int index, IEnumerable<Matrix<T>> matrices)
        {
            if (!CheckContainer(matrices))
            {
                throw new DifferentMatrixSizeException();
            }

            if (ValidateSecuence(matrices))
            {
                base.InsertRange(index,matrices);
            }
            else
            {
                throw new DifferentMatrixSizeException();
            }
        }

        public new Matrix<T> this[int index] => this[index];

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            int index = 0;
            this.ForEach(m =>
            {
                index++;
                sb.Append($"Matrix{index}:{Environment.NewLine} {m.ToString()}");
            });
            return sb.ToString();
        }

        #endregion

        #region Helpers

        private bool CheckContainer(IEnumerable<Matrix<T>> matrixes)
        {
            var matrixSize = matrixes.FirstOrDefault()?.Count();
            return matrixes.All(m => m.Count() == matrixSize);
        }

        private bool CheckContainer(Matrix<T> matrix)
        {
            var matrixSize = this.FirstOrDefault()?.Count();
            return Count == 0 || matrix.Count() == matrixSize;
        }

        private bool ValidateSingleValue(Matrix<T> matrix)
        {
            if (!CheckContainer(matrix))
            {
                throw new DifferentMatrixSizeException();
            }
            return true;
        }

        private bool ValidateSecuence(IEnumerable<Matrix<T>> matrices)
        {
            if (!CheckContainer(matrices))
            {
                throw new DifferentMatrixSizeException();
            }

            return Count == 0 || this.First().Count() == matrices.First().Count();

        }

        #endregion
    }
}
