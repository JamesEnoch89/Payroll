using EmployeePayRoll.Models;
using EmployeePayRoll.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeePayRoll.Controllers
{
    [Route("api/payroll")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        PayrollService _service = new PayrollService();

        [HttpGet]
        [Route("get/employees")]
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            return _service.GetAllEmployees();
        }

        [HttpPost]
        [Route("create/employee")]
        public IEnumerable<EmployeeModel> CreateEmployee([FromBody] EmployeeModel employeeModel)
        {
            return _service.AddEmployee(employeeModel);
        }

        [HttpPost]
        [Route("create/dependent")]
        public IEnumerable<DependentModel> CreateDependent([FromBody] DependentModel dependentModel)
        {
            return _service.AddDependent(dependentModel);
        }

        [HttpGet]
        [Route("get/employee/{employeeId}/dependents")]
        public IActionResult GetDependentsByEmployeeId(int employeeId)
        {
            return Ok(_service.GetDependentsByEmployeeId(employeeId));
        }

        [HttpDelete]
        [Route("delete/employee/{employeeId}")]
        public int DeleteEmployee(int employeeId)
        {
            return _service.DeleteEmployee(employeeId);
        }
    }
}
