using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMgt.API.Models;

namespace EmployeeMgt.API.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeModels>> GetAllEmployeeAsync();
        Task<EmployeeModels> GetEmployeeByIdAsync(int EID);
        Task<List<EmployeeModels>> GetAllEmployeeByDeptIdAsync(int DeptID);
        Task<int> AddNewEmployeeAsync(EmployeeModels employeeModels);

        Task<int> UpdateEmployeeByIdAsync(int id, EmployeeModels employeeModels);

        Task<int> DeleteEmployeeByIdAsync(int id);
        Task<int> DeleteEmployeeByDeptIdAsync(int DeptId);
        Task<List<EmployeeModels>> GetAllEmployeeByNameAsync(string EmpName);

    }
}
