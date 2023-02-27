using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Onboard.ApplicationCore.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(9)")]
        public string SSN { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
        [Required]
        public int EmployeeCategoryId { get; set; }
        [Required]
        public int EmployeeStatusId { get; set; }
        [Required]
        public int EmployeeRoleId { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string? Address { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        //navigation property
        public EmployeeRole EmployeeRole { get; set; }
        public EmployeeCategory EmployeeCategory { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }

    }
}
