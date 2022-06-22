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

        public string Delete(int empId)
        {
            EmployeeModel currentEmp = _loginDemoAppDbContext.EmpModel.Find(empId);
            if (currentEmp == null)
                return "Employee Not Found";
            _loginDemoAppDbContext.Entry(currentEmp).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _loginDemoAppDbContext.SaveChanges();
            return "Deleted Succesfully..!";
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

        public EmployeeModel SelectEmpById(int empId)
        {
            EmployeeModel currentUser = _loginDemoAppDbContext.EmpModel.Find(empId);
            if(currentUser == null)
                return null;
            return currentUser;
        }

        public List<EmployeeModel> SelectEmployees()
        {
            return _loginDemoAppDbContext.EmpModel.ToList();
        }

        public string Update(EmployeeModel employee)
        {
            _loginDemoAppDbContext.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _loginDemoAppDbContext.SaveChanges();
            return "Updated Succesfully..!";
        }

    }
}
