using System.ComponentModel.DataAnnotations;

namespace Todo_api.Models.Domain
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        // One Category have many Task
        public List<Task> Tasks { get; set; }
    }
}
