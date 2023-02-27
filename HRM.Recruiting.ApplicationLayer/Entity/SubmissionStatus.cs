﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Recruiting.ApplicationCore.Entity
{
    public class SubmissionStatus
    {
        public int Id { get; set; }
        [Required, Column(TypeName = "varchar(50)")]
        public string Title { get; set; }

        public bool IsActive { get; set; }
    }
}
