using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Onboard.ApplicationCore.Model.Request
{
    public class EmployeeRequestModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int EmployeeCategoryId { get; set; }
        public int EmployeeStatusId { get; set; }
        public int EmployeeRoleId { get; set; }
        public string? Address { get; set; }
        public string EmailId { get; set; }

    }
}
