using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using EmployeeRecords.Models.EntityModels;

namespace _09_EmployeeRecordsManagementCopyTwoProj.ViewModels.EmployeeVM
{
    public class EmployeeViewModel
    {
        [Display(Name = "ID")]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "First name is required"), Display(Name = "First Name")]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required"), Display(Name = "Last Name")]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Date of Birth is required"), Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [StringLength(10, ErrorMessage = "Gender should be 'Male', 'Female' or other valid identifiers.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Email address is required"), StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required"), Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required, Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        //Relationship with department
        [ForeignKey("Department")]
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; } //Foreign key
        public Department? Department { get; set; } //Rederence navigation property
    }
}
