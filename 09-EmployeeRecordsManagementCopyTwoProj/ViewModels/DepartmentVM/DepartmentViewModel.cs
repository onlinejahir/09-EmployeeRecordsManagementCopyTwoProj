using System.ComponentModel.DataAnnotations;

namespace _09_EmployeeRecordsManagementCopyTwoProj.ViewModels.DepartmentVM
{
    public class DepartmentViewModel
    {
        [Display(Name = "ID")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Department name is required"), Display(Name = "Department Name")]
        [StringLength(100)]
        public string DepartmentName { get; set; }
    }
}
