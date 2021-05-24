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

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        // TODO: This is not where this belongs! We'll continue refactoring and put it elsewhere later.
        private List<Book> AllBookData()
        {
            var books = new List<Book>();

            var connString = _configuration.GetConnectionString("default");
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();

                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM Books";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var title = reader["Title"].ToString();
                    var id = Convert.ToInt32(reader["BookId"]);

                    books.Add(new Book
                    {
                        Title = title,
                        Id = id
                    });
                }
            }

            return books;
        }

        public IActionResult Index()
        {
            var books = AllBookData();   

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
            var books = AllBookData();

            return Json(books);
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
