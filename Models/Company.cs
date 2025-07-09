namespace HarunProjectAPI.Models
{
    public class Company:DefaultModel
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string TaxNumber { get; set; } = string.Empty;
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
