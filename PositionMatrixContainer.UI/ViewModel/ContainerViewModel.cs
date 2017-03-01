using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using PositionMatrixContainer.Models.Collection;

namespace PositionMatrixContainer.UI.ViewModel
{
    public class ContainerViewModel : ViewModelBase
    {
        #region Fields
        public object Container { get; private set; }
        public List<object> MatricesList { get; set; } 

        #endregion
        #region Properties
        public int AmountOfMatrices { get; private set; }
        public int AmountOfPositions { get; private set; }
        public Type Type { get; private set; }
        #endregion

        #region Constructor
        public ContainerViewModel(int matricesNumber, int positionsNumber, Type type)
        {
            AmountOfMatrices = matricesNumber;
            AmountOfPositions = positionsNumber;
            Type = type;
            AddNewContainerCommand = new RelayCommand(AddNewPointCommandExecute);
            SetMatricesList();
        }
        #endregion

        #region Properties
        private ObservableCollection<MatrixViewModel> _matrices = new ObservableCollection<MatrixViewModel>();

        public ObservableCollection<MatrixViewModel> Matrices
        {
            get { return _matrices; }
            set
            {
                _matrices = value;
                RaisePropertyChanged();
            }
        }


        private int _containerNumber;

        public int ContainerNumber
        {
            get { return _containerNumber; }
            set
            {
                _containerNumber = value;
                RaisePropertyChanged();
            }
        }

        private List<string> _positionsList = new List<string>();

        public List<string> PositionsTypesList
        {
            get { return _positionsList; }
            set
            {
                _positionsList = value;
                RaisePropertyChanged();
            }
        }
        #endregion



        #region Commands

        public RelayCommand AddNewContainerCommand { get; private set; }

        #endregion

        #region Helpers

        private void AddNewPointCommandExecute()
        {
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage("AddContainer"));

        }

        private void CreateContainer()
        {
            var container = typeof(Container<>);
            var containerType = container.MakeGenericType(Type);
            Container = Activator.CreateInstance(containerType);
        }

        private void SetMatricesList()
        {
            for (int i = 0; i < AmountOfPositions; i++)
            {
                PositionsTypesList.Add($"Position {i+1}");
            }

            for (int i = 0; i < AmountOfMatrices; i++)
            {
                var matrix = new MatrixViewModel(AmountOfPositions,Type)
                {
                    Number = i + 1,
                    Positions = PositionsTypesList,
                    IsPoint1DTypeEnabled = true,
                    IsPoint2DTypeEnabled = true,
                    IsPoint3DTypeEnabled = true
                };

                Matrices.Add(matrix);
            }
           
        }

        private void CreateMatrix()
        {
            for (int i = 0; i < AmountOfMatrices; i++)
            {
                var type = typeof(Matrix<>);
                var matrixType = type.MakeGenericType(Type);
                MatricesList.Add(Activator.CreateInstance(matrixType));
            }        
                   
        }
      
        #endregion

    }
}
