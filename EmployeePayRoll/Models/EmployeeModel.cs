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
        public decimal GrossPay { get; set; }
        public string FormattedTotalPay { get; set; }
        public decimal DeductionPerPeriod { get; set; }
        public decimal TotalEmployeeDeductionAmount { get; set; }
        public decimal TotalDependentDeductionAmount { get; set; }
        public decimal DependentDeductionAmountPerPeriod { get; set; }
        public string FormattedTotalDeductionAmount { get; set; }
        public bool HasDependent { get; set; }
        public IEnumerable<DependentModel> Dependents { get; set; }
    }
}
