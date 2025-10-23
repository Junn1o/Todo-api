using System.ComponentModel.DataAnnotations;

namespace Todo_api.Models.Domain
{
    public class Task_Assignee
    {
        [Key]
        public int TaskId { get; set; }
        public Task Task { get; set; }
        [Key]
        public Guid UserId { get; set; }
        public Team_User Team_User { get; set; }
        
    }
}
