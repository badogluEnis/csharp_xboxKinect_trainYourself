using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DataAccess
{
    public class UserRepository : AbstractRepository<User>
    {
        public UserRepository(TrainContext context) : base(context)
        {
        }

        public bool CheckLogin(string email, string password)
        {
            return Context.Users.Any(u => u.Password == password && u.Email == email);
        }

        public int GetUserIdByMail(string mail)
        {

            return Context.Users.Single(u => u.Email == mail).Id;
        }

        public bool CheckIfEmailexist(string mail)
        {
            return Context.Users.Any(u => u.Email == mail);
        }

        public static void UpdateUser(User user)
        {
            using (TrainContext context = new TrainContext())
            {
                context.Users.Attach(user);
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
