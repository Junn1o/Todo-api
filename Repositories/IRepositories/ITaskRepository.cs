using Todo_api.Models.Domain;
using Todo_api.Models.DTO;

namespace Todo_api.Repositories.IRepositories
{
    public interface ITaskRepository
    {
        List<GetAllTaskByUserId> getAllTaskByUserId(Guid userId, int pageSize, int pageNumber);
        GetTaskByTaskId getTaskByTaskId(Guid taskId);
        TaskRequestFormDTO addTaskDTO(TaskRequestFormDTO addTaskDTO);
        TaskRequestFormDTO updateTaskDTO(Guid taskId, Guid userId, TaskRequestFormDTO updateTaskDTO);
        SubTaskRequestFormDTO addSubTaskDTO(SubTaskRequestFormDTO addSubTaskDTO);
        SubTaskRequestFormDTO updateSubTaskDTO(Guid subtaskId, Guid taskId, Guid userId,SubTaskRequestFormDTO updateSubTaskDTO);
        Sub_Task deleteSubTask(Guid subTaskId);
        Models.Domain.Task deleteTask(Guid taskId);
    }
}
