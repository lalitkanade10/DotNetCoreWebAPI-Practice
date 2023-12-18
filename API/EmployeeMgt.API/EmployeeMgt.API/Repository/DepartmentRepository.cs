using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EmployeeMgt.API.Data;
using EmployeeMgt.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;

namespace EmployeeMgt.API.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly EmployeeMgtDbContext _context;

        public DepartmentRepository(EmployeeMgtDbContext Context)
        {
            _context = Context;
        }

        public async Task<List<DepartmentModels>> GetAllDepartmentAsync()
        {
            var result = await _context.Department.Where(x=> x.DeleteFlag==0).Select(x => new DepartmentModels
            {
                DeptID = x.DeptID,
                DepartmentName = x.DepartmentName,
                DeleteFlag = x.DeleteFlag,
                MDate = x.MDate
            }).ToListAsync();

            return result;
        }

        public async Task<DepartmentModels> GetDepartmentByIdAsync(int DeptId)
        {
            var result = await _context.Department.Where(x=> x.DeptID==DeptId && x.DeleteFlag==0).Select(x => new DepartmentModels
            {
                DeptID = x.DeptID,
                DepartmentName = x.DepartmentName,
                DeleteFlag = x.DeleteFlag,
                MDate = x.MDate
            }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<int> AddNewDepartmentAsync(DepartmentModels departmentModels)
        {
            var NewDeprtment = new Department
            {
                DepartmentName = departmentModels.DepartmentName,
                DeleteFlag = departmentModels.DeleteFlag,
                MDate = departmentModels.MDate
            };

            _context.Department.Add(NewDeprtment);
             await _context.SaveChangesAsync();
            return NewDeprtment.DeptID;
        }

        public async Task<int> UpdateDepartmentAsync(int DeptID,DepartmentModels departmentModels)
        {
            var NewDeprtment = new Department
            {
                DeptID=DeptID,
                DepartmentName = departmentModels.DepartmentName,
                DeleteFlag = departmentModels.DeleteFlag,
                MDate = departmentModels.MDate
            };

            _context.Department.Update(NewDeprtment);
            
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteDepartmentAsync(int DeptID)
        {
            var NewDeprtment = _context.Department.Find(DeptID);
            NewDeprtment.DeleteFlag = 1;
            _context.Department.Update(NewDeprtment);

            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<DepartmentModels>> GetAllDepartmentByNameAsync(string EmpName)
        {
            var result = await _context.Department.Where(x => x.DepartmentName.StartsWith(EmpName)).Select(x => new DepartmentModels
            {
                DeptID = x.DeptID,
                DepartmentName = x.DepartmentName,
                DeleteFlag = x.DeleteFlag,
                MDate = x.MDate
            }).ToListAsync();

            return result;
        }
    }
}
