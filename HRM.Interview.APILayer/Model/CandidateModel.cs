namespace HRM.Interview.APILayer.Model
{
    public class CandidateModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Mobile { get; set; }

        public string EmailId { get; set; }

        public string? ResumeUrl { get; set; }
    }
}
