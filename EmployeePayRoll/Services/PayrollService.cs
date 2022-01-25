using EmployeePayRoll.Entities;
using EmployeePayRoll.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayRoll.Services
{
    public class PayrollService
    {
        EmployeePayContext db = new EmployeePayContext();

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            var payPeriods = 26;

            try
            {
                var employees = db.Employee.Include(i => i.DeductionType).Include(i => i.Dependent).ToList();

                var employeeModels = employees.Select(employee =>
                    new EmployeeModel
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        PayPerPeriod = employee.PayPerPeriod,
                        TotalPay = employee.PayPerPeriod * payPeriods,
                        DeductionAmount = employee.DeductionType.DeductionAmount,
                        TotalDeductionAmount = employee.DeductionType.DeductionAmount * payPeriods,
                        DeductionTypeId = employee.DeductionType.Id
                    });

                return employeeModels;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<EmployeeModel> AddEmployee(EmployeeModel employeeModel)
        {
            var payAmount = 2000;
            var deductionTypes = db.DeductionType.ToList();

            try
            {
                var deductionTypeId = employeeModel.Name.ToLower().StartsWith('a')
                    ? deductionTypes.Where(w => w.DeductionCode == "NAME").Select(s => s.Id).FirstOrDefault()
                    : deductionTypes.Where(w => w.DeductionCode == "STND").Select(s => s.Id).FirstOrDefault();

                var employee = new Employee()
                {
                    Name = employeeModel.Name,
                    PayPerPeriod = 2000,
                    DeductionTypeId = deductionTypeId
                };

                db.Employee.Add(employee);
                db.SaveChanges();
                return GetAllEmployees();
            }
            catch
            {
                throw;
            }
        }

    }
}
