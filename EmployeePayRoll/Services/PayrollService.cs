using EmployeePayRoll.Entities;
using EmployeePayRoll.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


//To Do
// If time allots create generic 'BenefitMember' Interface
// Both Employees and Dependents will use the same methods
// Would need to adjust data model to have a 'BenefitMemberType' to pass in to IBenefitMember
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
                        PayPerPeriod = decimal.Round(employee.PayPerPeriod / payPeriods, 2, MidpointRounding.AwayFromZero),
                        FormattedTotalPay = (employee.PayPerPeriod * payPeriods).ToString("n", CultureInfo.GetCultureInfo("en-US")),
                        TotalPay = employee.PayPerPeriod * payPeriods,
                        DeductionPerPeriod = decimal.Round(employee.DeductionType.DeductionAmount / payPeriods, 2, MidpointRounding.AwayFromZero),
                        TotalDeductionAmount = employee.DeductionType.DeductionAmount,
                        FormattedTotalDeductionAmount = (employee.DeductionType.DeductionAmount).ToString("n", CultureInfo.GetCultureInfo("en-US")),
                        DeductionTypeId = employee.DeductionType.Id,
                        HasDependent = employee.Dependent.Any()
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
            var standardEmpDeduction = deductionTypes.Where(w => w.DeductionCode == "STND").Select(s => s.Id).FirstOrDefault();
            var specialEmpDeduction = deductionTypes.Where(w => w.DeductionCode == "SPE").Select(s => s.Id).FirstOrDefault();

            try
            {
                var deductionTypeId = employeeModel.Name.ToLower().StartsWith('a')
                    ? specialEmpDeduction
                    : standardEmpDeduction;

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

        public IEnumerable<DependentModel> AddDependent(DependentModel dependentModel)
        {
            var deductionTypes = db.DeductionType.ToList();
            var standardDepDeduction = deductionTypes.Where(w => w.DeductionCode == "STNDT").Select(s => s.Id).FirstOrDefault();
            var specialDepDeduction = deductionTypes.Where(w => w.DeductionCode == "SPD").Select(s => s.Id).FirstOrDefault();

            try
            {
                var deductionTypeId = dependentModel.Name.ToLower().StartsWith('a')
                    ? specialDepDeduction
                    : standardDepDeduction;

                var dependent = new Dependent()
                {
                    Name = dependentModel.Name,
                    DeductionTypeId = deductionTypeId,
                    EmployeeId = dependentModel.EmployeeId,
                };

                db.Dependent.Add(dependent);
                db.SaveChanges();
                return GetDependentsByEmployeeId(dependent.EmployeeId);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<DependentModel> GetDependentsByEmployeeId(int employeeId)
        {
            var payPeriods = 26;

            try
            {
                var dependents = db.Dependent.Include(i => i.DeductionType).Include(i => i.Employee).Where(w => w.EmployeeId == employeeId).ToList();

                var dependentModels = dependents.Select(dependent =>
                    new DependentModel
                    {
                         DependentId = dependent.Id,
                         EmployeeId = dependent.EmployeeId,
                         DeductionTypeId = dependent.DeductionTypeId,
                         DeductionAmount = dependent.DeductionType.DeductionAmount,
                         Name = dependent.Name,
                         EmployeeName = dependent.Employee.Name
                    });

                return dependentModels;
            }
            catch
            {
                throw;
            }
        }
    }
}
