using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMgt.API.Models;
using EmployeeMgt.API.Data;

namespace EmployeeMgt.API.Repository
{
    public interface IDepartmentRepository
    {
        Task<List<DepartmentModels>> GetAllDepartmentAsync();
        Task<DepartmentModels> GetDepartmentByIdAsync(int DeptId);
        Task<int> AddNewDepartmentAsync(DepartmentModels departmentModels);
        Task<int> UpdateDepartmentAsync(int DeptID, DepartmentModels departmentModels);
        Task<int> DeleteDepartmentAsync(int DeptID);
        Task<List<DepartmentModels>> GetAllDepartmentByNameAsync(string EmpName);
    }
}
