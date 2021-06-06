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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            DGridShedule.ItemsSource = ScheduleEntities.GetContext().Sheldules.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPage((sender as Button).DataContext as Sheldules));

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var deleteSheldules = DGridShedule.SelectedItems.Cast<Sheldules>().ToArray();

            if (MessageBox.Show($"Вы точно хотите удалить следущие {deleteSheldules.Count()} элементов? \nВсе данные с этими дежурством будут удалены!!!", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                ScheduleEntities.GetContext().Sheldules.RemoveRange(deleteSheldules);
                ScheduleEntities.GetContext().SaveChanges();
                DGridShedule.ItemsSource = ScheduleEntities.GetContext().Sheldules.ToArray();
                

            }


        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ScheduleEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGridShedule.ItemsSource = ScheduleEntities.GetContext().Sheldules.ToArray();
        }

        private void tBPoisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tBPoisk.Text))
            {
                try
                {
                    DGridShedule.ItemsSource = ScheduleEntities.GetContext().Sheldules.Where(p =>

                        p.SurName.ToString().ToLower().Contains(tBPoisk.Text.ToLower()) ||
                        p.Name.ToString().ToLower().Contains(tBPoisk.Text.ToLower()) ||
                        p.RoleSheldules.day.ToString().ToLower().Contains(tBPoisk.Text.ToLower()) ||
                        p.RoleMonth.month.ToString().ToLower().Contains(tBPoisk.Text.ToLower())).ToList();


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
