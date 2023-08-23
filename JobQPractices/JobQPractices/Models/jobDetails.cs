namespace JobQPractices.Models
{
    public class jobDetails
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public JobStatus? JobStatus { get; set; }
        public DateTime? FinishDate { get; set; }
    }
}
