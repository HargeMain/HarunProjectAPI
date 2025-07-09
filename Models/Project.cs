namespace HarunProjectAPI.Models
{
    public class Project : DefaultModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; } = DateTime.UtcNow.AddDays(30);
        public ICollection<ProjectWorkLog> WorkLogs { get; set; } = new List<ProjectWorkLog>();
        public int CompanyId { get; set; }
        public Company Company { get; set; } = new Company();
        public int DepertmentId { get; set; }
        public Depertment Depertment { get; set; } = new Depertment();
        public int MaxWorkingHours { get; set; } = 40;
    }
}
