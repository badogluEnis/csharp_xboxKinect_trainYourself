using System.Collections.Generic;
using System.Linq;
using Model;

namespace DataAccess
{
    public class UserRepository : AbstractRepository<User>
    {
        public UserRepository(TrainContext context) : base(context)
        {
        }

        public List<User> Top4ListPushUps()
        {
            return Context.Users.OrderByDescending(u => u.RecordPushups).Take(4).ToList();
        }

        public List<User> Top4ListSitUps()
        {
            return Context.Users.OrderByDescending(u => u.RecordSitups).Take(4).ToList();
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
    }
}
