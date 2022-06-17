using System;
using System.Collections.Generic;
using System.Text;

namespace LoginDemoApp.Entity.Models
{
    public class EmployeeModel
    {
        public int EmpId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }

    }
}
