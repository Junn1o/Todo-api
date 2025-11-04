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
    public class UserRepository : IUserRepository
    {
        public readonly AppDbContext appDbContext;
        private readonly Functions function;
        public UserRepository(AppDbContext _appDbContext, Functions _function)
        {
            DotNetEnv.Env.Load();
            this.appDbContext = _appDbContext;
            this.function = _function;
        }
        public UserListResultDTO getUserListResult(int pageSize, int pageNumber)
        {
            var UserListDomain = appDbContext.Users
                .Select(user => new UserListResultDTO.UserListDTO()
                {
                    user_id = user.UserId,
                    user_name = user.UserName,
                    name = user.Name,
                    avatar = user.Avatar,
                    date_of_birth = user.DateofBirth.ToString("dd/MM/yyyy"),
                });
            var skipResults = (pageNumber - 1) * pageSize;
            if (UserListDomain == null)
            {
                return null;
            }
            else
            {
                var userList = UserListDomain.Skip(skipResults).Take(pageSize).ToList();
                var totalResult = UserListDomain.Count();
                var totalPage = (int)Math.Ceiling((double)totalResult / pageSize);
                var result = new UserListResultDTO
                {
                    users_list = userList.ToList(),
                    total_result = totalResult,
                    total_pages = totalPage,
                };
                return result;
            }
        }
        public UserWithTaskDTO userWithTaskDTOs(int userId, int pageSize, int pageNumber)
        {
            var userDomain = appDbContext.Users
                .Include(c => c.Tasks)
                .ThenInclude(c => c.Category)
                .FirstOrDefault(ui => ui.UserId == userId);
            if (userDomain == null) return null;
            var orderedTasks = userDomain.Tasks
                .OrderBy(t => t.DueDate ?? DateTime.MaxValue)
                .ThenBy(t => t.CreateDate);
            int totalResult = orderedTasks.Count();
            int totalPage = (int)Math.Ceiling((double)totalResult / pageSize);
            var skipResults = (pageNumber - 1) * pageSize;
            var pagedTasksList = orderedTasks
                .Skip(skipResults)
                .Take(pageSize)
                .ToList();
            var tasksList = pagedTasksList.Select(tasks => new UserWithTaskDTO.TasksDTO
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
                category_name = tasks.Category?.CategoryName ?? "",
                create_date = tasks.CreateDate.ToString("dd/MM/yyyy")
            }).ToList();
            return new UserWithTaskDTO
            {
                tasks_list = tasksList,
                total_result = totalResult,
                total_pages = totalPage
            };
        }

        public UserRequestFormDTO registerUser(UserRequestFormDTO addUserDTO)
        {
            var userDomain = new User
            {
                UserName = addUserDTO.user_name,
                Password = function.HashPassword(addUserDTO.password),
                DateofBirth = DateTime.ParseExact(addUserDTO.date_of_birth, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                Name = addUserDTO.name,
            };
            appDbContext.Users.Add(userDomain);
            appDbContext.SaveChanges();
            if (addUserDTO.file_uri != null)
                userDomain.Avatar = addUserDTO.avatar = function.UploadImage(addUserDTO.file_uri, userDomain.UserId);
            appDbContext.SaveChanges();
            return addUserDTO;
        }

        public UserRequestFormDTO userUpdateFormDTO(int userId, UserRequestFormDTO updateDTO)
        {
            var userDomain = appDbContext.Users.FirstOrDefault(ui => ui.UserId == userId);
            userDomain.UserName = userDomain.UserName;
            userDomain.Name = updateDTO.name;
            userDomain.DateofBirth = DateTime.ParseExact(updateDTO.date_of_birth, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (updateDTO.password != null)
                userDomain.Password = function.HashPassword(updateDTO.password);
            if (updateDTO.file_uri != null)
                userDomain.Avatar = function.UpdateImage(updateDTO.file_uri, userDomain.Avatar);
            appDbContext.SaveChanges();
            return updateDTO;

        }
        public User deleteUser(int userId)
        {
            var userDomain = appDbContext.Users
                .FirstOrDefault(u => u.UserId == userId);
            if (userDomain == null)
                return null;
            appDbContext.Sub_Tasks.RemoveRange(userDomain.Tasks.SelectMany(p => p.SubTasks));
            appDbContext.Tasks.RemoveRange(userDomain.Tasks);
            appDbContext.Category.RemoveRange(userDomain.Categories);
            //appDbContext.Users_Roles.RemoveRange(userDomain.User_Role);
            function.DeleteImage(userDomain.Avatar);
            appDbContext.Users.Remove(userDomain);
            appDbContext.SaveChanges();
            return userDomain;
        }
        public UserLoginDTO userLogin(string userName)
        {
            var userDomain = appDbContext.Users.FirstOrDefault(u => u.UserName.ToString() == userName.ToString());
            if (userDomain == null)
                return null;
            return new UserLoginDTO
            {
                user_name = userName,
            };
        }
        public ResponseUserDataDTO ResponseData(string userName)
        {
            var loginData = appDbContext.Users
                .Where(us => us.UserName == userName)
                .Select(u => new ResponseUserDataDTO()
                {
                    user_id = u.UserId,
                    user_name = u.UserName,
                    avatar = u.Avatar,
                    date_of_birth = u.DateofBirth.ToString("dd/MM/yyyy"),
                    name = u.Name,
                    role_name = u.User_Role.Roles.RoleName
                }).FirstOrDefault();
            return loginData;
        }
        public bool ValidatePassword(string userName, string inputPassword)
        {
            var user = appDbContext.Users.SingleOrDefault(c => c.UserName == userName);
            if (user == null)
                return false;
            var isPasswordValid = function.VerifyPassword(user.Password, inputPassword);
            if (!isPasswordValid)
                return false;
            return true;
        }
        public string GenerateJwtToken(ResponseUserDataDTO responseDataDTO)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("Jwt:Key")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, responseDataDTO.user_id.ToString()),
                new Claim(ClaimTypes.Name, responseDataDTO.user_name.ToString()),
                new Claim(ClaimTypes.Name, responseDataDTO.name.ToString()),
                new Claim(ClaimTypes.DateOfBirth, responseDataDTO.date_of_birth.ToString()),
                new Claim(ClaimTypes.Uri, responseDataDTO.avatar.ToString()),
                new Claim(ClaimTypes.Role, responseDataDTO.role_name.ToString())
            };
            var token = new JwtSecurityToken(
                issuer: Environment.GetEnvironmentVariable("Jwt:Issuer"),
                audience: Environment.GetEnvironmentVariable("Jwt:Audience"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials

            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
