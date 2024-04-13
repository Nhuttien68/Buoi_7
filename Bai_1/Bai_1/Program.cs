using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1
{
    internal class Program
    {
        private Library library;
        private Function functions;

        public Program(Library library)
        {
            this.library = library;
            this.functions = new Function();
        }
        static void Main(string[] args)
        {
            Library library = new Library();
            Program program = new Program(library);
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nMENU:");
                Console.WriteLine("1. Them sach moi:");
                Console.WriteLine("2. Tìm kiếm theo tên tac gia");
                Console.WriteLine("3. Tim kiếm theo ISBN");
                Console.WriteLine("4. Muon sach");
                Console.WriteLine("5. Tra sach");
                Console.WriteLine("6. thoat");
                Console.Write("Moi nhap lua chon: ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
                {
                    Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                    Console.Write("Nhap lua chon cua ban: ");
                }

                switch (choice)
                {
                    case 1:
                        program.functions.addBook(program.library);
                        break;
                    case 2:
                        program.functions.searchBookByAuthor(program.library);
                        break;
                    case 3:
                        program.functions.searchBookByISBN(program.library);
                        break;
                    case 4:
                        program.functions.borrowBook(program.library);
                        break;
                    case 5:
                        program.functions.returnBook(program.library);
                        break;
                    case 6:
                        exit = true;
                        Console.WriteLine("Chuong trinh ket thuc.");
                        break;
                }
            }
        }

    }
}
