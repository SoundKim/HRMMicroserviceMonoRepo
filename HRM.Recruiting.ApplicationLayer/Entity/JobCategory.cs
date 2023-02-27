using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Recruiting.ApplicationCore.Entity
{
    public class JobCategory
    {
        public int Id { get; set; }
        [Required, Column(TypeName = "varchar(20)")]
        public string Title { get; set; }
        [Required, Column(TypeName = "varchar(20)")]
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
