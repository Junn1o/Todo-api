using System.ComponentModel.DataAnnotations;

namespace Todo_api.Models.Domain
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        // One Category have many Task
        public List<Task> Tasks { get; set; }
    }
}
