using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMatrixContainerDataModel.Models.Models.Collection
{
    public class Container<T>:BaseCollection<Matrix<T>>
    {
        #region Constructor

        public Container() : base() { }

        public Container(IEnumerable<Matrix<T>> matrixes)
        {
            if (!CheckContainer(matrixes))
            {
                //Exception
            }
            base.Fill(matrixes);
        }

        #endregion

        #region Methods

        public override void Add(Matrix<T> matrix)
        {
            if (!CheckContainer(matrix))
            {
                //Exception
            }
            base.Add(matrix);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            int index = 0;
            Elements.ForEach(m =>
            {
                index++;
                sb.AppendFormat($"Matrix{index}:{Environment.NewLine} {m.ToString()}");
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
            return matrix.Count() == matrixSize;
        }

        #endregion

    }
}
