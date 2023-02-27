using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Recruiting.ApplicationCore.Entity
{
    public class JobRequirement
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Title { get; set; }
        [Required]
        public int TotalPosition { get; set; }
        [Required, Column(TypeName = "varchar(500)")]
        public string Description { get; set; }
        [Required]
        public int HiringManagerId { get; set; }
        [Required, Column(TypeName = "varchar(100)")]
        public string HiringManagerName { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime ClosedOn { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public string? ClosingReason { get; set; }
        [Required]
        public int JobCategoryId { get; set; }

        //navigation property
        public JobCategory jobCategory { get; set; }



    }
}
