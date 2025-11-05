using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo_api.Models.Domain
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public required string Title { get; set; }
        public string? Note { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsRepeat { get; set; }
        public bool IsImportance { get; set; }
        public bool IsNotification { get; set; }
        public DateTime? DueDate { get; set; }
        public required DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        // One Task have many SubTask
        public List<Sub_Task> SubTasks { get; set; }
    }
}
