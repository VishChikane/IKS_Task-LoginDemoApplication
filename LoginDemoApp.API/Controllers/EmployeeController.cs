using LoginDemoApp.Business.Services;
using LoginDemoApp.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginDemoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("SelectEmployees")]
        public IActionResult SelectEmployees()
        {
            return Ok(_employeeService.SelectEmployees());
        }

        [HttpPost("Login")]
        public IActionResult Login(EmployeeModel emp)
        {
            return Ok(_employeeService.Login(emp));
        }
    }
}
