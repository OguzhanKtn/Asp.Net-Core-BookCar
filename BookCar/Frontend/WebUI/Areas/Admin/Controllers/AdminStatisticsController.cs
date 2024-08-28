using Dto.StatisticsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();

            #region İstatistik1
            var responseMessage = await client.GetAsync("https://localhost:44380/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int v1 = random.Next(0, 101);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.v = values.carCount;
                ViewBag.v1 = v1;
            }
            #endregion

            #region İstatistik2
            var responseMessage2 = await client.GetAsync("https://localhost:44380/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                int locationCountRandom = random.Next(0, 101);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                
                ViewBag.locationCount = values.locationCount;
                ViewBag.locationCountRandom = locationCountRandom;
            }
            #endregion

            #region İstatistik3
            var responseMessage3 = await client.GetAsync("https://localhost:44380/api/Statistics/GetBrandCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                int brandCountRandom = random.Next(0, 101);
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                
                ViewBag.brandCount = values.brandCount;
                ViewBag.brandCountRandom = brandCountRandom;
            }
            #endregion

            #region İstatistik4
            var responseMessage4 = await client.GetAsync("https://localhost:44380/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int avgRentPriceForDailyRandom = random.Next(0, 101);
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.avgRentPriceForDaily = values.avgRentPriceForDaily.ToString("0.00"); ;
                ViewBag.avgRentPriceForDailyRandom = avgRentPriceForDailyRandom;
            }
            #endregion

            #region İstatistik5
            var responseMessage5 = await client.GetAsync("https://localhost:44380/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMessage5.IsSuccessStatusCode)
            {
                int avgRentPriceForWeeklyRandom = random.Next(0, 101);
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.avgRentPriceForWeekly = values.avgRentPriceForWeekly.ToString("0.00");
                ViewBag.avgRentPriceForWeeklyRandom = avgRentPriceForWeeklyRandom;
            }
            #endregion

            #region İstatistik6
            var responseMessage6 = await client.GetAsync("https://localhost:44380/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseMessage6.IsSuccessStatusCode)
            {
                int avgRentPriceForMonthlyRandom = random.Next(0, 101);
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
                ViewBag.avgRentPriceForMonthly = values.avgRentPriceForMonthly.ToString("0.00");
                ViewBag.avgRentPriceForMonthlyRandom = avgRentPriceForMonthlyRandom;
            }
            #endregion

            #region İstatistik7
            var responseMessage7 = await client.GetAsync("https://localhost:44380/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (responseMessage7.IsSuccessStatusCode)
            {
                int carCountByTranmissionIsAutoRandom = random.Next(0, 101);
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
                ViewBag.carCountByTranmissionIsAuto = values.carCountByTransmissionIsAuto;
                ViewBag.carCountByTranmissionIsAutoRandom = carCountByTranmissionIsAutoRandom;
            }
            #endregion

            #region İstatistik8
            var responseMessage8 = await client.GetAsync("https://localhost:44380/api/Statistics/GetBrandNameByMaxCar");
            if (responseMessage8.IsSuccessStatusCode)
            {
                int brandNameByMaxCarRandom = random.Next(0, 101);
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
                ViewBag.brandNameByMaxCar = values.brandNameByMaxCar;
                ViewBag.brandNameByMaxCarRandom = brandNameByMaxCarRandom;
            }
            #endregion

            #region İstatistik9
            var responseMessage9 = await client.GetAsync("https://localhost:44380/api/Statistics/GetCarCountByKmSmallerThan1000");
            if (responseMessage9.IsSuccessStatusCode)
            {
                int carCountByKmSmallerThan1000Random = random.Next(0, 101);
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
                ViewBag.carCountByKmSmallerThen1000 = values.carCountByKmSmallerThan1000;
                ViewBag.carCountByKmSmallerThen1000Random = carCountByKmSmallerThan1000Random;
            }
            #endregion

            #region İstatistik10
            var responseMessage10 = await client.GetAsync("https://localhost:44380/api/Statistics/GetCarCountByFuelGasoline");
            if (responseMessage10.IsSuccessStatusCode)
            {
                int carCountByFuelGasolineOrDieselRandom = random.Next(0, 101);
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);
                ViewBag.carCountByFuelGasoline = values.carCountByFuelGasoline;
                ViewBag.carCountByFuelGasolineRandom = carCountByFuelGasolineOrDieselRandom;
            }
            #endregion

            #region İstatistik11
            var responseMessage11 = await client.GetAsync("https://localhost:44380/api/Statistics/GetCarCountByFuelDiesel");
            if (responseMessage11.IsSuccessStatusCode)
            {
                int carCountByFuelDieselRandom = random.Next(0, 101);
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);
                ViewBag.carCountByFuelDiesel = values.carCountByFuelDiesel;
                ViewBag.carCountByFuelDieselRandom = carCountByFuelDieselRandom;
            }
            #endregion

            #region İstatistik12
            var responseMessage12 = await client.GetAsync("https://localhost:44380/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseMessage12.IsSuccessStatusCode)
            {
                int carBrandAndModelByRentPriceDailyMaxRandom = random.Next(0, 101);
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);
                ViewBag.carBrandAndModelByRentPriceDailyMax = values.carBrandAndModelByRentPriceDailyMax;
                ViewBag.carBrandAndModelByRentPriceDailyMaxRandom = carBrandAndModelByRentPriceDailyMaxRandom;
            }
            #endregion

            #region İstatistik13
            var responseMessage13 = await client.GetAsync("https://localhost:44380/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseMessage13.IsSuccessStatusCode)
            {
                int carBrandAndModelByRentPriceDailyMinRandom = random.Next(0, 101);
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData13);
                ViewBag.carBrandAndModelByRentPriceDailyMin = values.carBrandAndModelByRentPriceDailyMin;
                ViewBag.carBrandAndModelByRentPriceDailyMinRandom = carBrandAndModelByRentPriceDailyMinRandom;
            }
            #endregion

            return View();
        }
    }
}
