using mortageAggregator.API.Models;
using System.Linq;

namespace mortageAggregator.API.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private MortageAggregatorContext _context;

        public UsersRepository(MortageAggregatorContext context)
        {
            _context = context;
        }

        public User Get(int Id)
        {
            return _context.User.SingleOrDefault(x => x.Id == Id);
        }

        public User Add(User user)
        {           
            _context.User.Add(user);

            _context.SaveChanges();

            return user;
        }
    }
}
