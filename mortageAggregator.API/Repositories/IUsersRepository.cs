using mortageAggregator.API.Models;

namespace mortageAggregator.API.Repositories
{
    public interface IUsersRepository
    {
        public User Get(int Id);

        public User Add(User user);

    }
}