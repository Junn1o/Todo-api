namespace Todo_api.Models.DTO
{
    public class Sub_TaskCreateDTO
    {
        public Guid task_id { get; set; }
        public required string name { get; set; }
        public bool? is_complete { get; set; }
        public required int position { get; set; }
    }
}
