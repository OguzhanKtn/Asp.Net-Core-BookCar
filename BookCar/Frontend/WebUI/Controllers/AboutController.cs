﻿using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "About Us";
            ViewBag.v2 = "Our mission & vision";
            return View();
        }
    }
}
