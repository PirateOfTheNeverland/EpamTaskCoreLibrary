using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTaskTestSuite.Entities;

namespace EpamTaskTestSuite.DataProviders
{
    public class UserProvider
    {
        public static IEnumerable<User> Users
        {
            get
            {
                yield return new User()
                {
                    Name = "aivanooooov",
                    Password = "123qwe123",
                    Domain = "mail.ru"
                };
            }
        } 
    }
}
