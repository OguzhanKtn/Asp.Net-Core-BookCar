using Microsoft.AspNetCore.Mvc;

namespace WebUI.Views.Shared.Components._ScriptUILayoutComponentPartial
{
    public class _ScriptUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
