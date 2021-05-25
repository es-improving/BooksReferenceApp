using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SingleBlogPost(int? year, int? month, int? day, string slug)
        {
            ViewData["year"] = year;
            ViewData["title"] = slug;

            return View();
        }

        public IActionResult BlogCategory(string name)
        {
            ViewData["name"] = name;
            return View();
        }
    }
}
