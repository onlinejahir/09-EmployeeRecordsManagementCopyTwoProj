using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecords.Models.EntityModels
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        //Relationship with employees
        public ICollection<Employee> Employees { get; set; } //Collection navigation property
    }
}
