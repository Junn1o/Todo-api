using Todo_api.Models.Domain;

namespace Todo_api.Models.DTO
{
    public class TaskWithAllSub_Task
    {
        public Guid TaskID { get; set; }
        public required string Title { get; set; }
        public string? Note { get; set; }
        public bool? IsCompleted { get; set; }
        public bool? IsRepeat { get; set; }
        public bool? IsImportance { get; set; }
        public string? Progress { get; set; }
        public string? IsNotification { get; set; }
        public required DateTime DueDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public Guid? UserId { get; set; }
        public Guid? CategoryID { get; set; }
        public List<Sub_Task> Sub_Tasks { get; set; }
        public List<TaskWithAllSub_Task> taskWithAllSub_Task { get; set; }
        public class Sub_Task
        {
            public Guid SubTaskId { get; set; }
            public Guid TaskId { get; set; }
            public required string Name { get; set; }
            public bool? IsCompleted { get; set; }
            public required int Position { get; set; }
        }
        public int totalResult { get; set; }
        public int totalPages { get; set; }
    }
    public class TaskCreateDTO
    {
        public Guid TaskID { get; set; }
        public required string Title { get; set; }
        public string? Note { get; set; }
        public bool? IsCompleted { get; set; }
        public bool? IsRepeat { get; set; }
        public bool? IsImportance { get; set; }
        public string? Progress { get; set; }
        public string? IsNotification { get; set; }
        public required DateTime DueDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public Guid? UserId { get; set; }
        public Guid? CategoryID { get; set; }

    }
    public class TaskUpdateDTO
    {
        public Guid TaskID { get; set; }
        public required string Title { get; set; }
        public string? Note { get; set; }
        public bool? IsCompleted { get; set; }
        public required DateTime DueDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public Guid? UserId { get; set; }
        public Guid? CategoryID { get; set; }
    }
    public class TaskDeleteDTO 
    {
        public Guid TaskID { get; set; }
    }


}
