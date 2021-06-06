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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {      
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new AutorizationPage());
            Manager.MainFrame = MainFrame;
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (Manager.MainFrame.CanGoBack)
            {
                btnRegis.Visibility = Visibility.Visible;
                btnVhod.Visibility = Visibility.Visible;
                btnBack.Visibility = Visibility.Visible;
                btnInfo.Visibility = Visibility.Visible;
            }
            else
            {
                btnRegis.Visibility = Visibility.Hidden;
                btnVhod.Visibility = Visibility.Hidden;
                btnBack.Visibility = Visibility.Hidden;
                btnInfo.Visibility = Visibility.Hidden;
            }
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRegis_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new UserAppPage(null));
        }

        private void btnVhod_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new HistoriPage());
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new UserPage());
        }
    }
}
