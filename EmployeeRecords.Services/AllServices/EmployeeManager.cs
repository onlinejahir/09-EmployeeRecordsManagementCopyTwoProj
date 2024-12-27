using EmployeeRecords.Models.EntityModels;
using EmployeeRecords.Repositories.Contracts.AllContracts;
using EmployeeRecords.Services.Contracts.AllContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecords.Services.AllServices
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IUnitRepository _unitRepository;
        public EmployeeManager(IUnitRepository unitRepository)
        {
            this._unitRepository = unitRepository;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _unitRepository.employeeRepository.AddAsync(employee);
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int? id)
        {
            return await _unitRepository.employeeRepository.GetByIdAsync(id);
        }

        public void UpdateEmployee(Employee employee)
        {
            _unitRepository.employeeRepository.Update(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            _unitRepository.employeeRepository.Remove(employee);
        }

        public IQueryable<Employee> GetAll()
        {
            return _unitRepository.employeeRepository.GetAll();
        }

        public IQueryable<Employee> SearchEmployeeResult(string searchString)
        {
            IQueryable<Employee> employees = _unitRepository.employeeRepository.GetAll();
            employees = employees.Where(e => e.FirstName.Contains(searchString) || e.LastName.Contains(searchString));
            return employees;
        }
    }
}
