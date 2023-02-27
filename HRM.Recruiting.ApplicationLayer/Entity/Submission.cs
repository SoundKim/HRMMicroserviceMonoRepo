using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Recruiting.ApplicationCore.Entity
{
    public class Submission
    {
        public int Id { get; set; }
        [Required]
        public int CandidateId { get; set; }
        [Required]
        public int JobRequirementId { get; set; }
        [Required]
        public DateTime SubmittedOn { get; set; } = DateTime.Now;
        public DateTime? ConfirmedOn { get; set; }
        public DateTime? RejectedOn { get; set; }
        [Required]
        public int SubmissionStatusId { get; set; } = 1;

        //navigational properties
        public Candidate Candidate { get; set; }
        public JobRequirement JobRequirement { get; set; }
        public SubmissionStatus SubmissionStatus { get; set; }
    }
}
