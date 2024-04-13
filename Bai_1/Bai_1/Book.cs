using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }

        public Book(string title, string author, string isbn, decimal price)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Price = price;
        }
    }

}
