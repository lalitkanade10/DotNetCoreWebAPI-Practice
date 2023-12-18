using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMgt.API.Data
{
    public class Department:Flags
    {
        [Key]
        public int DeptID { get; set; }
        public string DepartmentName { get; set; }
    }
}
