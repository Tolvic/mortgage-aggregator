using Microsoft.EntityFrameworkCore;
using mortageAggregator.API.Models;

namespace mortageAggregator.API.Repositories
{
    public class MortageAggregatorContext : DbContext
    {
        public MortageAggregatorContext(DbContextOptions<MortageAggregatorContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Mortgage> Mortage { get; set; }
    }
}
