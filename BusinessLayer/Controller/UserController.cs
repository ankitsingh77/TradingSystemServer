using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Model;

namespace BusinessLayer.Controller
{
    public class UserController
    {
        public Guid CreateUser(string userName, string fullName, string emailId, int userType, string pwd)
        {
            Guid result = Guid.NewGuid();
            try
            {
                using (TradingSystemDbContext dbContext = new TradingSystemDbContext())
                {
                    var user = new User()
                    {
                        UserId = result,
                        UserName = userName,
                        FullName = fullName,
                        EmailId = emailId,
                        Type = (UserType)userType,
                        Password = pwd
                    };

                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Guid.Empty;
            }

            return result;
        }

        public User GetUser(Guid id)
        {
            if(id == null)
            {
                return null;
            }

            using (var dbContext = new TradingSystemDbContext())
            {
                return dbContext.Users.Find(id);
            }
        }

        public User ValidateUser(string userName, string password)
        {
            using (var dbContext = new TradingSystemDbContext())
            {
                return dbContext.Users.Where(o => o.UserName == userName && o.Password == password).FirstOrDefault();
            }
        }

    }
}
