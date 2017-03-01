using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using PositionMatrixContainer.UI.Helpers;
using PositionMatrixContainer.UI.ViewModel;

namespace PositionMatrixContainer.UI.View
{
    /// <summary>
    /// Interaction logic for PMCDataModelCreationWindow.xaml
    /// </summary>
    public partial class ContainersView : Window
    {
        private int _row = 0;
        private int _column = 0;
        private int _amount = 0;

        public ContainersView()
        {
            InitializeComponent();
            DataContext = new ContainersViewModel();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        public void NotificationMessageReceived(NotificationMessage message)
        {
            switch (message.Notification)
            {
                case "NewContainer":
                    AddContainer();
                    break;
                case "ValidationError":
                    MessageBox.Show("Please, enter correct values in text fields.", "Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    break;
            }
        }

        private ContainersViewModel ViewModel
        {
            get { return this.DataContext as ContainersViewModel; }
        }

        public void AddContainer()
        {                    
            new ContainerView(ViewModel.AmountOfMatricesInContainerValue, ViewModel.AmountOfPositionsValue,ViewModel.Type).Show();
        }
    }
}
