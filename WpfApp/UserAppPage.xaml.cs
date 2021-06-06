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
    /// Логика взаимодействия для UserAppPage.xaml
    /// </summary>
    public partial class UserAppPage : Page
    {
        private Users _currentUser = new Users();
        public UserAppPage(Users Users)
        {
            InitializeComponent();
            DataContext = _currentUser;
            Role.ItemsSource = ScheduleEntities.GetContext().Role.ToList();
            if (Users != null)
                _currentUser = Users;
        }

        private void Login_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void btnZareg_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (PovPassword.Text == PovPassword.Text)
            {
                if (string.IsNullOrWhiteSpace(_currentUser.Login))
                {
                    errors.AppendLine("Укажите логин");
                }
                if (string.IsNullOrWhiteSpace(_currentUser.Password))
                {
                    errors.AppendLine("Укажите пароль");
                }
                if (string.IsNullOrWhiteSpace(_currentUser.Name))
                {
                    errors.AppendLine("Укажите имя");
                }
                if (string.IsNullOrWhiteSpace(_currentUser.SurName))
                {
                    errors.AppendLine("Укажите фамилию");
                }
                if (_currentUser.Role == null)
                {
                    errors.AppendLine("Выберите роль");
                }
                if (errors.Length > 0)
                {

                    MessageBox.Show(errors.ToString(), "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (_currentUser.id == 0)
                {
                    try
                    {
                        string logindChek = "SELECT * FROM Users WHERE Login ='" + Login.Text + "'";
                        var sql = ScheduleEntities.GetContext().Users.SqlQuery(logindChek).ToArray();
                        if (sql.Length != 0)
                        {
                            MessageBox.Show("Логин уже занят другим пользователем.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (sql.Length == 0)
                        {

                            ScheduleEntities.GetContext().Users.Add(_currentUser);
                            ScheduleEntities.GetContext().SaveChanges();
                            MessageBox.Show("Пользователь добавлен.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.MainFrame.GoBack();
                        }
                    }
                    catch (Exception en)
                    {
                        MessageBox.Show(en.Message.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Ошибка подключения к серверу", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
