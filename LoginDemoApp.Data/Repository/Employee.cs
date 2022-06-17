using LoginDemoApp.Data.DataConnection;
using LoginDemoApp.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginDemoApp.Data.Repository
{
    public class Employee : IEmployee
    {
        private readonly LoginDemoAppDbContext _loginDemoAppDbContext;

        public Employee(LoginDemoAppDbContext loginDemoAppDbContext)
        {
            _loginDemoAppDbContext = loginDemoAppDbContext;
        }
        public EmployeeModel Login(EmployeeModel emp)
        {
            EmployeeModel currentEmp = null;
            currentEmp = _loginDemoAppDbContext.EmpModel.FirstOrDefault(e => e.Email.ToLower() == emp.Email.ToLower() && e.Password == emp.Password);
            if (currentEmp != null)
                return currentEmp;
            return currentEmp;
        }

        public string Register(EmployeeModel emp)
        {
            _loginDemoAppDbContext.EmpModel.Add(emp);
            _loginDemoAppDbContext.SaveChanges();
            return "Employee Registered Succesfully !";
        }

        public List<EmployeeModel> SelectEmployees()
        {
            return _loginDemoAppDbContext.EmpModel.ToList();
        }
    }
}
