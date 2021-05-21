using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Controllers
{
    public class HtmlSamplesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
