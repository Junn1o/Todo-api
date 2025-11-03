using System.ComponentModel.DataAnnotations;

namespace Todo_api.Models.Domain
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public string? Avatar { get; set; }
        public required DateTime DateofBirth { get; set; }
        public List<Task> Tasks { get; set; }
        // One User have many Category
        public List<Category> Categories { get; set; }
    }
}
