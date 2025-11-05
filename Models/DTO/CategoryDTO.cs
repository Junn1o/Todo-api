using Todo_api.Models.Domain;
namespace Todo_api.Models.DTO
{
    public class UserCategoryWithTask
    {
        public int category_id { get; set; }
        public int user_id { get; set; }
        public required string category_name { get; set; }
        public List<TasksDTO> task_list { get; set; }
        public class TasksDTO
        {
            public int task_id { get; set; }
            public string title { get; set; }
            public string user_name { get; set; }
            public string? note { get; set; }
            public string? is_completed { get; set; }
            public string? is_repeat { get; set; }
            public string? is_importance { get; set; }
            public string? progress { get; set; }
            public string? is_notification { get; set; }
            public string due_date { get; set; }
            public string modify_date { get; set; }
        }

        public int total_result { get; set; }
        public int total_pages { get; set; }
    }
    public class GetUSerCategory
    {
        public int category_id { get; set; }
        public string category_name { get; set; }
    }
    public class CategoryRequestFromDTO
    {
        public required string category_name { get; set; }
    }
}
