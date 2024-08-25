using Dto.CarDtos;
using Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44380/api/Car/GetCarPricingWithCar");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultCarPricingDto>>(jsonData);

                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewBag.v1 = "Car Details";
            ViewBag.v2 = "Technical Accessories and Features Of The Car";
            ViewBag.carId = id;
            return View();
        }
    }
}
