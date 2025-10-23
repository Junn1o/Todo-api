using System.ComponentModel.DataAnnotations;

namespace Todo_api.Models.Domain
{
    public class Team_User
    {
        [Key]
        public int TeamId { get; set; }
        public required Team Team { get; set; }
        [Key]
        public Guid UserId { get; set; }
        public User User { get; set; }
        // One User have many Task_Assignee
        public List<Task_Assignee> Assignees { get; set; }
    }
}
