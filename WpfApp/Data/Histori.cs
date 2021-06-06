using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.BD;

namespace WpfApp.Data
{
   public static class Histori
    {


        public static void AddHistori(string login, bool result)
        {

            LoginHistory loginHistory = new LoginHistory();
            loginHistory.Login = login;
            loginHistory.Data = DateTime.Now;
            loginHistory.Statys = result;
            ScheduleEntities.GetContext().LoginHistory.Add(loginHistory);
            ScheduleEntities.GetContext().SaveChanges();

        }
    }
}
