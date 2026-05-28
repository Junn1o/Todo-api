using Todo_api.Models.Domain;

namespace Todo_api.Models.DTO
{
    public class GetAllTaskByUserId
    {
        public class TaskList
        {
            public int task_id { get; set; }
            public string task_name { get; set; }
            public string user_name { get; set; }
            public string task_note { get; set; }
            public bool is_completed { get; set; }
            public bool is_repeat { get; set; }
            public bool is_importance { get; set; }
            public bool is_notification { get; set; }
            public string due_date { get; set; }
            public string modify_date { get; set; }
            public string category_name { get; set; }
        }
        public List<TaskList> task_lists { get; set; }
        public int total_result {  get; set; }
        public int total_page { get; set; }
    }
    public class GetTaskByTaskId
    {
        public int task_id { get; set; }
        public string task_name { get; set; }
        public string task_note { get; set; }
        public bool is_completed { get; set; }
        public bool is_repeat { get; set; }
        public bool is_importance { get; set; }
        public string progress { get; set; }
        public bool is_notification { get; set; }
        public string due_date { get; set; }
        public string modify_date { get; set; }
        public int user_id { get; set; }
        public string user_name { get; set; }
        public int category_id { get; set; }
        public string category_name { get; set; }
        public List<Sub_Task> subtask_list { get; set; }
        public class Sub_Task
        {
            public int subtask_id { get; set; }
            public string subtask_name { get; set; }
            public bool is_completed { get; set; }
            public int position { get; set; }
        }
    }
    public class TaskRequestFormDTO
    {
        public string task_name { get; set; }
        public string task_note { get; set; }
        public bool is_completed { get; set; }
        public bool is_repeat { get; set; }
        public bool is_importance { get; set; }
        public bool is_notification { get; set; }
        public DateTime? due_date { get; set; }
        public DateTime? modify_date { get; set; }
        public DateTime date_create { get; set; }
        public int user_id { get; set; }
        public int? category_id { get; set; }
        public List<SubTask> subtask_form { get; set; }
        public class SubTask
        {
            public string subtask_name { get; set; }
            public bool? is_completed { get; set; }
            public int position { get; set; }
        }
    }
    public class SubTaskRequestFormDTO
    {
        public int task_id { get; set; }
        public required string name { get; set; }
        public bool? is_complete { get; set; }
        public required int position { get; set; }
    }
}
