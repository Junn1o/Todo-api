using Todo_api.Models.Domain;
using Todo_api.Models.DTO;

namespace Todo_api.Repositories.IRepositories
{
    public interface ITaskRepository
    {
        GetAllTaskByUserId getAllTaskByUserId(int userId, int pageSize, int pageNumber);
        GetTaskByTaskId getTaskByTaskId(int taskId);
        TaskRequestFormDTO addTaskDTO(TaskRequestFormDTO addTaskDTO);
        TaskRequestFormDTO updateTaskDTO(int taskId, int userId, TaskRequestFormDTO updateTaskDTO);
        SubTaskRequestFormDTO addSubTaskDTO(SubTaskRequestFormDTO addSubTaskDTO);
        SubTaskRequestFormDTO updateSubTaskDTO(int subtaskId, int taskId, int userId,SubTaskRequestFormDTO updateSubTaskDTO);
        Sub_Task deleteSubTask(int subTaskId);
        Models.Domain.Task deleteTask(int taskId);
    }
}
