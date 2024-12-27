using EmployeeRecords.Repositories.Contracts.AllContracts;
using EmployeeRecords.Services.Contracts.AllContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecords.Services.AllServices
{
    public class UnitManager : IUnitManager
    {
        private readonly IUnitRepository _unitRepository;

        public UnitManager(IUnitRepository unitRepository)
        {
            this._unitRepository = unitRepository;
        }

        public IEmployeeManager employeeManager => new EmployeeManager(this._unitRepository);

        public IDepartmentManager departmentManager => new DepartmentManager(this._unitRepository);

        public async Task<bool> SaveChangesAsync()
        {
            return await _unitRepository.SaveChangesAsync();
        }

        public void Dispose()
        {
            _unitRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            if (_unitRepository is IAsyncDisposable asyncDisposableRepo)
            {
                await asyncDisposableRepo.DisposeAsync();  // Dispose asynchronously
            }
            else
            {
                _unitRepository.Dispose();  // Fallback to synchronous disposal
            }

            GC.SuppressFinalize(this);
        }
    }
}
