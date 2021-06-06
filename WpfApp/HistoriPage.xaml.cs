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
    /// Логика взаимодействия для HistoriPage.xaml
    /// </summary>
    public partial class HistoriPage : Page
    {
        public HistoriPage()
        {
            InitializeComponent();
            dBHistori.ItemsSource = ScheduleEntities.GetContext().LoginHistory.ToArray();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены что хотите очистеть всю историю?", "Информация",

                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
                try
                {
                    if (result == MessageBoxResult.Yes)
                    {
                        ScheduleEntities deleteHistori = new ScheduleEntities();
                        var sql = deleteHistori.Database.ExecuteSqlCommand("DELETE  FROM LoginHistory Where Id != 0");
                        ScheduleEntities.GetContext().SaveChanges();
                        dBHistori.ItemsSource = ScheduleEntities.GetContext().LoginHistory.ToArray();
                        MessageBox.Show("История входа чистая.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch
                {

                }
            }
        }
    }
}
