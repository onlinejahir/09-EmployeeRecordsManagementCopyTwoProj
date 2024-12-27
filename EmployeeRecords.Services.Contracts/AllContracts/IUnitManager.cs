using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecords.Services.Contracts.AllContracts
{
    public interface IUnitManager : IDisposable, IAsyncDisposable
    {
        IEmployeeManager employeeManager { get; }
        IDepartmentManager departmentManager { get; }
        Task<bool> SaveChangesAsync();
    }
}
