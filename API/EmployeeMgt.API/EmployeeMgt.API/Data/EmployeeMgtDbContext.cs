using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMgt.API.Data
{
    public class EmployeeMgtDbContext : DbContext
    {
        public EmployeeMgtDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}
