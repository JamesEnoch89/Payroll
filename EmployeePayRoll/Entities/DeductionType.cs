using System;
using System.Collections.Generic;

namespace EmployeePayRoll.Entities
{
    public partial class DeductionType
    {
        public DeductionType()
        {
            Dependent = new HashSet<Dependent>();
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string DeductionName { get; set; }
        public string DeductionCode { get; set; }
        public decimal DeductionAmount { get; set; }

        public virtual ICollection<Dependent> Dependent { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
