using Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            var bookPickDate = TempData["bookPickDate"];
            var bookOffDate = TempData["bookOffDate"];
            var timePick = TempData["timePick"];
            var timeOff = TempData["timeOff"];
            var locationID = TempData["locationID"];

            id = Convert.ToInt32(locationID);

            ViewBag.bookPickDate = bookPickDate;
            ViewBag.bookOffDate = bookOffDate;
            ViewBag.timePick = timePick;
            ViewBag.timeOff = timeOff;
            ViewBag.locationID = locationID;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44380/api/RentACars?locationID={id}&available=true");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
