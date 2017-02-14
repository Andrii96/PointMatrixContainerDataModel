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
        /// <summary>
        /// Default constructor
        /// </summary>
        public Container() : base() { }

        /// <summary>
        /// Instantiates container with matrix collection
        /// </summary>
        /// <param name="matrixCollection">Matrix collection</param>
        public Container(IEnumerable<Matrix<T>> matrixCollection)
        {
            var matrices = matrixCollection.ToList();

            if (!matrices.Any())
            {
                throw new ArgumentException();
            }
            this.AddRange(matrices);
        }

        #endregion

        #region Methods
        /// <summary>
        /// Adds new matrix to container
        /// </summary>
        /// <param name="matrix">Matrix for adding</param>
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

        /// <summary>
        /// Adds range of matrices to container
        /// </summary>
        /// <param name="matrixCollection">matrix collection</param>
        public new void AddRange(IEnumerable<Matrix<T>> matrixCollection)
        {
            var matrices = matrixCollection.ToList();

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

        /// <summary>
        /// Inserts matrix to container at specified position
        /// </summary>
        /// <param name="index">Position number</param>
        /// <param name="matrix">Matrix for inserting</param>
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

        /// <summary>
        /// Inserts range of matrices to container at specified position
        /// </summary>
        /// <param name="index">Index</param>
        /// <param name="matrixCollection">Matrix collection</param>
        public new void InsertRange(int index, IEnumerable<Matrix<T>> matrixCollection)
        {
            var matrices = matrixCollection.ToList();

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

        /// <summary>
        /// String representation of container
        /// </summary>
        /// <returns></returns>
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

        private bool CheckContainer(IEnumerable<Matrix<T>> matrixCollection)
        {
            var matrices = matrixCollection.ToList();
            var matrixSize = matrices.FirstOrDefault()?.Count();
            return matrices.All(m => m.Count() == matrixSize);
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

        private bool ValidateSecuence(IEnumerable<Matrix<T>> matrixCollection)
        {
            var matrices = matrixCollection.ToList();

            if (!CheckContainer(matrices))
            {
                throw new DifferentMatrixSizeException();
            }

            return Count == 0 || this.First().Count() == matrices.First().Count();

        }

        #endregion
    }
}
