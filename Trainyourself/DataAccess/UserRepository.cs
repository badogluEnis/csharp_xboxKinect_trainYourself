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

  
    }
}
