using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

using EmployeeMgt.API.Data;
using EmployeeMgt.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMgt.API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeMgtDbContext _context;

        public EmployeeRepository(EmployeeMgtDbContext Context)
        {
            _context = Context;
        }              

        public async Task<List<EmployeeModels>> GetAllEmployeeAsync()
        {          
            var result = await (from emp in _context.Employee
                                 join dept in _context.Department on emp.DeptID equals dept.DeptID
                                 where emp.DeleteFlag == 0
                                 select new EmployeeModels()
                                 {
                                     EID = emp.EID,
                                     EmployeeName = emp.EmployeeName,
                                     EmailID = emp.EmailID,
                                     Address = emp.Address,
                                     Salary = emp.Salary,
                                     DeptID = emp.DeptID,
                                     DepartmentName = dept.DepartmentName,
                                     DeleteFlag = emp.DeleteFlag,
                                     MDate = emp.MDate

                                 }).ToListAsync();

            return result;
        }

        public async Task<EmployeeModels> GetEmployeeByIdAsync(int EID)
        {
            var result = await (from emp in _context.Employee
                                join dept in _context.Department on emp.DeptID equals dept.DeptID
                                where emp.DeleteFlag == 0 && emp.EID==EID
                                select new EmployeeModels()
                                {
                                    EID = emp.EID,
                                    EmployeeName = emp.EmployeeName,
                                    EmailID = emp.EmailID,
                                    Address = emp.Address,
                                    Salary = emp.Salary,
                                    DeptID = emp.DeptID,
                                    DepartmentName = dept.DepartmentName,
                                    DeleteFlag = emp.DeleteFlag,
                                    MDate = emp.MDate

                                }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<List<EmployeeModels>> GetAllEmployeeByDeptIdAsync(int DeptID)
        {
            var result = await (from emp in _context.Employee
                                join dept in _context.Department on emp.DeptID equals dept.DeptID
                                where emp.DeleteFlag == 0 && emp.DeptID == DeptID
                                select new EmployeeModels()
                                {
                                    EID = emp.EID,
                                    EmployeeName = emp.EmployeeName,
                                    EmailID = emp.EmailID,
                                    Address = emp.Address,
                                    Salary = emp.Salary,
                                    DeptID = emp.DeptID,
                                    DepartmentName = dept.DepartmentName,
                                    DeleteFlag = emp.DeleteFlag,
                                    MDate = emp.MDate

                                }).ToListAsync();

            return result;
        }

        public async Task<int> AddNewEmployeeAsync(EmployeeModels employeeModels)
        {
            var NewEmployee = new Employee
            {
                EID = employeeModels.EID,
                EmployeeName = employeeModels.EmployeeName,
                EmailID = employeeModels.EmailID,
                Address = employeeModels.Address,
                Salary = employeeModels.Salary,
                DeptID = employeeModels.DeptID,
                DeleteFlag = employeeModels.DeleteFlag,
                MDate = employeeModels.MDate

            };

            _context.Employee.Add(NewEmployee);
            await _context.SaveChangesAsync();
            return NewEmployee.EID;
        }

        public async Task<int> UpdateEmployeeByIdAsync(int id,EmployeeModels employeeModels)
        {
            var NewEmployee = new Employee
            {
                EID = id,
                EmployeeName = employeeModels.EmployeeName,
                EmailID = employeeModels.EmailID,
                Address = employeeModels.Address,
                Salary = employeeModels.Salary,
                DeptID = employeeModels.DeptID,
                DeleteFlag = employeeModels.DeleteFlag,
                MDate = employeeModels.MDate
            };

            _context.Employee.Update(NewEmployee);
             return await _context.SaveChangesAsync(); 
        }

        public async Task<int> DeleteEmployeeByIdAsync(int id)
        {
            var NewEmp = _context.Employee.Find(id);
            NewEmp.DeleteFlag = 1;
            _context.Employee.Update(NewEmp);

            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteEmployeeByDeptIdAsync(int DeptId)
        {
            var result = await (from emp in _context.Employee
                                join dept in _context.Department on emp.DeptID equals dept.DeptID
                                where emp.DeleteFlag == 0 && emp.DeptID == DeptId
                                select new EmployeeModels()
                                {
                                    EID = emp.EID
                                }).ToListAsync();

            if (result != null)
            {
                foreach (EmployeeModels obj in result)
                {
                    var NewEmp = _context.Employee.Find(obj.EID);
                    NewEmp.DeleteFlag = 1;
                    _context.Employee.Update(NewEmp);
                    await _context.SaveChangesAsync();
                }
                return 1;
            }
            else
            {
                return 0;
            }            
        }

        public async Task<List<EmployeeModels>> GetAllEmployeeByNameAsync(string EmpName)
        {
            var result = await (from emp in _context.Employee
                                join dept in _context.Department on emp.DeptID equals dept.DeptID
                                where emp.DeleteFlag == 0 && emp.EmployeeName.StartsWith(EmpName)
                                select new EmployeeModels()
                                {
                                    EID = emp.EID,
                                    EmployeeName = emp.EmployeeName,
                                    EmailID = emp.EmailID,
                                    Address = emp.Address,
                                    Salary = emp.Salary,
                                    DeptID = emp.DeptID,
                                    DepartmentName = dept.DepartmentName,
                                    DeleteFlag = emp.DeleteFlag,
                                    MDate = emp.MDate

                                }).ToListAsync();

            return result;
        }


    }
}
