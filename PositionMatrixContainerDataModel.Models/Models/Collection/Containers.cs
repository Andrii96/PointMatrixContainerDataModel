
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PositionMatrixContainerDataModel.Models.Exceptions;
using System;

namespace PositionMatrixContainerDataModel.Models.Models.Collection
{
    public class Containers<T>:BaseCollection<Container<T>>
    {
        #region Constructor

        /// <summary>
        /// Default constructor. Initializes containers collection
        /// </summary>
        public Containers():base() {}

        /// <summary>
        /// Initializes containers collection with container sequence.
        /// 
        /// Exceptions:
        /// DifferentMatrixSizeException,
        /// DifferentContainersSizeException,
        /// DifferentIndexedMatrixType,
        /// DifferentNumberOfPointsIn3DMatrixPositions
        /// </summary>
        /// <param name="containers">Containers sequence</param>
        public Containers(IEnumerable<Container<T>> containers)
        {
            if (CheckContainersContainerMatrixSize(containers) && CheckContainers(containers) &&
                CheckTypeOfEachIndexedMatrix(containers) && CheckNumberOfDataPointsIn3DMatrix(containers))
            {
                Fill(containers);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds new container to containers collection
        /// 
        /// Exceptions:
        /// DifferentMatrixSizeException,
        /// DifferentContainersSizeException,
        /// DifferentIndexedMatrixType,
        /// DifferentNumberOfPointsIn3DMatrixPositions
        /// </summary>
        /// <param name="container">Container for adding</param>
        public override void Add(Container<T> container)
        {
            if (Elements.Count > 0)
            {
                if (CheckContainersContainerMatrixSize(container) && CheckContainers(container) &&
                    CheckTypeOfIndexedMatrix(container, Elements.Last()) &&
                    CheckNumberOfDataPointsIn3DMatrix(container, Elements.Last()))
                {
                    base.Add(container);
                    return;
                }
            }
            else
            {
                base.Add(container);
            }
            
        }

        /// <summary>
        /// Represents containers collection as string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(" ");
            int index = 0;
            Elements.ForEach(c =>
            {
                sb.Append($"Container {++index}: {c.ToString()} {Environment.NewLine}");
            });
            return sb.ToString();
        }

        #endregion

        #region Helpers

        private bool CheckContainersContainerMatrixSize(IEnumerable<Container<T>> containers)
        {
            var positionNumberInMatrix = containers.FirstOrDefault()?
                                                 .Matrixes
                                                 .First()
                                                 .Count();
            if (positionNumberInMatrix != null)
            {
                foreach (var container in containers)
                {
                    if (container.Matrixes.Any(matrix => matrix.Count() != positionNumberInMatrix))
                    {
                        throw new DifferentMatrixSizeException((int)positionNumberInMatrix);
                    }
                }
            }
            
            return true;
        }

        private bool CheckContainersContainerMatrixSize(Container<T> container)
        {
            var positionNumberInMatrix = base.Elements.FirstOrDefault()?
                                                      .Matrixes
                                                      .First()
                                                      .Count();
            if (positionNumberInMatrix != null)
            {
                if (container.Matrixes
                            .FirstOrDefault()?
                            .Count() != positionNumberInMatrix)
                {
                    throw new DifferentMatrixSizeException((int)positionNumberInMatrix);
                }
            }
           
            return true;
        }

        private bool CheckContainers(IEnumerable<Container<T>> containers)
        {
            var matrixNumber = containers.FirstOrDefault()?
                                         .Matrixes
                                         .Count();
            if (matrixNumber != null)
            {
                if (!containers.All(c => c.Matrixes.Count() == matrixNumber))
                {
                    throw new DifferentContainersSizeException((int)matrixNumber);
                }
            }

            return true;
        }

        private bool CheckContainers(Container<T> container)
        {
            var matrixNumber = base.Elements.FirstOrDefault()?
                                            .Matrixes
                                            .Count();
            if (matrixNumber != null)
            {
                if (container.Matrixes.Count() != matrixNumber)
                {
                    throw new DifferentContainersSizeException((int)matrixNumber);
                }
            }

            return true;

        }

        private bool CheckTypeOfIndexedMatrix(Container<T> firstContainer, Container<T> secondContainer)
        {
            for (int i = 0; i < firstContainer.Matrixes.Count(); i++)
            {
                var type1 = firstContainer.Matrixes.ElementAt(i).First().Dimension;
                var type2 = secondContainer.Matrixes.ElementAt(i).First().Dimension;
                if ( type1!=type2)
                {
                    throw new DifferentIndexedMatrixType(type1,type2);
                }
            }
            return true;
        }

        private bool CheckTypeOfEachIndexedMatrix(IEnumerable<Container<T>> containers )
        {
            return containers.All(c => CheckTypeOfIndexedMatrix(c, containers.First()));
        }

        private bool CheckNumberOfDataPointsIn3DMatrix(IEnumerable<Container<T>> containers)
        {
            return containers.All(c => CheckNumberOfDataPointsIn3DMatrix(c, containers.First()));
        }

        private bool CheckNumberOfDataPointsIn3DMatrix(Container<T> firstContainer, Container<T> secondContainer)
        {
            for (int i = 0; i < firstContainer.Matrixes.Count(); i++)
            {
                var matrix1 = firstContainer.Matrixes.ElementAt(i);
                if (matrix1.First().Dimension == PointDimension.Point3D)
                {
                    if (GetAmountOfPointsFor3DMatrix(matrix1) !=
                        GetAmountOfPointsFor3DMatrix(secondContainer.Matrixes.ElementAt(i)))
                    {
                        throw new DifferentNumberOfPointsIn3DMatrixPositions(GetAmountOfPointsFor3DMatrix(matrix1));
                    }
                }
            }

            return true;
        }

        private int GetAmountOfPointsFor3DMatrix(Matrix<T> matrix)
        {
            return matrix.First().Count();
        }

        #endregion
    }
}
