using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Recruiting.ApplicationCore.Model.Response
{
    public class SubmissionResponseModel
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int JobRequirementId { get; set; }
        public DateTime SubmittedOn { get; set; } = DateTime.Now;
        public DateTime? ConfirmedOn { get; set; }
        public DateTime? RejectedOn { get; set; }
        public int SubmissionStatusId { get; set; } = 1;

    }
}
