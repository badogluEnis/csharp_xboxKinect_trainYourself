using Model;

namespace DataAccess
{
    public class UserRepository : AbstractRepository<User>
    {
        public UserRepository(TrainContext context) : base(context)
        {
        }

  
    }
}
