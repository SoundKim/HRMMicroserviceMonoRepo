using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Authentication.Infrastructure.Model.Response
{
    public class UserResponseModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmailId { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
