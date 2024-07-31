using Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.ViewComponents.TestimonialViewComponents
{
    public class _TestimonialViewComponentPartial : ViewComponent
    {
        private IHttpClientFactory _httpClientFactory;

        public _TestimonialViewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:44380/api/Testimonial");

            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultTestimonialDto>>(jsonData);

                return View(values);
            }
            return View();
        }
    }
}
