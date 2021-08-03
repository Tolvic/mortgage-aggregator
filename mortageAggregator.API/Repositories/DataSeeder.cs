using mortageAggregator.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace mortageAggregator.API.Repositories
{
    public class DataSeeder
    {
        private MortageAggregatorContext _context;

        public DataSeeder(MortageAggregatorContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Mortage.Any())
            {
                return;
            }

            _context.Database.EnsureCreated();

            _context.Mortage.AddRange(GetSeedData());

            _context.SaveChanges();
        }

        private List<Mortgage> GetSeedData()
        {
            return new List<Mortgage>
            {
                new Mortgage
                {
                    Lender = "Lender A",
                    interestRate = 2.00m,
                    Type = "Variable",
                    MaxLoandToValue = 60.00m
                },
                new Mortgage
                {
                    Lender = "Lender B",
                    interestRate = 3.00m,
                    Type = "Fixed",
                    MaxLoandToValue = 60.00m
                },
                new Mortgage
                {
                    Lender = "Lender C",
                    interestRate = 4.00m,
                    Type = "Fixed",
                    MaxLoandToValue = 90.00m
                }
            };
        }
    }
}
