using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.DefaultStatisticsComponent
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
