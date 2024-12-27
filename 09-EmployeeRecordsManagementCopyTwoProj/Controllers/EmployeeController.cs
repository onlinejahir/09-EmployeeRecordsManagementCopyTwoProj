using _09_EmployeeRecordsManagementCopyTwoProj.ProjectModels;
using _09_EmployeeRecordsManagementCopyTwoProj.ViewModels.EmployeeVM;
using AutoMapper;
using EmployeeRecords.Models.EntityModels;
using EmployeeRecords.Services.Contracts.AllContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _09_EmployeeRecordsManagementCopyTwoProj.Controllers
{    
    public class EmployeeController : Controller
    {
        private readonly IUnitManager _unitManager;
        private readonly IMapper _mapper;
        public EmployeeController(IUnitManager unitManager, IMapper mapper)
        {
            this._unitManager = unitManager;
            this._mapper = mapper;
        }
        public async Task<IActionResult> Index(string text, string searchString, string sortOrder, int pageNumber)
        {
            ViewBag.Message = text;
            IQueryable<Employee> employees;

            if (!string.IsNullOrEmpty(searchString))
            {
                employees = _unitManager.employeeManager.SearchEmployeeResult(searchString).AsQueryable();
            }
            else
            {
                employees = _unitManager.employeeManager.GetAll().AsQueryable();
            }

            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "nameDesc" : "";
            ViewBag.DateOfBirthSortParam = sortOrder == "dateAsc" ? "dateDesc" : "dateAsc";
            ViewBag.IsActiveSortParam = sortOrder == "isActiveAsc" ? "isActiveDesc" : "isActiveAsc";

            switch (sortOrder)
            {
                case "nameDesc":
                    employees = employees.OrderByDescending(e => e.FirstName);
                    break;
                case "dateAsc":
                    employees = employees.OrderBy(e => e.DateOfBirth);
                    break;
                case "dateDesc":
                    employees = employees.OrderByDescending(e => e.DateOfBirth);
                    break;
                case "isActiveAsc":
                    employees = employees.OrderBy(e => e.IsActive);
                    break;
                case "isActiveDesc":
                    employees = employees.OrderByDescending(e => e.IsActive);
                    break;
                default:
                    employees = employees.OrderBy(e => e.FirstName);
                    break;
            }

            //Ensure page number is at least 1
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            int pageSize = 3;

            IQueryable<EmployeeViewModel> employeesVM = employees.Select(e => new EmployeeViewModel
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                DateOfBirth = e.DateOfBirth,
                Gender = e.Gender,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                Department = e.Department,
                Address = e.Address,
                IsActive = e.IsActive
            });

            return View(await PaginatedList<EmployeeViewModel>.CreateAsync(employeesVM, pageNumber, pageSize));
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            List<Department> departments = (await _unitManager.departmentManager.GetAllAsync()).ToList();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeViewModel employeeVM)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeVM);
            }
            Employee emp = _mapper.Map<Employee>(employeeVM);
            await _unitManager.employeeManager.AddEmployeeAsync(emp);
            bool isAdded = await _unitManager.SaveChangesAsync();
            if (isAdded)
            {
                return RedirectToAction("Index", "Employee");
            }
            ViewBag.Message = "Sorry! employee hasn't been added";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            List<Department> departments = (await _unitManager.departmentManager.GetAllAsync()).ToList();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName");
            Employee employee = await _unitManager.employeeManager.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                ViewBag.Message = "Sorry! there is no employee";
                return View();
            }
            EmployeeViewModel employeeVM = _mapper.Map<EmployeeViewModel>(employee);
            return View(employeeVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel employeeVM)
        {
            List<Department> departments = (await _unitManager.departmentManager.GetAllAsync()).ToList();
            ViewBag.Departments = new SelectList(departments, "DepartmentId", "DepartmentName");
            if (!ModelState.IsValid)
            {
                return View(employeeVM);
            }
            Employee employee = _mapper.Map<Employee>(employeeVM);
            _unitManager.employeeManager.UpdateEmployee(employee);
            bool isUpdated = await _unitManager.SaveChangesAsync();
            if (isUpdated)
            {
                return RedirectToAction("Index", "Employee");
            }
            ViewBag.Message = "Sorry! information hasn't been updated";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Employee employee = await _unitManager.employeeManager.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return RedirectToAction("Index", "Employee", new { text = "Sorry! there is no employee" });
            }
            _unitManager.employeeManager.RemoveEmployee(employee);
            bool isRemoved = await _unitManager.SaveChangesAsync();
            if (isRemoved)
            {
                return RedirectToAction("Index", "Employee");
            }
            return RedirectToAction("Index", "Employee", new { text = "Sorry! employee hasn't been deleted" });
        }
    }
}
