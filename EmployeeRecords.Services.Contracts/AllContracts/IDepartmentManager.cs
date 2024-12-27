using EmployeeRecords.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecords.Services.Contracts.AllContracts
{
    public interface IDepartmentManager
    {
        Task AddAsync(Department department);
        Task<Department?> GetDepartmentByIdAsync(int? id);
        void UpdateDepartment(Department department);
        void RemoveDepartment(Department department);
        Task<IEnumerable<Department>> GetAllAsync();
    }
}
