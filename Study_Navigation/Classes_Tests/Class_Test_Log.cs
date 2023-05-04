using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Navigation.Classes_Tests
{
    public class Class_Test_Log
    {
        /// <summary>
        /// Тест-1 для проверки верности пользователя
        /// </summary>
        /// <param name="login"></param>
        /// <param name="passw"></param>
        /// <param name="type_us"></param>
        /// <returns></returns>
        public bool LogIsTrue(string login, string passw, int type_us)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                var logs = new User()
                {
                    Login = login,
                    Password = passw,
                    Access_rights = type_us
                };

                dbContext.Users.Add(logs);
                dbContext.SaveChanges();

                var maxValue = dbContext.Users.Max(x => x.id_user);
                var result = dbContext.Users.First(x => x.id_user == maxValue);

                string _login = result.Login;
                string _passw = result.Password;
                int _type_us = result.Access_rights;

                return (0 == String.Compare(login, _login)) && 0 == (String.Compare(passw, _passw)) && (type_us == _type_us);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="passw"></param>
        /// <param name="type_us"></param>
        /// <returns></returns>
        public bool LogIsFalse(string login, string passw, int type_us)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                var logs = new User()
                {
                    Login = login,
                    Password = passw,
                    Access_rights = type_us
                };

                dbContext.Users.Add(logs);
                dbContext.SaveChanges();

                var maxValue = dbContext.Users.Max(x => x.id_user);
                var result = dbContext.Users.First(x => x.id_user == maxValue);

                string _login = result.Login;
                string _passw = result.Password;
                int _type_us = result.Access_rights;

                return (0 != String.Compare(login, _login)) && 0 != (String.Compare(passw, _passw)) && (type_us != _type_us);
            }
        }
    }
}
