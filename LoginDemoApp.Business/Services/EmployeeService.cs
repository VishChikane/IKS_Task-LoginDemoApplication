using LoginDemoApp.Data.Repository;
using LoginDemoApp.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginDemoApp.Business.Services
{
    public class EmployeeService
    {
        private readonly IEmployee _employee;
        public EmployeeService(IEmployee employee)
        {
            _employee = employee;
        }

        public List<EmployeeModel> SelectEmployees()
        {
            return _employee.SelectEmployees();
        }

        public EmployeeModel Login(EmployeeModel emp)
        {
            return _employee.Login(emp);
        }

        public string Register(EmployeeModel emp)
        {
            return _employee.Register(emp);
        }

        public object SelectEmpById(int empId)
        {
            return _employee.SelectEmpById(empId);
        }

        public object Update(EmployeeModel employee)
        {
            return _employee.Update(employee);
        }

        public object Delete(int empId)
        {
            return _employee.Delete(empId);
        }
    }
}
