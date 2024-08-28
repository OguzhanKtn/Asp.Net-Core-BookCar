using Application.Features.CQRS.Commands.CarFeaturesCommand;
using Application.ViewModels;
using Dto.CarFeatureDtos;
using Dto.FeatureDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44380/api/CarFeatures?id="+id);
            if (responseMessage.IsSuccessStatusCode) 
            { 
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDto)
        {
            foreach (var item in resultCarFeatureByCarIdDto)
            {
                if (item.Available)
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:44380/api/CarFeatures/CarFeatureChangeAvailableToTrue?id=" + item.CarFeatureID);

                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:44380/api/CarFeatures/CarFeatureChangeAvailableToFalse?id=" + item.CarFeatureID);
                }
            }
            return RedirectToAction("Index", "AdminCar");
        }
        [Route("CreateFeatureByCarId/{id}")]
        [HttpGet]
        public async Task<IActionResult> CreateFeatureByCarId(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44380/api/Feature");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                ViewBag.carId = id;
                return View(values);           
            }
            return View();
        }

        [HttpPost]
        [Route("CreateFeatureByCarID/{id}")]
        public async Task<IActionResult> AddFeatureByCar(List<AddCarFeatureByCarDto> dto)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "carbooktoken")?.Value;
            if (token != null)
            {
                try
                {
                    var client = _httpClientFactory.CreateClient();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var command = new CreateCarFeatureByCarCommand
                    {
                        CarFeatures = dto.Select(d => new CarFeatureViewModel
                        {
                            FeatureID = d.FeatureID,
                            CarID = d.CarID,
                            Available = d.Available
                        }).ToList()
                    };
                    var jsonData = JsonConvert.SerializeObject(command);
                    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsync("https://localhost:44380/api/CarFeatures", stringContent);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "AdminCar");
                    }
                    else
                    {
                        var errorResponse = await responseMessage.Content.ReadAsStringAsync();
                        ModelState.AddModelError(string.Empty, $"API Error: {responseMessage.StatusCode} - {errorResponse}");
                        return View();
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                    return View();
                }
            }
               return View();
        }
    }
}
