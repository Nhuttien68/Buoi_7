using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1
{
    public class Function
    {
        private Library library;

        public Function(Library library)
        {
            this.library = library;
        }

        public Function()
        {
        }

        public void addBook(Library library)
        {
            Console.WriteLine("\nNhap thong tin sach:");
            string title = "";
            string author = "";
            string isbn = "";
            decimal price = 0;
            while (string.IsNullOrWhiteSpace(title) || chuakitudacbiet(title) || !CheckXSSInput(title))
            {
                Console.Write("Nhap ten sach: ");
                title = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("Ten sach khong duoc de trong. Vui long nhap lai.");
                }
                else if (chuakitudacbiet(title))
                {
                    Console.WriteLine("Ten sach khong duoc chua ki tu dac biet. Vui long nhap lai.");
                }
                else if (!CheckXSSInput(title))
                {
                    Console.WriteLine("Ten sach khong duoc chua ky tu nguy hiem. Vui long nhap lai.");
                }
            }
            while (string.IsNullOrWhiteSpace(author) || chuakitudacbiet(author) || !CheckXSSInput(author))
            {
                Console.Write("Nhap ten tac gia: ");
                author = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(author))
                {
                    Console.WriteLine("Ten tac gia khong duoc de trong. Vui long nhap lai.");
                }
                else if (chuakitudacbiet(author))
                {
                    Console.WriteLine("Ten tac gia khong duoc chua ki tu dac biet. Vui long nhap lai.");
                }
                else if (!CheckXSSInput(author))
                {
                    Console.WriteLine("Ten tac gia khong duoc chua ky tu nguy hiem. Vui long nhap lai.");
                }
            }
            while (string.IsNullOrWhiteSpace(isbn) || !isbn.StartsWith("ISBN"))
            {
                Console.Write("Nhap ISBN (ISBNxxxx): ");
                isbn = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(isbn))
                {
                    Console.WriteLine("ISBN khong duoc de trong. Vui long nhap lai.");
                }
                else if (!isbn.StartsWith("ISBN"))
                {
                    Console.WriteLine("ISBN phai bat dau bang 'ISBN'. Vui long nhap lai.");
                }
            }
            while (price <= 0)
            {
                Console.Write("Nhap gia: ");
                string priceInput = Console.ReadLine();
                if (!decimal.TryParse(priceInput, out price) || price <= 0)
                {
                    Console.WriteLine("Gia khong hop le. Vui long nhap gia la mot so duong.");
                }
            }
            library.addBook(new Book(title, author, isbn, price));
        }


        public void searchBookByAuthor(Library library)
        {
            Console.Write("\nEnter author name: ");
            string author = Console.ReadLine();
            Book book = library.searchByAuthor(author);
            if (book != null)
            {
                Console.WriteLine($"Found book: {book.Title} by {book.Author}");
            }
        }

        public void searchBookByISBN(Library library)
        {
            Console.Write("\nEnter ISBN: ");
            string isbn = Console.ReadLine();
            Book book = library.searchByISBN(isbn);
            if (book != null)
            {
                Console.WriteLine($"Found book: {book.Title} (ISBN: {book.ISBN})");
            }
        }

        public void borrowBook(Library library)
        {
            Console.Write("\nEnter ISBN of book to borrow: ");
            string isbn = Console.ReadLine();
            library.borrowBook(isbn);
        }

        public void returnBook(Library library)
        {
            Console.Write("\nEnter ISBN of book to return: ");
            string isbn = Console.ReadLine();
            Book book = library.searchByISBN(isbn);
            if (book != null)
            {
                library.returnBook(book);
            }
        }


        public bool CheckXSSInput(string input)
        {
            try
            {
                var listdangerousString = new List<string> { "<applet", "<body", "<embed", "<frame", "<script", "<frameset", "<html", "<iframe", "<img", "<style", "<layer", "<link", "<ilayer", "<meta", "<object", "<h", "<input", "<a", "&lt", "&gt" };
                if (string.IsNullOrEmpty(input)) return false;
                foreach (var dangerous in listdangerousString)
                {
                    if (input.Trim().ToLower().IndexOf(dangerous) >= 0) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool chuakitudacbiet(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
