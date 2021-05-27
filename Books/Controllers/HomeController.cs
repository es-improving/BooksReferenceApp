using Books.Models;
using Books.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly BookData _bookData;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, BookData bookData)
        {
            _logger = logger;
            _configuration = configuration;
            _bookData = bookData;
        }

        public IActionResult Index()
        {
            var books = _bookData.AllBookData();   

            var vm = new HomeViewModel();
            vm.Message = "Look at these wonderful books!";
            vm.Books = books;

            return View(vm);
        }

        public IActionResult BooksWithAjax()
        {
            return View();
        }

        public IActionResult BookData()
        {
            var books = _bookData.AllBookData();

            return Json(books);
        }

        //Home/Book/42
        public IActionResult Book(int? id)
        {
            // TODO: Use the id passed and go get the book data.
            // Use that book data to create a new view.
            var vm = new BookDetailViewModel
            {
                Book = _bookData.GetBook(id.Value)
            };
            return View(vm);
        }


        [HttpGet]
        public IActionResult NewBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewBook(Book book)
        {
            _bookData.CreateNewBook(book);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
