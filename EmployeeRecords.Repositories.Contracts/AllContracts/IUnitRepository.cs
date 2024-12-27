using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecords.Repositories.Contracts.AllContracts
{
    public interface IUnitRepository : IDisposable, IAsyncDisposable
    {
        IEmployeeRepository employeeRepository { get; }
        IDepartmentRepository departmentRepository { get; }
        Task<bool> SaveChangesAsync();
    }
}
