using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Study_Navigation;

namespace Study_Navigation.Classes_Tests
{
    public class Class_Test_Reg
    {
        /// <summary>
        /// Тест положительный
        /// </summary>
        /// <param name="us_name"></param>
        /// <param name="log"></param>
        /// <param name="passw"></param>
        /// <returns></returns>
        public bool RegIsTrue(string us_name, string log, string passw)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                var regs = new User()
                {
                    FCs = us_name,
                    Login = log,
                    Password = passw
                };

                dbContext.Users.Add(regs);
                dbContext.SaveChanges();

                var maxValue = dbContext.Users.Max(x => x.id_user);
                var result = dbContext.Users.First(x => x.id_user == maxValue);

                string _us_name = result.FCs;
                string _log = result.Login;
                string _passw = result.Password;

                return (0 == String.Compare(us_name, _us_name)) && 0 == (String.Compare(log, _log)) && 0 == (String.Compare(passw, _passw));
            }
        }

        /// <summary>
        /// Тест негативный
        /// </summary>
        /// <param name="us_name"></param>
        /// <param name="log"></param>
        /// <param name="passw"></param>
        /// <returns></returns>
        public bool RegIsFalse(string us_name, string log, string passw)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                var regs = new User()
                {
                    FCs = us_name,
                    Login = log,
                    Password = passw
                };

                dbContext.Users.Add(regs);
                dbContext.SaveChanges();

                var maxValue = dbContext.Users.Max(x => x.id_user);
                var result = dbContext.Users.First(x => x.id_user == maxValue);

                string _us_name = result.FCs;
                string _log = result.Login;
                string _passw = result.Password;

                return (0 != String.Compare(us_name, _us_name)) && 0 != (String.Compare(log, _log)) && 0 != (String.Compare(passw, _passw));
            }
        }
    }
}
