using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayRoll.Models
{
    public class DeductionModel
    {
        public int DeductionId { get; set; }
        public decimal DeductionAmount { get; set; }
        public decimal TotalDeductionAmount { get; set; }
        public IdCodeNameModel DeductionType { get; set; }
    }
}
