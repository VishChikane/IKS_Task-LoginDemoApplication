using LoginDemoApp.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginDemoApp.Data.Repository
{
    public class Employee : IEmployee
    {
        public EmployeeModel Login(EmployeeModel emp)
        {
            EmployeeModel currentEmp = null;
            currentEmp = EmpConstantData.Users.FirstOrDefault(e => e.Email.ToLower() == emp.Email.ToLower() && e.Password == emp.Password);
            if (currentEmp != null)
                return currentEmp;
            return currentEmp;
        }

        public List<EmployeeModel> SelectEmployees()
        {
            return EmpConstantData.Users.ToList();
        }
    }
}
