using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.ViewModels.Home
{
    public class HomeViewModel
    {
        public string Message { get; set; }

        public List<Book> Books { get; set; }
    }
}
