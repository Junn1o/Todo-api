using Todo_api.Models.Domain;

namespace Todo_api.Models.DTO
{
    public class GetAllTask
    {
        public Guid task_id { get; set; }
        public string title { get; set; }
        public string user_name { get; set; }
        public string note { get; set; }
        public string is_completed { get; set; }
        public string is_repeat { get; set; }
        public string is_importance { get; set; }
        public string progress { get; set; }
        public string is_notification { get; set; }
        public string due_date { get; set; }
        public string modify_date { get; set; }
    }
    public class GetTaskById
    {
        public Guid task_id { get; set; }
        public string title { get; set; }
        public string note { get; set; }
        public bool is_completed { get; set; }
        public bool is_repeat { get; set; }
        public bool is_importance { get; set; }
        public string progress { get; set; }
        public string is_notification { get; set; }
        public required DateTime due_date { get; set; }
        public DateTime modify_date { get; set; }
        public Guid user_id { get; set; }
        public string user_name { get; set; }
        public Guid category_id { get; set; }
        public string category_name { get; set; }
        public List<Sub_Task> subtask_list { get; set; }
        public class Sub_Task
        {
            public Guid subtask_id { get; set; }
            public string name { get; set; }
            public bool is_completed { get; set; }
            public int position { get; set; }
        }
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
