using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using PositionMatrixContainer.Models.Collection;

namespace PositionMatrixContainer.UI.ViewModel
{
    public class ContainersViewModel : ViewModelBase
    {
        public object Containers { get; private set; }
        public Type Type { get; private set; }
       
        public ContainersViewModel()
        {
            AvailableDataTypes = GetAllowedTypes();
            AddContainerCommand = new RelayCommand(AddContainerCommandExecute, CanAddCommandExecute);
            IsSelectionEnabled = true;
        }

        private int _amountOfMatricesInContainerValue;

        public int AmountOfMatricesInContainerValue
        {
            get { return _amountOfMatricesInContainerValue; }
        }
        private int _amountOfPositionsValue;

        public int AmountOfPositionsValue
        {
            get { return _amountOfPositionsValue; }
        }


        private int _amountOfContainers;

        public int AmountOfContainers
        {
            get { return _amountOfContainers; }
            set
            {
                _amountOfContainers = value;
                RaisePropertyChanged();
            }
        }

        private string _amountOfMatricesInContainer;

        public string AmountOfMatricesInContainer
        {
            get { return _amountOfMatricesInContainer; }
            set
            {
                _amountOfMatricesInContainer = value;
                RaisePropertyChanged();
                AddContainerCommand.RaiseCanExecuteChanged();
            }
        }

        private List<string> _availableDataTypes;

        public List<string> AvailableDataTypes
        {
            get { return _availableDataTypes; }
            set
            {
                _availableDataTypes = value;
                RaisePropertyChanged();
            }
        }

        private string _amountOfPositions;

        public string AmountOfPositions
        {
            get { return _amountOfPositions; }
            set
            {
                _amountOfPositions = value;
                RaisePropertyChanged();
                AddContainerCommand.RaiseCanExecuteChanged();
            }
        }

        private string _selectedType;

        public string SelectedType
        {
            get { return _selectedType; }
            set
            {
                _selectedType = value;
                RaisePropertyChanged();
                AddContainerCommand.RaiseCanExecuteChanged();
                IsSelectionEnabled = false;
                CreateContainer();
            }
        }

        private bool _isSelectionEnabled;

        public bool IsSelectionEnabled
        {
            get { return _isSelectionEnabled;}
            set
            {
                _isSelectionEnabled = value;
                RaisePropertyChanged();
            }
        }

        #region Commands
        public RelayCommand AddContainerCommand { get; private set; }
        #endregion

        #region Helpers


        private void AddContainerCommandExecute()
        {
            if (!Validate())
            {
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage("ValidationError"));
            }
            else
            {
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage("NewContainer"));
            }
           
        }

        private bool CanAddCommandExecute()
        {
            return !string.IsNullOrEmpty(SelectedType) && !string.IsNullOrEmpty(AmountOfMatricesInContainer) &&
                   !string.IsNullOrEmpty(AmountOfPositions);
        }

        private List<string> GetAllowedTypes()
        {
            var list = new List<string>();
            list.Add(TypeCode.Byte.ToString());
            list.Add(TypeCode.Decimal.ToString());
            list.Add(TypeCode.Double.ToString());
            list.Add(TypeCode.Int16.ToString());
            list.Add(TypeCode.Int32.ToString());
            list.Add(TypeCode.Int64.ToString());
            list.Add(TypeCode.SByte.ToString());
            list.Add(TypeCode.Single.ToString());
            list.Add(TypeCode.UInt16.ToString());
            list.Add(TypeCode.UInt32.ToString());
            list.Add(TypeCode.UInt64.ToString());
            return list;

        }

        private bool Validate()
        {
            return int.TryParse(AmountOfMatricesInContainer, out _amountOfMatricesInContainerValue) && int.TryParse(AmountOfPositions,out _amountOfPositionsValue);
        }

        private void CreateContainer()
        {
            var containers = typeof (Containers<>);
            Type = Type.GetType($"System.{SelectedType}");
            var containersType = containers.MakeGenericType(Type);
            Containers = Activator.CreateInstance(containersType);
           
        }

        #endregion

    }
}
