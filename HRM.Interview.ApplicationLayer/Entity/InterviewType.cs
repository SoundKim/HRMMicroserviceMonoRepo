﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Interview.ApplicationCore.Entity
{
    public class InterviewType
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Title { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
