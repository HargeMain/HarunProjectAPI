using System.ComponentModel.DataAnnotations;

namespace HarunProjectAPI.Models
{
    public class DefaultModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
