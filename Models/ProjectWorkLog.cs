using HarunProjectAPI.Models;

public class ProjectWorkLog : DefaultModel
{
    public int ProjectId { get; set; }
    public Project Project { get; set; } = new Project();
    public int UserId { get; set; }
    public User User { get; set; } = new User();
    public DateTime WorkDate { get; set; } = DateTime.UtcNow;
    public int HoursWorked { get; set; } = 0;
    public int OvertimeHours { get; set; } = 0;
    public bool IsBillable { get; set; } = true;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending"; 
    public DateTime? ApprovalDate { get; set; }
    public int? ApprovedByUserId { get; set; }
    public User? ApprovedByUser { get; set; }
    public string? TaskName { get; set; }
}