using System.ComponentModel.DataAnnotations;

namespace Todo_api.Models.Domain
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        // One Category have many Task
        public List<Task> Tasks { get; set; }
    }
}
