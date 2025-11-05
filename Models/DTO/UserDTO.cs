
using System.ComponentModel.DataAnnotations;

namespace Todo_api.Models.DTO
{
    public class UserWithTaskDTO
    {
        public List<TasksDTO> tasks_list { get; set; }
        public class TasksDTO
        {
            public int task_id { get; set; }
            public string task_name { get; set; }
            public string task_note { get; set; }
            public bool is_completed { get; set; }
            public bool is_repeat { get; set; }
            public bool is_importance { get; set; }
            public bool is_notification { get; set; }
            public string due_date { get; set; }
            public string modify_date { get; set; }
            public string category_name { get; set; }
            public string create_date { get; set; }
        }
        public int total_result { get; set; }
        public int total_pages { get; set; }
    }

    public class UserListResultDTO
    {
        public class UserListDTO
        {
            public int user_id { get; set; }
            public string name { get; set; }
            public string avatar { get; set; }
            public string date_of_birth { get; set; }
            public string user_name { get; set; }
        }
        public List<UserListDTO> users_list { get; set; }
        public int total_result { get; set; }
        public int total_pages { get; set; }
    }
    public class UserRequestFormDTO
    {
        [Required(ErrorMessage = "User name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "User name must be between 3 and 50 characters.")]
        public string user_name { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
        public string password { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string name { get; set; }
        public string? avatar { get; set; }

        public IFormFile? file_uri { get; set; }
        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        [RegularExpression(@"^\d{2}-\d{2}-\d{4}$", ErrorMessage = "Date of birth must be in DD/MM/YYYY format.")]
        public string date_of_birth { get; set; }
    }
    public class UserLoginDTO
    {
        public string user_name { get; set; }
    }
    public class ResponseUserDataDTO
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public string date_of_birth { get; set; }
        public string role_name { get; set; }
    }
   
}

