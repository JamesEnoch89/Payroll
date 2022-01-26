using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayRoll.Models
{
    public class DependentModel
    {
        public int DependentId { get; set; }
        public int EmployeeId { get; set; }
        public int DeductionTypeId { get; set; }
        public decimal DeductionAmount { get; set; }
        public string Name { get; set; }
        public string EmployeeName { get; set; }
    }
}
