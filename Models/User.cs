namespace HarunProjectAPI.Models
{
    public class User : DefaultModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true; 
        public int DepertmentId { get; set; }
        public Depertment Depertment { get; set; } = new Depertment();
        public ICollection<ProjectWorkLog> ProjectWorkLogs { get; set; } = new List<ProjectWorkLog>();
        public ICollection<ProjectWorkLog> ApprovedWorkLogs { get; set; } = new List<ProjectWorkLog>();

    }
}
