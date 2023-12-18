using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMgt.API.Data
{    
    public class Flags
    {          
        public int DeleteFlag { get; set; }
        public DateTime MDate { get; set; }
    }
}
