using Todo_api.Models.Domain;
using static Todo_api.Models.DTO.TaskRequestDTO;

namespace Todo_api.Models.DTO
{
    public class GetAllTaskByUserId
    {
        public class TaskList
        {
            public Guid task_id { get; set; }
            public string task_name { get; set; }
            public string user_name { get; set; }
            public string task_note { get; set; }
            public string is_completed { get; set; }
            public string is_repeat { get; set; }
            public string is_importance { get; set; }
            public string progress { get; set; }
            public string is_notification { get; set; }
            public string due_date { get; set; }
            public string modify_date { get; set; }
        }
        public List<TaskList> task_lists { get; set; }
        public string total_result {  get; set; }
        public string total_page { get; set; }
    }
    public class GetTaskByTaskId
    {
        public Guid task_id { get; set; }
        public string task_name { get; set; }
        public string task_note { get; set; }
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
            public string subtask_name { get; set; }
            public bool is_completed { get; set; }
            public int position { get; set; }
        }
    }
    public class TaskRequestDTO
    {
        public Guid task_id { get; set; }
        public string task_name { get; set; }
        public string task_note { get; set; }
        public bool? is_completed { get; set; }
        public bool? is_repeat { get; set; }
        public bool? is_importance { get; set; }
        public string? progress { get; set; }
        public bool? is_notification { get; set; }
        public DateTime? due_date { get; set; }
        public DateTime? modify_date { get; set; }
        public DateTime date_create { get; set; }
        public required Guid user_id { get; set; }
        public Guid? category_id { get; set; }
        public List<SubTask> subtask_form { get; set; }
        public class SubTask
        {
            public Guid subtask_id { get; set; }
            public string subtask_name { get; set; }
            public bool? is_completed { get; set; }
            public int position { get; set; }
        }
    }
    public class TaskUpdateDTO
    {
        public string task_name { get; set; }
        public string task_note { get; set; }
        public bool? is_completed { get; set; }
        public bool? is_repeat { get; set; }
        public bool? is_importance { get; set; }
        public string? progress { get; set; }
        public bool? is_notification { get; set; }
        public DateTime? due_date { get; set; }
        public DateTime? modify_date { get; set; }
        public required Guid user_id { get; set; }
        public Guid? category_id { get; set; }
        public List<SubTask> subtask_form { get; set; }
        public class SubTask
        {
            public string subtask_name { get; set; }
            public bool? is_completed { get; set; }
            public int position { get; set; }
        }
    }
}
