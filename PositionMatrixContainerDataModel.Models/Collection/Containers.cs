
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PositionMatrixContainer.Models.Exceptions;
using System;
using PositionMatrixContainer.Models.Point;

namespace PositionMatrixContainer.Models.Collection
{
    public class Containers<T> : List<Container<T>> where T : struct
    {
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public Containers() : base() { }

        /// <summary>
        /// Instantiates Containers with containers collection
        /// </summary>
        /// <param name="containerCollection">Containers collection</param>
        public Containers(IEnumerable<Container<T>> containerCollection)
        {
            var containers = containerCollection.ToList();

            if (!containers.Any())
            {
                throw new ArgumentException();
            }
            this.AddRange(containers);
        }

        #endregion

        #region Methods
        /// <summary>
        /// Adds new container to containers
        /// </summary>
        /// <param name="container">Container for adding</param>
        public new void Add(Container<T> container)
        {
            if (container == null)
            {
                throw new ArgumentNullException();
            }

            if (ValidateSingleValue(container))
            {
                base.Add(container);
            }
        }

        /// <summary>
        /// Adds range of containers to Containers collection
        /// </summary>
        /// <param name="containerCollection">Containers collection for adding</param>
        public new void AddRange(IEnumerable<Container<T>> containerCollection)
        {
            var containers = containerCollection.ToList();
            if (ValidateSequence(containers))
            {
                base.AddRange(containers);
            }                      
        }

        /// <summary>
        /// Inserts new container to Containers at specified position
        /// </summary>
        /// <param name="index">Index</param>
        /// <param name="container">Container for inserting</param>
        public new void Insert(int index, Container<T> container)
        {
            if (container == null)
            {
                throw new ArgumentNullException();
            }

            if (ValidateSingleValue(container))
            {
                base.Insert(index,container);
            }
                    
        }

        /// <summary>
        /// Inserts range of containers to Containers collection
        /// </summary>
        /// <param name="index">Index</param>
        /// <param name="containerCollection">Collection of containers for inserting</param>
        public new void InsertRange(int index, IEnumerable<Container<T>> containerCollection)
        {
            var containers = containerCollection.ToList();

            if (ValidateSequence(containers))
            {
                base.InsertRange(index,containers);
            }
        }

        /// <summary>
        /// String representation of containers
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(" ");
            int index = 0;
            this.ForEach(c =>
            {
                sb.Append($"Container {++index}: {c.ToString()} {Environment.NewLine}");
            });
            return sb.ToString();
        }

        #endregion

        #region Helpers

        private bool CheckContainersContainerMatrixSize(IEnumerable<Container<T>> containerCollection)
        {
            var containers = containerCollection.ToList();

            var positionNumberInMatrix = containers.FirstOrDefault()?
                                                 .First()
                                                 .Count();
            if (positionNumberInMatrix != null)
            {
                foreach (var container in containers)
                {
                    if (container.Any(matrix => matrix.Count() != positionNumberInMatrix))
                    {
                        throw new DifferentMatrixSizeException((int)positionNumberInMatrix);
                    }
                }
            }

            return true;
        }

        private bool CheckContainersContainerMatrixSize(Container<T> container)
        {
            var positionNumberInMatrix = this.FirstOrDefault()?
                                                      .First()
                                                      .Count();
            if (positionNumberInMatrix != null)
            {
                if (container.FirstOrDefault()?
                            .Count() != positionNumberInMatrix)
                {
                    throw new DifferentMatrixSizeException((int)positionNumberInMatrix);
                }
            }

            return true;
        }

        private bool CheckContainers(IEnumerable<Container<T>> containerCollection)
        {
            var containers = containerCollection.ToList();

            var matrixNumber = containers.FirstOrDefault()?.Count();
            if (matrixNumber != null)
            {
                if (containers.Any(c => c.Count() != matrixNumber))
                {
                    throw new DifferentContainersSizeException((int) matrixNumber);
                }

                return true;
            }
            return true;
        }

        private bool CheckContainers(Container<T> container)
        {
            var matrixNumber = this.FirstOrDefault()?.Count();
            if (matrixNumber != null)
            {
                if (container.Count() != matrixNumber)
                {
                    throw new DifferentContainersSizeException((int)matrixNumber);
                }
            }

            return true;
        }

        private bool CheckTypeOfIndexedMatrix(Container<T> firstContainer, Container<T> secondContainer)
        {
            for (int i = 0; i < firstContainer.Count(); i++)
            {
                var type1 = firstContainer[i].First().PositionType;
                var type2 = secondContainer[i].First().PositionType;
                if (type1 != type2)
                {
                    throw new DifferentIndexedMatrixTypeException(type1, type2);
                }
            }
            return true;
        }

        private bool CheckTypeOfEachIndexedMatrix(IEnumerable<Container<T>> containerCollection)
        {
            var containers = containerCollection.ToList();
            return containers.All(c => CheckTypeOfIndexedMatrix(c, containers.First()));
        }

        private bool CheckNumberOfDataPointsIn3DMatrix(IEnumerable<Container<T>> containerCollection)
        {
            var containers = containerCollection.ToList();
            return containers.All(c => CheckNumberOfDataPointsIn3DMatrix(c, containers.First()));
        }

        private bool CheckNumberOfDataPointsIn3DMatrix(Container<T> firstContainer, Container<T> secondContainer)
        {
            for (int i = 0; i < firstContainer.Count(); i++)
            {
                var matrix1 = firstContainer.ElementAt(i);
                if (matrix1.First().PositionType == PointDimension.Point3D)
                {
                    if (GetAmountOfPointsFor3DMatrix(matrix1) !=
                        GetAmountOfPointsFor3DMatrix(secondContainer[i]))
                    {
                        throw new DifferentNumberOfPointsInIndexed3DMatrixPositionsException(GetAmountOfPointsFor3DMatrix(matrix1));
                    }
                }
            }

            return true;
        }

        private int GetAmountOfPointsFor3DMatrix(Matrix<T> matrix)
        {
            return matrix.First().Count();
        }

        private bool ValidateSingleValue(Container<T> container)
        {
            return Count == 0 || (CheckContainersContainerMatrixSize(container) && CheckContainers(container) &&
                                  CheckTypeOfIndexedMatrix(container, this.Last()) &&
                                  CheckNumberOfDataPointsIn3DMatrix(container, this.Last()));
        }

        private bool ValidateSequence(IEnumerable<Container<T>> containers)
        {
            var containersCollection = containers.ToList();

            if (CheckContainersContainerMatrixSize(containersCollection) && CheckContainers(containersCollection) &&
                CheckTypeOfEachIndexedMatrix(containersCollection) &&
                CheckNumberOfDataPointsIn3DMatrix(containersCollection))
            {

                return Count == 0 || (CheckContainersContainerMatrixSize(containersCollection.First()) &&
                                      CheckContainers(containersCollection.First()) &&
                                      CheckTypeOfIndexedMatrix(this.First(), containersCollection.First()) &&
                                      CheckNumberOfDataPointsIn3DMatrix(this.First(), containersCollection.First()));
            }
            return false;
        }

        #endregion
    }
}
