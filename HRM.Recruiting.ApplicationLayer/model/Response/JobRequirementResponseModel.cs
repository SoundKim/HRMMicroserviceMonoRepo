using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Recruiting.ApplicationCore.Entity;

namespace HRM.Recruiting.ApplicationCore.Model.Response
{
    public class JobRequirementResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TotalPosition { get; set; }
        public string Description { get; set; }
        public int HiringManagerId { get; set; }
        public string HiringManagerName { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime StartDate { get; set; }
        public DateTime ClosedOn { get; set; }
        public bool IsActive { get; set; }
        public string? ClosingReason { get; set; }
        public int JobCategoryId { get; set; }

    }
}
