
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PositionMatrixContainerDataModel.Models.Exceptions;
using System;

namespace PositionMatrixContainerDataModel.Models.Models.Collection
{
    public class Containers<T> : List<Container<T>> where T : struct
    {
        #region Constructor

        public Containers() : base() { }

        public Containers(IEnumerable<Container<T>> containers)
        {
            if (containers == null)
            {
                throw new ArgumentNullException();
            }
            this.AddRange(containers);
        }

        #endregion

        #region Methods

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

        public new void AddRange(IEnumerable<Container<T>> containersCollection)
        {
            if (ValidateSequence(containersCollection))
            {
                base.AddRange(containersCollection);
            }
                      
        }

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

        public new void InsertRange(int index, IEnumerable<Container<T>> containersCollection)
        {
            if (ValidateSequence(containersCollection))
            {
                base.InsertRange(index,containersCollection);
            }
        }

        public new Container<T> this[int index] => this[index];

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

        private bool CheckContainersContainerMatrixSize(IEnumerable<Container<T>> containers)
        {
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

        private bool CheckContainers(IEnumerable<Container<T>> containers)
        {
            var matrixNumber = containers.FirstOrDefault()?.Count();
            if (matrixNumber != null)
            {
                if (!containers.All(c => c.Count() == matrixNumber))
                {
                    throw new DifferentContainersSizeException((int)matrixNumber);
                }
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

        private bool CheckTypeOfEachIndexedMatrix(IEnumerable<Container<T>> containers)
        {
            return containers.All(c => CheckTypeOfIndexedMatrix(c, containers.First()));
        }

        private bool CheckNumberOfDataPointsIn3DMatrix(IEnumerable<Container<T>> containers)
        {
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
