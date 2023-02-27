﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Interview.ApplicationCore.Model.Response
{
    public class InterviewTypeResponseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}