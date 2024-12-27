using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecords.Models.EntityModels
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required, DataType(DataType.Date)]
        public string Gender { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public bool IsActive { get; set; }
        //Relationship with department
        [ForeignKey("Department")]
        public int DepartmentId { get; set; } //Foreign key
        public Department Department { get; set; } //Reference navigation property
    }
}
