using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMgt.API.Models
{
    public class FlagsModels
    {
        public FlagsModels()
        {
            DeleteFlag = 0;
            MDate = System.DateTime.Now;
        }

        public int DeleteFlag { get; set; }
        public DateTime MDate { get; set; }
    }
}
