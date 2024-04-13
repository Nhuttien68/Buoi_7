using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAi__2
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public abstract decimal CalculateSalary();
    }
}
