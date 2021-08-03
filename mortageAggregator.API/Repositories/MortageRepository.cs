using mortageAggregator.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace mortageAggregator.API.Repositories
{
    public class MortageRepository : IMortgageRepository
    {
        private readonly MortageAggregatorContext _context;

        public MortageRepository(MortageAggregatorContext context)
        {
            _context = context;
        }

        public List<Mortgage> GetByMaxLoanToValue(decimal loanToValueAmount)
        {
            return _context.Mortage.Where(x => x.MaxLoandToValue > loanToValueAmount).ToList();
        }
    }
}
