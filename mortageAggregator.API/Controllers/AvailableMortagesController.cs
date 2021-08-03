using Microsoft.AspNetCore.Mvc;
using mortageAggregator.API.Calculator;
using mortageAggregator.API.Models;
using mortageAggregator.API.Repositories;
using System.Collections.Generic;

namespace mortageAggregator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableMortagesController : ControllerBase
    {
        private const int MinAge = 18;
        private readonly ILoanToValueCalculator _loanToValueCalculator;
        private readonly IUsersRepository _usersRepository;
        private readonly IMortgageRepository _mortgageRepository;

        public AvailableMortagesController(ILoanToValueCalculator loanToValueCalculator, IUsersRepository usersRepository, IMortgageRepository mortgageRepository)
        {
            _loanToValueCalculator = loanToValueCalculator;
            _usersRepository = usersRepository;
            _mortgageRepository = mortgageRepository;

        }

        [HttpPost]
        [Route("Get")]
        public IActionResult Get(AvailableMortageRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = _usersRepository.Get(request.UserId);

            if (user == null)
            {
                return BadRequest();
            }

            if (user.GetAge() < MinAge)
            {
                return Ok(new List<Mortgage>());
            }

            var ltvAmount = _loanToValueCalculator.Calculate(request.PropertyValue, request.DepositAmount);

            return Ok(_mortgageRepository.GetByMaxLoanToValue(ltvAmount));
        }
    }
}
