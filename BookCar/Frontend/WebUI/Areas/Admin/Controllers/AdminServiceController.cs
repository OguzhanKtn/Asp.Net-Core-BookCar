﻿using Dto.ServiceDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/AdminService")]
    public class AdminServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44380/api/Service");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("CreateService")]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateService")]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "carbooktoken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var jsonData = JsonConvert.SerializeObject(createServiceDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:44380/api/Service", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AdminService", new { area = "Admin" });
                }
            }          
            return View();
        }
        [Route("RemoveService/{id}")]
        public async Task<IActionResult> RemoveService(int id)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "carbooktoken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var responseMessage = await client.DeleteAsync("https://localhost:44380/api/Service?id=" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AdminService", new { area = "Admin" });
                }
            }           
            return View();
        }
        [HttpGet]
        [Route("UpdateService/{id}")]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var resposenMessage = await client.GetAsync($"https://localhost:44380/api/Service/{id}");
            if (resposenMessage.IsSuccessStatusCode)
            {
                var jsonData = await resposenMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateService/{id}")]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "carbooktoken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var jsonData = JsonConvert.SerializeObject(updateServiceDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:44380/api/Service/", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AdminService", new { area = "Admin" });
                }
            }      
            return View();
        }
    }
}
