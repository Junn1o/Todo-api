using System.ComponentModel.DataAnnotations;

namespace Todo_api.Models.Domain
{
    public class Sub_Task
    {
        [Key]
        public int SubTaskId { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public required string Name { get; set; }
        public bool? IsCompleted { get; set; }
        public required int Position { get; set; }
    }
}
