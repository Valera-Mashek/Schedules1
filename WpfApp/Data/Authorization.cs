using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp.BD;

namespace WpfApp.Data
{
  public static  class Authorization
  {
        public static void Vhod(TextBox tBLogin, PasswordBox pBPassword, Page AdministratorPage, Page AdminAssistantPage)
        {

            int errors = 0;
            try
            {

                foreach (var user in ScheduleEntities.GetContext().Users)
                {

                    if (tBLogin.Text == user.Login && pBPassword.Password == user.Password)
                    {                        
                        if (user.RoleId == 1)
                        {
                            MessageBox.Show("Вы вошли как: Администратор.", "Информация",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                            Manager.MainFrame.Navigate(AdministratorPage);                           
                        }
                        else if (user.RoleId == 2)
                        {
                            MessageBox.Show("Вы вошли как: Студент.", "Информация",
                             MessageBoxButton.OK,
                             MessageBoxImage.Information);
                            Manager.MainFrame.Navigate(AdminAssistantPage);
                            
                        }

                        errors = 0;
                        break;
                    }
                    else if (tBLogin.Text == user.Login)
                    {
                        errors += 2;
                    }

                    else
                    {
                        errors++;
                    }


                }
                if (errors == 0)
                {
                    // Для истории входа                                   
                    Histori.AddHistori(tBLogin.Text, true);
                    ///////
                }
                else
                {
                    if (errors == 2)
                    {
                        // Для истории входа
                        Histori.AddHistori(tBLogin.Text, false);
                        //////
                    }
                    MessageBox.Show("Логин или пароль не верный", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("На данный момент отсутствует подключение к серверу. \nОбратитесь к техническому специалисту.", "Информация",
               MessageBoxButton.OK,
               MessageBoxImage.Information);
            }

        }
        public static void Length(TextBox textBox, PasswordBox passwordBox)
        {
            if (textBox.Text.Length == 0 && passwordBox.Password.Length == 0)
            {
                MessageBox.Show("Вы не ввели логин и пароль.", "Информация",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else if (textBox.Text.Length == 0 && passwordBox.Password.Length != 0)
            {
                MessageBox.Show("Вы не ввели логин.", "Информация",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else if (textBox.Text.Length != 0 && passwordBox.Password.Length == 0)
            {
                MessageBox.Show("Вы не ввели пароль.", "Информация",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }
    }
}
