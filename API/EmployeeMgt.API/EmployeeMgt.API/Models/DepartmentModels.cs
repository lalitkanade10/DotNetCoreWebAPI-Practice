using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMgt.API.Models
{
    public class DepartmentModels:FlagsModels
    {
        public int DeptID { get; set; }
        public string? DepartmentName { get; set; }
    }
}
