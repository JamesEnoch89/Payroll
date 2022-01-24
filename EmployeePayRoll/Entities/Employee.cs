using System;
using System.Collections.Generic;

namespace EmployeePayRoll.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Dependent = new HashSet<Dependent>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PayPerPeriod { get; set; }
        public int DeductionId { get; set; }

        public virtual Deduction Deduction { get; set; }
        public virtual ICollection<Dependent> Dependent { get; set; }
    }
}
