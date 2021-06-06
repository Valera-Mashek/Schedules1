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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public UserPage()
        {
            InitializeComponent();
            DGridShedule.ItemsSource = ScheduleEntities.GetContext().Users.ToList();
        }

        private void BtnInfoDelete_Click(object sender, RoutedEventArgs e)
        {
            var deleteUsers = DGridShedule.SelectedItems.Cast<Users>().ToArray();

            if (MessageBox.Show($"Вы точно хотите удалить следущие {deleteUsers.Count()} элементов? \nВсе данные с этими пользователем будут удалены!!!", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ScheduleEntities.GetContext().Users.RemoveRange(deleteUsers);
                ScheduleEntities.GetContext().SaveChanges();
                DGridShedule.ItemsSource = ScheduleEntities.GetContext().Users.ToArray();


            }


        }

        private void BtnRedac_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new UserAppPage((sender as Button).DataContext as Users));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ScheduleEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGridShedule.ItemsSource = ScheduleEntities.GetContext().Users.ToArray();
        }

        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            {
                if (!string.IsNullOrEmpty(Poisk.Text))
                {
                    try
                    {
                        DGridShedule.ItemsSource = ScheduleEntities.GetContext().Users.Where(p =>

                            p.Login.ToString().ToLower().Contains(Poisk.Text.ToLower()) ||
                            p.Password.ToString().ToLower().Contains(Poisk.Text.ToLower()) ||
                            p.Name.ToString().ToLower().Contains(Poisk.Text.ToLower()) ||
                            p.SurName.ToString().ToLower().Contains(Poisk.Text.ToLower()) ||
                            p.Role.Name.ToString().ToLower().Contains(Poisk.Text.ToLower())).ToList();


                    }
                    catch
                    {
                        MessageBox.Show("Ошибка в получении данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    try
                    {
                        DGridShedule.ItemsSource = ScheduleEntities.GetContext().Sheldules.ToList();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка в получении данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
