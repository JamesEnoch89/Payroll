using System;
using System.Collections.Generic;

namespace EmployeePayRoll.Entities
{
    public partial class Deduction
    {
        public Deduction()
        {
            Dependent = new HashSet<Dependent>();
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public decimal DeductionAmount { get; set; }
        public int DeductionTypeId { get; set; }

        public virtual DeductionType DeductionType { get; set; }
        public virtual ICollection<Dependent> Dependent { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
