using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAi__2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            Function function = new Function();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nMENU:");
                Console.WriteLine("1. Nhap Nhan Vien");
                Console.WriteLine("2. Tinh Luong Nhan Vien");
                Console.WriteLine("3. In toan bo danh sach nhan vien");
                Console.WriteLine("4. Thoat");
                Console.Write("Nhap lua chon cua ban: ");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                    Console.Write("Nhap lua chon cua ban: ");
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Nhap so luong nhan vien can them: ");
                        int numberOfEmployees;
                        while (!int.TryParse(Console.ReadLine(), out numberOfEmployees) || numberOfEmployees <= 0)
                        {
                            Console.WriteLine("So luong khong hop le. Vui long nhap lai.");
                            Console.Write("Nhap so luong nhan vien can them: ");
                        }

                        for (int i = 0; i < numberOfEmployees; i++)
                        {
                            Console.WriteLine($"Nhap thong tin cho nhan vien thu {i + 1}:");
                            function.AddEmployee(employees);
                        }
                        function.PrintEmployeeList(employees);
                        break;
                    case 2:
                        function.CalculateSalaries(employees);
                        break;
                    case 3:
                        function.PrintEmployeeList(employees);
                        break;
                    case 4:
                        exit = true;
                        Console.WriteLine("Chuong trinh ket thuc.");
                        break;
                }
            }
        }
    }
}
