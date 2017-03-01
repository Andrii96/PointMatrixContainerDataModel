using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace PositionMatrixContainer.UI.Model
{
    public class PointViewModel:ViewModelBase
    {
        #region Fields

        private Type _type;

        #endregion

        #region Constructor

        public PointViewModel(Type type)
        {
            _type = type;
            AddNewPointCommand = new RelayCommand(AddNewPointCommandExecute);
        }
        #endregion

        #region Commands
        public RelayCommand AddNewPointCommand { get; private set; }
        #endregion

        #region Properties

        private string _x;

        public string X
        {
            get { return _x; }
            set
            {
                _x = value;
                RaisePropertyChanged();
            }
        }

        private string _y;

        public string Y
        {
            get { return _y; }
            set
            {
                _y = value;
                RaisePropertyChanged();
            }
        }

        private string _z;

        public string Z
        {
            get { return _z; }
            set
            {
                _z = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Helpers

        private void AddNewPointCommandExecute()
        {
            
        }
        #endregion

    }
}
