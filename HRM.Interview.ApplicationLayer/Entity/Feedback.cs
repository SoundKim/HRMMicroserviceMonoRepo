using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Interview.ApplicationCore.Entity
{
    public class Feedback
    {
        public int Id { get; set; }
        [Required]
        public int Rating { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Comment { get; set; }

    }
}
