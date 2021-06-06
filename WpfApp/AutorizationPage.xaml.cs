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
using WpfApp.BD;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public AutorizationPage()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {

           

            if (LoginBox.Text.Length == 0 || PasswordBox.Password.Length == 0)
            {
                Data.Authorization.Length(LoginBox, PasswordBox);
            }
            else
            {
                Data.Authorization.Vhod(LoginBox, PasswordBox, new AdminPage(), new StudentPage());
            }
        }
    }
}
                          


