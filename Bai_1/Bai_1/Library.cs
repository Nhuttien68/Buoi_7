using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1
{
    public class Library
    {
        private List<Book> books = new List<Book>();

        public void addBook(Book book)
        {
            books.Add(book);
            Console.WriteLine("sach da đc them thanh cong");
        }

        public Book searchByAuthor(string author)
        {
            foreach (Book book in books) {
                if (book.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
                {
                    return book;
                }
            }
            Console.WriteLine("khong tim thay sach co ten tac gia" + author);
            return null;
        }
        public Book searchByISBN(string isbn)
        {
            foreach (Book book in books)
            {
                if (book.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase))
                {
                    return book;
                }
            }
            Console.WriteLine("khong có sach voi ma ISBN" + isbn); ;
            return null;     
        }
        public void borrowBook(string isbn) 
        {
             Book book = searchByISBN (isbn);
            if(book != null)
            {
                Console.WriteLine($"da muon sach thanh cong '{book.Title}'");
                books.Remove(book);
            }
        }
        public void returnBook(Book book)
        {
            books.Add (book);
            Console.WriteLine("sach da dc tra thanh cong");
        }
    }
}
