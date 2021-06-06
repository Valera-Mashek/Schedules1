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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        private Sheldules _currentSchedule = new Sheldules();
        public AddPage(Sheldules sheldules)
        {
            InitializeComponent();
            if (sheldules != null)
                _currentSchedule = sheldules;
            DataContext = _currentSchedule;
            ComboCountries.ItemsSource = ScheduleEntities.GetContext().RoleSheldules.ToList();
            ComboCountries2.ItemsSource = ScheduleEntities.GetContext().RoleMonth.ToList();

        }



        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            {
                
                if (string.IsNullOrWhiteSpace(_currentSchedule.Name))
                {
                    errors.AppendLine("Укажите имя");
                }
                if (string.IsNullOrWhiteSpace(_currentSchedule.SurName))
                {
                    errors.AppendLine("Укажите фамилию");
                }
                if (_currentSchedule.RoleSheldules == null)
                {
                    errors.AppendLine("Выберите день");
                }
                if (_currentSchedule.RoleMonth == null)
                {
                    errors.AppendLine("Выберите месяц");
                }
                if (errors.Length > 0)
                {

                    MessageBox.Show(errors.ToString(), "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (_currentSchedule.id == 0)
                {
                    try
                    {

                        {

                            ScheduleEntities.GetContext().Sheldules.Add(_currentSchedule);
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

                else
                {
                    MessageBox.Show("Ошибка подключения к серверу", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }

        }

        
    }
}
