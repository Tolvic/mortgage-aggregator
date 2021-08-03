using Microsoft.AspNetCore.Mvc;
using mortageAggregator.UI.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace mortgageAggregator.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _UserClient;

        public UserController(IHttpClientFactory clientFactory)
        {
            _UserClient = clientFactory.CreateClient("User"); 
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var body = new StringContent(
                JsonSerializer.Serialize(user),
                Encoding.UTF8,
                "application/json");

            var response = await _UserClient.PostAsync("Add", body);

            if (response.IsSuccessStatusCode)
            { 
                var userId = int.Parse(await response.Content.ReadAsStringAsync());

                return RedirectToAction("Index", "MortgageRequirements", new { userId = userId});
            }

            return View("Error");
        }
    }
}
