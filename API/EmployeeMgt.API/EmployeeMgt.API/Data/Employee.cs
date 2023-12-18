using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMgt.API.Data
{
    public class Employee:Flags
    {
        [Key]
        public int EID { get; set; }
        public string EmployeeName { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public int DeptID { get; set; }
    }
}
