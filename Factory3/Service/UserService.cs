using Factory3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory3.Service
{
    public class UserService
    {
        public IEnumerable<User> List()
        {
            IEnumerable<User> result;

            using (var dataContext = new DataContext())
            {
                result = dataContext.Users.ToList();
            }

            return result;
        }

        public User Insert(User user)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Users.Add(user);
                dataContext.SaveChanges();
            }
            return user;
        }

        public User Get(int id)
        {
            User result;
            using(var dataContext = new DataContext())
            {
                result = dataContext.Users.Find(id);

            }
            return result;
        }
    }
}
