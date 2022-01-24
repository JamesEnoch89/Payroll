using System;
using System.Collections.Generic;

namespace EmployeePayRoll.Entities
{
    public partial class DeductionType
    {
        public DeductionType()
        {
            Deduction = new HashSet<Deduction>();
        }

        public int Id { get; set; }
        public string DeductionName { get; set; }
        public string DeductionCode { get; set; }

        public virtual ICollection<Deduction> Deduction { get; set; }
    }
}
