using _09_EmployeeRecordsManagementCopyTwoProj.ViewModels.DepartmentVM;
using AutoMapper;
using EmployeeRecords.Models.EntityModels;
using EmployeeRecords.Services.Contracts.AllContracts;
using Microsoft.AspNetCore.Mvc;

namespace _09_EmployeeRecordsManagementCopyTwoProj.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitManager _unitManager;
        private readonly IMapper _mapper;
        public DepartmentController(IUnitManager unitManager, IMapper mapper)
        {
            this._unitManager = unitManager;
            this._mapper = mapper;
        }
        public async Task<IActionResult> Index(string text)
        {
            ViewBag.Message = text;
            List<Department> departments = (await _unitManager.departmentManager.GetAllAsync()).ToList();
            List<DepartmentViewModel> departmentsVM = _mapper.Map<List<DepartmentViewModel>>(departments);
            return View(departmentsVM);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(DepartmentViewModel departmentVM)
        {
            if (!ModelState.IsValid)
            {
                return View(departmentVM);
            }
            Department dpt = _mapper.Map<Department>(departmentVM);
            await _unitManager.departmentManager.AddAsync(dpt);
            bool isAdded = await _unitManager.SaveChangesAsync();
            if (isAdded)
            {
                return RedirectToAction("Index", "Department");
            }
            else
            {
                ViewBag.Message = "Sorry! department hasn't been added";
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Department department = await _unitManager.departmentManager.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                ViewBag.Message = "Sorry! there is no department";
                return View();
            }
            DepartmentViewModel departmentVM = _mapper.Map<DepartmentViewModel>(department);
            return View(departmentVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentViewModel departmentVM)
        {
            if (!ModelState.IsValid)
            {
                return View(departmentVM);
            }
            Department department = _mapper.Map<Department>(departmentVM);
            _unitManager.departmentManager.UpdateDepartment(department);
            bool isUpdated = await _unitManager.SaveChangesAsync();
            if (isUpdated)
            {
                return RedirectToAction("Index", "Department");
            }
            ViewBag.Message = "Sorry! information hasn't been updated";
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            Department department = await _unitManager.departmentManager.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return RedirectToAction("Index", "Department", new { text = "Sorry! there is no department" });
            }
            _unitManager.departmentManager.RemoveDepartment(department);
            bool isRemoved = await _unitManager.SaveChangesAsync();
            if (isRemoved)
            {
                return RedirectToAction("Index", "Department");
            }
            return RedirectToAction("Index", "Department", new { text = "Sorry! Department hasn't been deleted" });
        }
    }
}
