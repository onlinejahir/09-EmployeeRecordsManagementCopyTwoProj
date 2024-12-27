using EmployeeRecords.Database.Data;
using EmployeeRecords.Models.EntityModels;
using EmployeeRecords.Repositories.Contracts.AllContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecords.Repositories.AllRepositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public override IQueryable<Employee> GetAll()
        {
            return _dbContext.Employees
                .Include(e => e.Department).AsQueryable();
        }
    }
}
