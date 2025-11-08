using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Todo_api.Data;
using Todo_api.Models.Domain;
using Todo_api.Models.DTO;
using Todo_api.Repositories.Funtion;
using Todo_api.Repositories.IRepositories;
using DotNetEnv;
using System.Text;

    public class TaskRepository : ITaskRepository
{
    public SubTaskRequestFormDTO addSubTaskDTO(SubTaskRequestFormDTO addSubTaskDTO)
    {
        throw new NotImplementedException();
    }

    public TaskRequestFormDTO addTaskDTO(TaskRequestFormDTO addTaskDTO)
    {
        throw new NotImplementedException();
    }

    public Sub_Task deleteSubTask(int subTaskId)
    {
        throw new NotImplementedException();
    }

    public Todo_api.Models.Domain.Task deleteTask(int taskId)
    {
        throw new NotImplementedException();
    }

    public GetAllTaskByUserId getAllTaskByUserId(int userId, int pageSize, int pageNumber)
    {
        throw new NotImplementedException();
    }

    public GetTaskByTaskId getTaskByTaskId(int taskId)
    {
        throw new NotImplementedException();
    }

    public SubTaskRequestFormDTO updateSubTaskDTO(int subtaskId, int taskId, int userId, SubTaskRequestFormDTO updateSubTaskDTO)
    {
        throw new NotImplementedException();
    }

    public TaskRequestFormDTO updateTaskDTO(int taskId, int userId, TaskRequestFormDTO updateTaskDTO)
    {
        throw new NotImplementedException();
    }
}

