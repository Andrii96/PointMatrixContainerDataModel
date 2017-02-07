using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionMatrixContainerDataModel.Models.Exceptions;

namespace PositionMatrixContainerDataModel.Models.Models.Collection
{
    public class Container<T>:BaseCollection<Matrix<T>>
    {
        #region Constructor
        /// <summary>
        /// Default constructor.Initializes container instance.
        /// </summary>
        public Container() : base() { }

        /// <summary>
        /// Initializes container instance with matrix sequence.
        /// 
        /// Exceptions:
        /// DifferentMatrixSizeException
        /// </summary>
        /// <param name="matrices">Sequence of matrices</param>
        public Container(IEnumerable<Matrix<T>> matrices)
        {
            if (!CheckContainer(matrices))
            {
               throw new DifferentMatrixSizeException(matrices.First().Count());
            }
            base.Fill(matrices);
        }

        #endregion

        #region Properties

        public IEnumerable<Matrix<T>> Matrixes => Elements;

        #endregion

        #region Methods
        /// <summary>
        /// Adds new matrix to container
        /// 
        /// Exceptions:
        /// DifferentMatrixSizeException
        /// </summary>
        /// <param name="matrix">matrix for adding to container</param>
        public override void Add(Matrix<T> matrix)
        {
            if (!CheckContainer(matrix))
            {
                throw new DifferentMatrixSizeException(Elements.First().Count());
            }
            base.Add(matrix);
        }

        /// <summary>
        /// Represents container  as string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            int index = 0;
            Elements.ForEach(m =>
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
            var matrixSize = base.Elements.FirstOrDefault()?.Count();
            return base.Elements.Count==0 || matrix.Count() == matrixSize;
        }

        #endregion

    }
}
