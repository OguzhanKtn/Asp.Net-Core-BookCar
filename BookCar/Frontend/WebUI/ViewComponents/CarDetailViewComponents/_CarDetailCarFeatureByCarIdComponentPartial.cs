﻿using Dto.CarFeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailCarFeatureByCarIdComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _CarDetailCarFeatureByCarIdComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.carId = id;
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44380/api/CarFeatures?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
