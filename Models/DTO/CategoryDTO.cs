using Todo_api.Models.Domain;
namespace Todo_api.Models.DTO
{
    public class CategoryWithTaskDTO
    {
        public Guid CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public Guid UserId { get; set; }
        public List<TasksDTO> Tasks { get; set; }
        public List<CategoryWithTaskDTO> categoryWithTaskDTO { get; set; }
        public class TasksDTO
        {
            public Guid task_id { get; set; }
            public string title { get; set; }
            public string? note { get; set; }
            public string? is_completed { get; set; }
            public string? is_repeat { get; set; }
            public string? is_importance { get; set; }
            public string? progress { get; set; }
            public string? is_notification { get; set; }
            public string due_date { get; set; }
            public string modify_date { get; set; }
            public string category_name { get; set; }
        }

        public int totalResult { get; set; }
        public int totalPages { get; set; }
    }
    public class CategoryRequestFromDTO 
    {
        public required string CategoryName { get; set; }
    }
    public class CategoryCreateDTO
    {
        public string CategoryName { get; set; }
        public Guid UserId { get; set; }
    }
    public class CategoryUpdateDTO
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
    public class CategoryDeleteDTO
    {
        public Guid CategoryId { get; set; }
    }
}
