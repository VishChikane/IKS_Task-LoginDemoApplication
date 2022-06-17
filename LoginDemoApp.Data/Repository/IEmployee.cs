using LoginDemoApp.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginDemoApp.Data.Repository
{
    public interface IEmployee
    {
        public List<EmployeeModel> SelectEmployees();
        public EmployeeModel Login(EmployeeModel emp);
        string Register(EmployeeModel emp);
    }
}
