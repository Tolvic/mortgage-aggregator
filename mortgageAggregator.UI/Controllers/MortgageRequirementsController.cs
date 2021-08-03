using Microsoft.AspNetCore.Mvc;
using mortageAggregator.UI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace mortgageAggregator.UI.Controllers
{
    public class MortgageRequirementsController : Controller
    {
        private readonly HttpClient _AvailableMortgagesClient;

        public MortgageRequirementsController(IHttpClientFactory clientFactory)
        {
            _AvailableMortgagesClient = clientFactory.CreateClient("AvailableMortgages");
        }

        public IActionResult Index(int userId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Add", "User");
            }

            var AvailableMortgageRequest = new AvailableMortageRequest
            {
                UserId = userId
            };

            return View(AvailableMortgageRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Get(AvailableMortageRequest availableMortageRequest)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }

            var body = new StringContent(
                JsonConvert.SerializeObject(availableMortageRequest),
               Encoding.UTF8,
               "application/json");

            var response = await _AvailableMortgagesClient.PostAsync("Get", body);

            if (response.IsSuccessStatusCode)
            {
                var responseMessage = await response.Content.ReadAsStringAsync();

                var mortgages = JsonConvert.DeserializeObject<List<Mortgage>>(responseMessage);

                return PartialView("_MortgagesTable", mortgages);
            }

            return BadRequest();
        }
    }
}
