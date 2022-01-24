//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using PayRoll.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using static EmployeePayRoll.Models.EmployeeService;

//namespace EmployeePayRoll.Controllers
//{
//    [Route("api/payroll")]
//    [ApiController]
//    public class PayrollController : ControllerBase
//    {
//        PayrollService _service = new PayrollService();

//        [HttpGet]
//        [Route("get/employees")]
//        public IEnumerable<EmployeeModel> GetAllEmployees()
//        {
//            return _service.GetAllEmployees();
//        }
//    }
//}
