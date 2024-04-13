using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAi__2
{
    public class FullTimeEmployee : Employee
    {
        public decimal MonthlySalary { get; set; }

        public override decimal CalculateSalary()
        {
            return MonthlySalary;
        }
    }
}
