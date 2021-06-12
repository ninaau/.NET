using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Lab3NET.Models;

namespace Lab3NET.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Razor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Count(NumOfBottles model)
        {
            return View(model);
        }

        [HttpGet]
        public IActionResult CreatePerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DisplayPerson(Person model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult Error()
        {
            return View();
        }

    }
}
