using Microsoft.AspNetCore.Mvc;
using mortageAggregator.API.Models;
using mortageAggregator.API.Repositories;

namespace mortageAggregator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            user = _usersRepository.Add(user);

            return Ok(user.Id);
        }
    }
}
