using EmployeePayRoll.Entities;
using EmployeePayRoll.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                var employees = db.Employee.Include(i => i.Deduction).Include(i => i.Deduction.DeductionType).Include(i => i.Dependent).ToList();

                var employeeModels = employees.Select(employee =>
                    new EmployeeModel
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        PayPerPeriod = employee.PayPerPeriod,
                        TotalPay = employee.PayPerPeriod * payPeriods,
                        Deduction = new DeductionModel
                        {
                            DeductionId = employee.Deduction.Id,
                            DeductionAmount = employee.Deduction.DeductionAmount,
                            TotalDeductionAmount = employee.Deduction.DeductionAmount * payPeriods,
                            DeductionType = new IdCodeNameModel
                            {
                                Id = employee.Deduction.DeductionType.Id,
                                Code = employee.Deduction.DeductionType.DeductionCode,
                                Name = employee.Deduction.DeductionType.DeductionName
                            }
                        }
                    });

                return employeeModels;
            }
            catch
            {
                throw;
            }
        }

    }
}
