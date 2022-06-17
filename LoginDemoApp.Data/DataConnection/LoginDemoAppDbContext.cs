using LoginDemoApp.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginDemoApp.Data.DataConnection
{
    public class LoginDemoAppDbContext : DbContext
    {
        public LoginDemoAppDbContext(DbContextOptions<LoginDemoAppDbContext> options):base(options)
        {

        }

        public DbSet<EmployeeModel> EmpModel { get; set; }
    }
}
