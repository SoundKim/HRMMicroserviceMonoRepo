﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Authentication.Infrastructure.Entity
{
    public class UserRole
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RoleId { get; set; }
        
        //navigation property
        public Account User { get; set; }
        public Role Role { get; set; }
    }
}
