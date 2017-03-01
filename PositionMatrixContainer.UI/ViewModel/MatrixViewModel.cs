using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PositionMatrixContainer.Models.Collection;
using PositionMatrixContainer.UI.View;

namespace PositionMatrixContainer.UI.ViewModel
{
    public partial class MatrixViewModel:ViewModelBase
    {
        #region Fields
        public List<object> PositionsList { get; private set; }
        private int _positionsNumber;
        private Type _type;
        #endregion

        #region Constructor

        public MatrixViewModel(int positionsNumber, Type type)
        {
            _positionsNumber = positionsNumber;
            _type = type;
            AddNewPointCommand = new RelayCommand(AddNewPointCommandExecute);
        }

        #endregion

        #region Commands
        public RelayCommand AddNewPointCommand { get; private set; }
        #endregion


        #region Properties

        private bool _point1D;

        public bool Point1D
        {
            get { return _point1D; }
            set
            {
                _point1D = value;
                RaisePropertyChanged();
                IsPoint2DTypeEnabled = false;
                IsPoint3DTypeEnabled = false;
            }
        }

        private bool _point2D;

        public bool Point2D
        {
            get { return _point2D; }
            set
            {
                _point2D = value;
                RaisePropertyChanged();
                IsPoint1DTypeEnabled = false;
                IsPoint3DTypeEnabled = false;
            }
        }

        private bool _point3D;

        public bool Point3D
        {
            get { return _point3D; }
            set
            {
                _point3D = value;
                RaisePropertyChanged();
                IsPoint1DTypeEnabled = false;
                IsPoint3DTypeEnabled = false;
            }
        }

        private int _number;

        public int Number
        {
            get { return _number; }
            set
            {
                _number = value;
                RaisePropertyChanged();
            }
        }

        private List<string> _positions;

        public List<string> Positions
        {
            get { return _positions; }
            set
            {
                _positions = value;
                RaisePropertyChanged();
            }
        }

        private bool _isPoint1DTypeEnabled;

        public bool IsPoint1DTypeEnabled
        {
            get
            {
                return _isPoint1DTypeEnabled;
            }
            set
            {
                _isPoint1DTypeEnabled = value;
                RaisePropertyChanged();
            }
        }

        private bool _isPoint2DTypeEnabled;

        public bool IsPoint2DTypeEnabled
        {
            get
            {
                return _isPoint2DTypeEnabled;
            }
            set
            {
                _isPoint2DTypeEnabled = value;
                RaisePropertyChanged();
            }
        }

        private bool _isPoint3DTypeEnabled;

        public bool IsPoint3DTypeEnabled
        {
            get
            {
                return _isPoint3DTypeEnabled;
            }
            set
            {
                _isPoint3DTypeEnabled = value;
                RaisePropertyChanged();
            }
        }

        private int _selectedIndex;

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Helpers 

        private void AddNewPointCommandExecute()
        {
            new PointView().Show();
        }

        private void CreatePositionsList()
        {
            for (int i = 0; i < _positionsNumber; i++)
            {
                var type = typeof(Position<>);
                var positionType = type.MakeGenericType(_type);
                PositionsList.Add(Activator.CreateInstance(positionType));
            }
        }

        #endregion


    }
}
