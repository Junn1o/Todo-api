using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo_api.Models.Domain
{
    public class Task
    {
        [Key]
        public Guid TaskID { get; set; }
        public required string Title { get; set; }
        public string? Note { get; set; }
        public bool? IsCompleted { get; set; }
        public bool? IsRepeat { get; set; }
        public bool? IsImportance { get; set; }
        public string? Progress {  get; set; }
        public string? IsNotification { get; set; }
        public required DateTime DueDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public required Guid UserId { get; set; }
        public User User { get; set; }
        public int? CategoryID { get; set; }
        public Category Category { get; set; }
        public Task_Assignee Task_Assignee { get; set; }
        // One Task have many SubTask
        public List<Sub_Task> SubTasks { get; set; }
    }
}
