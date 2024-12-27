using EmployeeRecords.Database.Data;
using EmployeeRecords.Repositories.Contracts.AllContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecords.Repositories.AllRepositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UnitRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEmployeeRepository employeeRepository => new EmployeeRepository(this._dbContext);

        public IDepartmentRepository departmentRepository => new DepartmentRepository(this._dbContext);

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            if (this._dbContext != null)
            {
                await this._dbContext.DisposeAsync();
                GC.SuppressFinalize(this);
            }
        }
    }
}
