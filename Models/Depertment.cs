namespace HarunProjectAPI.Models
{
    public class Depertment:DefaultModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Project> Projects { get; set; } = new();
        public List<User> Users { get; set; } = new();

    }
}
