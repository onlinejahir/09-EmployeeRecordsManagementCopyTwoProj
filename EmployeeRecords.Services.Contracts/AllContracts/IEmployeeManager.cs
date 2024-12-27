using EmployeeRecords.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecords.Services.Contracts.AllContracts
{
    public interface IEmployeeManager
    {
        Task AddEmployeeAsync(Employee employee);
        Task<Employee?> GetEmployeeByIdAsync(int? id);
        void UpdateEmployee(Employee employee);
        void RemoveEmployee(Employee employee);
        IQueryable<Employee> GetAll();
        IQueryable<Employee> SearchEmployeeResult(string searchString);
    }
}
