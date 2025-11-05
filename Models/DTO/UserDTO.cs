
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
        public string user_name { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string? avatar { get; set; }
        public IFormFile? file_uri { get; set; }
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

