using Todo_api.Repositories.IRepositories;
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

namespace Todo_api.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly AppDbContext appDbContext;
        private readonly Functions function;

        public CategoryRequestFromDTO categoryRequestFromDTO(CategoryRequestFromDTO addCategoryDTO)
        {
            var categoryDomain = new Category
            {
                CategoryName = addCategoryDTO.category_name
            };
            appDbContext.Category.Add(categoryDomain);
            appDbContext.SaveChanges();
            return addCategoryDTO;
        }

        public CategoryRequestFromDTO categoryUpdateFromDTO(int userId, int categoryId, CategoryRequestFromDTO updateCategoryDTO)
        {
            var categoryDomain = appDbContext.Category
                .FirstOrDefault(ui => ui.UserId == userId && ui.CategoryId == categoryId);
            categoryDomain.CategoryName = updateCategoryDTO.category_name;
            appDbContext.SaveChanges();
            return updateCategoryDTO;
        }

        public Category deleteCategory(int categoryId, int userId)
        {
            var categoryDomain = appDbContext.Category
                .FirstOrDefault(ui => ui.UserId == userId && ui.CategoryId == categoryId);
            if (categoryDomain == null)
                return null;
            appDbContext.Tasks.RemoveRange(categoryDomain.Tasks);
            appDbContext.Category.Remove(categoryDomain);
            appDbContext.SaveChanges();
            return categoryDomain;
        }

        public GetUSerCategory getUSerCategories(int UserId)
        {
            var CategorytDomain = appDbContext.Category
                .Where(c => c.UserId == UserId)
                .Select(catergory => new GetUSerCategory()
                {
                    category_id = catergory.CategoryId,
                    category_name = catergory.CategoryName,
                }).FirstOrDefault();
            if (CategorytDomain == null)
                return null;
            else
                return CategorytDomain;
        }

        public UserCategoryWithTask userCategoryWithTask(int userId, int categoryId, int pageSize, int pageNumber)
        {
            var CategorytDomain = appDbContext.Category
                .Include(c=>c.User)
                .Include(c => c.Tasks)
                .Where(ui => ui.UserId == userId&& ui.CategoryId == categoryId)
                .FirstOrDefault();
            if (CategorytDomain == null) 
                return null;            var orderedTasks = CategorytDomain.Tasks
                .OrderBy(t => t.DueDate ?? DateTime.MaxValue)
                .ThenBy(t => t.CreateDate);  
            int totalResult = orderedTasks.Count();
            int totalPage = (int)Math.Ceiling((double)totalResult / pageSize);
            var skipResults = (pageNumber - 1) * pageSize;
            var pagedTasksList = orderedTasks
                .Skip(skipResults)
                .Take(pageSize)
                .ToList();
            var tasksList = pagedTasksList.Select(tasks => new UserCategoryWithTask.TasksDTO
            {
                task_id = tasks.TaskId,
                title = tasks.Title,
                note = tasks.Note,
                due_date = tasks.DueDate.HasValue ? tasks.DueDate.Value.ToString("dd/MM/yyyy") : "null",
                modify_date = tasks.ModifyDate.HasValue ? tasks.ModifyDate.Value.ToString("dd/MM/yyyy") : "null",
                is_notification = tasks.IsNotification,
                is_completed = tasks.IsCompleted,
                is_importance = tasks.IsImportance,
                is_repeat = tasks.IsRepeat,
                
            }).ToList();
            return new UserCategoryWithTask
            {
                task_list = tasksList,
                total_result = totalResult,
                total_pages = totalPage
            };
        }
    }
}
