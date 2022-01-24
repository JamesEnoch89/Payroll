using System;
using System.Collections.Generic;

namespace EmployeePayRoll.Entities
{
    public partial class Dependent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public int DeductionId { get; set; }

        public virtual Deduction Deduction { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
