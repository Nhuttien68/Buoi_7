using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAi__2
{
    public class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; set; }
        public decimal HoursWorked { get; set; }

        public override decimal CalculateSalary()
        {
            return (decimal)(HourlyRate * HoursWorked);
        }
    }
}
