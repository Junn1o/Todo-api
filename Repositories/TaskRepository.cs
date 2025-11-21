using DotNetEnv;
using Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Todo_api.Data;
using Todo_api.Models.Domain;
using Todo_api.Models.DTO;
using Todo_api.Repositories.Funtion;
using Todo_api.Repositories.IRepositories;
using static Todo_api.Models.DTO.TaskRequestFormDTO;

    public class TaskRepository : ITaskRepository
{
    public readonly AppDbContext appDbContext;
    private readonly Functions function;
    public SubTaskRequestFormDTO addSubTaskDTO(SubTaskRequestFormDTO addSubTaskDTO)
    {
        var subtaskDomain = new Sub_Task
        {
            Name = addSubTaskDTO.name,
            Position = addSubTaskDTO.position
        }
        ;
        appDbContext.Sub_Tasks.Add(subtaskDomain);
        appDbContext.SaveChanges();
        return addSubTaskDTO;
    }

    public TaskRequestFormDTO addTaskDTO(TaskRequestFormDTO addTaskDTO)
    {
        var taskDomain = new Todo_api.Models.Domain.Task
        {
            Title = addTaskDTO.task_name,
            Note = addTaskDTO.task_note,
            IsCompleted = addTaskDTO.is_completed,
            IsImportance = addTaskDTO.is_importance,
            DueDate = addTaskDTO.due_date,
            CreateDate = addTaskDTO.date_create
        };
        appDbContext.Tasks.Add(taskDomain);
        appDbContext.SaveChanges();
        return addTaskDTO;
    }

    public Sub_Task deleteSubTask(int subTaskId)
    {
        var subtaskDomain = appDbContext.Sub_Tasks
            .FirstOrDefault(si => si.SubTaskId == subTaskId);
        if (subtaskDomain == null)
            return null;
        appDbContext.Sub_Tasks.Remove(subtaskDomain);
        appDbContext.SaveChanges();
        return subtaskDomain;
    }

    public Todo_api.Models.Domain.Task deleteTask(int taskId)
    {
        var taskDomain = appDbContext.Tasks
            .FirstOrDefault(ti => ti.TaskId == taskId);
        if (taskDomain == null)
            return null;
        appDbContext.Sub_Tasks.RemoveRange(taskDomain.SubTasks);
        appDbContext.Tasks.Remove(taskDomain);
        appDbContext.SaveChanges();
        return taskDomain;
    }

    public SubTaskRequestFormDTO updateSubTaskDTO(int subtaskId, int taskId, int userId, SubTaskRequestFormDTO updateSubTaskDTO)
    {
        var subtaskDomain = appDbContext.Sub_Tasks
            .FirstOrDefault(si => si.SubTaskId == subtaskId && si.TaskId == taskId);
        subtaskDomain.Name = updateSubTaskDTO.name;
        subtaskDomain.IsCompleted = updateSubTaskDTO.is_complete;
        appDbContext.SaveChanges();
        return updateSubTaskDTO;
    }

    public TaskRequestFormDTO updateTaskDTO(int taskId, int userId, TaskRequestFormDTO updateTaskDTO)
    {
        var taskDomain = appDbContext.Tasks
            .FirstOrDefault(si => si.TaskId == taskId && si.User.UserId == userId);
        taskDomain.Title = updateTaskDTO.task_name;
        taskDomain.IsCompleted = updateTaskDTO.is_completed;
        taskDomain.DueDate = updateTaskDTO.due_date;
        taskDomain.Note = updateTaskDTO.task_note;
        taskDomain.ModifyDate = updateTaskDTO.modify_date;
        appDbContext.SaveChanges();
        return updateTaskDTO;
    }

    public GetAllTaskByUserId getAllTaskByUserId(int userId, int pageSize, int pageNumber)
    {
        var taskDomain = appDbContext.Users
            .Include(c=> c.Tasks)
            .Include(c=> c.Categories)
            .FirstOrDefault(ui => ui.UserId == userId);
        if (taskDomain == null)
            return null;
        var orderedTasks = taskDomain.Tasks
                .OrderBy(t => t.DueDate ?? DateTime.MaxValue)
                .ThenBy(t => t.CreateDate);
        int totalResult = orderedTasks.Count();
        int totalPage = (int)Math.Ceiling((double)totalResult / pageSize);
        var skipResults = (pageNumber - 1) * pageSize;
        var pagedTasksList = orderedTasks
            .Skip(skipResults)
            .Take(pageSize)
            .ToList();
        var tasksList = pagedTasksList.Select(tasks => new GetAllTaskByUserId.TaskList
        {
            task_id = tasks.TaskId,
            task_name = tasks.Title,
            task_note = tasks.Note,
            due_date = tasks.DueDate.HasValue ? tasks.DueDate.Value.ToString("dd/MM/yyyy") : "null",
            modify_date = tasks.ModifyDate.HasValue ? tasks.ModifyDate.Value.ToString("dd/MM/yyyy") : "null",
            is_notification = tasks.IsNotification,
            is_completed = tasks.IsCompleted,
            is_importance = tasks.IsImportance,
            is_repeat = tasks.IsRepeat,
            category_name = tasks.Category.CategoryName,
            user_name = tasks.User.Name,
        }).ToList();
        return new GetAllTaskByUserId
        {
            task_lists = tasksList,
            total_result = totalResult,
            total_page = totalPage
        };
    }

    public GetTaskByTaskId getTaskByTaskId(int taskId)
    {
        var taskDomain = appDbContext.Tasks.FirstOrDefault(ti => ti.TaskId == taskId);
        if (taskDomain == null)
            return null;
        var taskDomainwithId = new GetTaskByTaskId
        {
            task_id = taskDomain.TaskId,
            task_name = taskDomain.Title,
            task_note = taskDomain.Note,
            due_date = taskDomain.DueDate.HasValue ? taskDomain.DueDate.Value.ToString("dd/MM/yyyy") : "null",
            modify_date = taskDomain.ModifyDate.HasValue ? taskDomain.ModifyDate.Value.ToString("dd/MM/yyyy") : "null",
            is_notification = taskDomain.IsNotification,
            is_completed = taskDomain.IsCompleted,
            is_importance = taskDomain.IsImportance,
            is_repeat = taskDomain.IsRepeat,
            category_name = taskDomain.Category.CategoryName,
            user_name = taskDomain.User.Name,
        };
        return taskDomainwithId;
    }
}

