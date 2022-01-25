using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayRoll.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public int DeductionTypeId { get; set; }
        public string Name { get; set; }
        public decimal PayPerPeriod { get; set; }
        public decimal TotalPay { get; set; }
        public decimal DeductionAmount { get; set; }
        public decimal TotalDeductionAmount { get; set; }
    }
}
