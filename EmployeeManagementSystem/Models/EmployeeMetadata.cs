using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Employee
    {

    }

    public class EmployeeMetadata
    {
        [Required(ErrorMessage = "Employee Name is required.")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [Range(1000, 1000000)]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }
    }
}