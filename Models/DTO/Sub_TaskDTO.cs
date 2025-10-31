namespace Todo_api.Models.DTO
{
    public class Sub_TaskDTO
    {
        public Guid SubTaskId { get; set; }
        public Guid TaskId { get; set; }
        public required string Name { get; set; }
        public bool? IsCompleted { get; set; }
        public required int Position { get; set; }
    }
    public class Sub_TaskCreateDTO
    {
        public Guid SubTaskId { get; set; }
        public Guid TaskId { get; set; }
        public required string Name { get; set; }
        public bool? IsCompleted { get; set; }
        public required int Position { get; set; }
    }
    public class Sub_TaskUpdateDTO
    {
        public Guid SubTaskId { get; set; }
        public Guid TaskId { get; set; }
        public required string Name { get; set; }
        public bool? IsCompleted { get; set; }
        public required int Position { get; set; }
    }
    public class Sub_TaskDeleteDTO 
    {
        public Guid SubTaskId { get; set; }
    }
}
