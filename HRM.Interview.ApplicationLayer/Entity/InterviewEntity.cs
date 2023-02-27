using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Interview.ApplicationCore.Entity
{
    public class InterviewEntity
    {
        public int Id { get; set; }
        [Required]
        public int RecruiterId { get; set; }
        [Required]
        public int SubmissionId { get; set; }
        [Required]
        public int InterviewTypeId { get; set; }
        [Required]
        public int InterviewRound { get; set; }
        [Required]
        public DateTime ScheduledOn { get; set; }
        [Required]
        public int InterviewerId { get; set; }
        [Required]
        public int FeedbackId { get; set; }


        //Navigation Properties
        public Recruiter Recruiter { get; set; }
        public InterviewType InterviewType { get; set; }
        public Interviewer Interviewer { get; set; }
        public Feedback Feedback { get; set; }

    }
}
