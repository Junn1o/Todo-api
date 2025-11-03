
namespace Todo_api.Models.Data
{
    public class TotalUserwithAllTaskDTO
    {
        public class UserwithTaskDTO
        {
            public Guid user_id { get; set; }
            public string name { get; set; }
            public string avatar { get; set; }
            public List<TasksDTO> task_list { get; set; }
            public class TasksDTO
            {
                public Guid task_id { get; set; }
                public string title { get; set; }
                public string note { get; set; }
                public string is_completed { get; set; }
                public string is_repeat { get; set; }
                public string is_importance { get; set; }
                public string progress { get; set; }
                public string is_notification { get; set; }
                public string due_date { get; set; }
                public string modify_date { get; set; }
                public string category_name { get; set; }
            }
        }
        public List<UserwithTaskDTO> userwithalltask { get; set; }
        public int total_result { get; set; }
        public int total_pages { get; set; }
    }

    public class UserListResultDTO
    {
        public class UserListDTO
        {
            public Guid user_id { get; set; }
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
        public DateTime date_of_birth { get; set; }
    }
    public class ResponseUserDataDTO
    {
        public Guid user_id { get; set; }
        public string user_name { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public DateTime date_of_birth { get; set; }
    }
   
}

