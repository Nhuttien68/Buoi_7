using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAi__2
{
    public class Function
    {
        public int EnterEmployeeId(List<Employee> employees)
        {
            int id;
            while (true)
            {
                Console.Write("Nhap ma nhan vien (phai la so nguyen): ");
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    if (employees.Any(e => e.Id == id))
                    {
                        Console.WriteLine("Ma nhan vien da ton tai. Vui long nhap lai.");
                        continue;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Ma nhan vien khong hop le. Vui long nhap lai.");
                }
            }
            return id;
        }
        public string EnterEmployeeName()
        {
            string name;
            while (true)
            {
                Console.Write("Nhap ten nhan vien: ");
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name) && CheckXSSInput(name) && !chuakitudacbiet(name))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ten nhan vien khong hop le. Vui long nhap lai.");
                }
            }
            return name;
        }
        public void AddEmployee(List<Employee> employees)
        {
            Console.WriteLine("\nLoai Nhan Vien:");
            Console.WriteLine("1. Nhan Vien Toan Thoi Gian");
            Console.WriteLine("2. Nhan Vien Ban Thoi Gian");
            Console.WriteLine("3. Nhan Vien Thuc Tap");

            int typeChoiceOfEmployee;
            Console.Write("Nhap lua chon cua ban: ");

            while (!int.TryParse(Console.ReadLine(), out typeChoiceOfEmployee) || typeChoiceOfEmployee < 1 || typeChoiceOfEmployee > 3)
            {
                Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                Console.Write("Nhap lua chon cua ban: ");
            }

            Employee employee = null;

            switch (typeChoiceOfEmployee)
            {
                case 1:
                    employee = new FullTimeEmployee();
                    employee.Name = EnterEmployeeName();
                    employee.Id = EnterEmployeeId(employees);
                    ((FullTimeEmployee)employee).MonthlySalary = EnterEmployeeMonthlySalary();
                    break;
                case 2:
                    employee = new PartTimeEmployee();
                    employee.Name = EnterEmployeeName();
                    employee.Id = EnterEmployeeId(employees);
                    ((PartTimeEmployee)employee).HourlyRate = EnterEmployeeHourlyRate();
                    ((PartTimeEmployee)employee).HoursWorked = EnterEmployeeHoursWorked();
                    break;
                case 3:
                    employee = new Intern();
                    employee.Name = EnterEmployeeName();
                    employee.Id = EnterEmployeeId(employees);
                    ((Intern)employee).MonthlyAllowance = EnterEmployeeMonthlyAllowance();
                    break;
            }

            employees.Add(employee);
            Console.WriteLine("Nhan vien da duoc them thanh cong.");
        }

        public decimal EnterEmployeeMonthlySalary()
        {
            decimal salary;
            while (true)
            {
                Console.Write("Nhap luong hang thang: ");
                if (decimal.TryParse(Console.ReadLine(), out salary))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Luong khong hop le. Vui long nhap lai.");
                }
            }
            return salary;
        }

        public decimal EnterEmployeeHourlyRate()
        {
            decimal rate;
            while (true)
            {
                Console.Write("Nhap muc luong moi gio: ");
                if (decimal.TryParse(Console.ReadLine(), out rate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Muc luong khong hop le. Vui long nhap lai.");
                }
            }
            return rate;
        }

        public decimal EnterEmployeeHoursWorked()
        {
            decimal hours;
            while (true)
            {
                Console.Write("Nhap so gio lam viec: ");
                if (decimal.TryParse(Console.ReadLine(), out hours))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("So gio lam viec khong hop le. Vui long nhap lai.");
                }
            }
            return hours;
        }

        public decimal EnterEmployeeMonthlyAllowance()
        {
            decimal allowance;
            while (true)
            {
                Console.Write("Nhap phu cap hang thang: ");
                if (decimal.TryParse(Console.ReadLine(), out allowance))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Phu cap khong hop le. Vui long nhap lai.");
                }
            }
            return allowance;
        }


        public void CalculateSalaries(List<Employee> employees)
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("Danh sach nhan vien rong. Vui long them nhan vien truoc khi tinh luong.");
                return;
            }

            Console.WriteLine("\nLuong cua tung nhan vien:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"Ten: {employee.Name}, Ma NV: {employee.Id}, Luong: {employee.CalculateSalary()}");
            }
        }
        public void PrintEmployeeList(List<Employee> employees)
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("Danh sach nhan vien rong.");
                return;
            }

            Console.WriteLine("\nDanh sach nhan vien:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"Ten: {employee.Name}, Ma NV: {employee.Id}");
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
    }
}
