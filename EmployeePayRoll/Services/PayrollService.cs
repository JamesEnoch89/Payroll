using EmployeePayRoll.Entities;
using EmployeePayRoll.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayRoll.Services
{
    public class PayrollService
    {
        public static int PayPeriods = 26;
        EmployeePayContext db = new EmployeePayContext();

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                var employees = db.Employee.Include(i => i.DeductionType).Include(i => i.Dependent).ThenInclude(x => x.DeductionType).ToList();

                var employeeModels = employees.Select(employee =>
                    new EmployeeModel
                    {
                        Id = employee.Id,
                        Name = employee.Name,
                        PayPerPeriod = FormatDecimal(employee.PayPerPeriod),
                        GrossPay = employee.PayPerPeriod * PayPeriods,
                        DeductionPerPeriod = FormatDecimal(employee.DeductionType.DeductionAmount / PayPeriods),
                        TotalEmployeeDeductionAmount = employee.DeductionType.DeductionAmount,
                        TotalDependentDeductionAmount = employee.Dependent.Any() ? employee.Dependent.Sum(s => s.DeductionType.DeductionAmount) : 0,
                        DependentDeductionAmountPerPeriod = employee.Dependent.Any() ? FormatDecimal(employee.Dependent.Sum(s => s.DeductionType.DeductionAmount) / PayPeriods) : 0,
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
                        DeductionAmountPerPeriod = FormatDecimal(dependent.DeductionType.DeductionAmount / PayPeriods),
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

        public void DeleteEmployee(int employeeId)
        {
            var dependents = db.Dependent.Where(w => w.EmployeeId == employeeId);

            if (dependents != null)
            {
                db.Dependent.RemoveRange(dependents);
            }

            var employee = db.Employee.Where(w => w.Id == employeeId).FirstOrDefault();

            db.Employee.Remove(employee);
            db.SaveChanges();
        }

        private decimal FormatDecimal(decimal amount) 
        {
            return decimal.Round(amount, 2, MidpointRounding.AwayFromZero);
        }
    }
}
