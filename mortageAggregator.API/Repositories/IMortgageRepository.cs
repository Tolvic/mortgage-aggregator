using mortageAggregator.API.Models;
using System.Collections.Generic;

namespace mortageAggregator.API.Repositories
{
    public interface IMortgageRepository
    {
        public List<Mortgage> GetByMaxLoanToValue(decimal loanToValueAmount);
    }
}