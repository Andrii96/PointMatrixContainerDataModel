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
    /// Interaction logic for MatrixEnteringView.xaml
    /// </summary>
    public partial class ContainerView : Window
    {
        private int _matricesNumber;
        private const int ColumnsNumber = 5;
        private int _count = 1;
        public ContainerView(int amountOfMatrices, int amountOfPositions,Type type)
        {
            InitializeComponent();
            DataContext = new ContainerViewModel(amountOfMatrices,amountOfPositions,type);
            _matricesNumber = amountOfMatrices;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
           // View.ItemsSource = ViewModel.Matrices;
            //SetMatrices();
        }

        private void NotificationMessageReceived(NotificationMessage obj)
        {
            switch (obj.Notification)
            {
                case "AddContainer":
                    this.Close();
                    break;
            }
        }

        private ContainerViewModel ViewModel
        {
            get { return DataContext as ContainerViewModel; }
        }

       
    }
}
