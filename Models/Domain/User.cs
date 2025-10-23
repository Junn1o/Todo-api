using System.ComponentModel.DataAnnotations;

namespace Todo_api.Models.Domain
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
        public string? Avatar { get; set; }
        public required string DateofBirth { get; set; }
        public List<Team_User> Users { get; set; }
        public List<Task> Tasks { get; set; }
        // One User have many Category
        public List<Category> Categories { get; set; }
    }
}
