using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Todo_api.Data;
using Todo_api.Models.Domain;
using Todo_api.Models.DTO;

namespace Todo_api.Repositories.Funtion
{
    public class Functions
    {
        private readonly PasswordHasher<object> passwordHasher;
        public readonly AppDbContext appDbContext;
        public Functions(AppDbContext _appDbContext)
        {
            passwordHasher = new PasswordHasher<object>();
            DotNetEnv.Env.Load();
            this.appDbContext = _appDbContext;
        }
        public static string HashPassword(string password)
        {
            var passwordHasher = new PasswordHasher<object>();
            return passwordHasher.HashPassword(new UserRequestFormDTO(), password);
        }
        public static bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var passwordHasher = new PasswordHasher<object>();
            var result = passwordHasher.VerifyHashedPassword(new UserRequestFormDTO(), hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
        public bool ValidatePassword(string userName, string inputPassword)
        {
            var user = appDbContext.Users.SingleOrDefault(c => c.UserName == userName);
            if (user == null)
                return false;
            var isPasswordValid = VerifyPassword(user.Password, inputPassword);
            if (!isPasswordValid)
                return false;
            return true;
        }
        public string GenerateJwtToken(ResponseUserDataDTO responseDataDTO)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("Key")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, responseDataDTO.user_id.ToString()),
                new Claim(ClaimTypes.Name, responseDataDTO.user_name.ToString()),
                new Claim(ClaimTypes.GivenName, responseDataDTO.name.ToString()),
                new Claim(ClaimTypes.DateOfBirth, responseDataDTO.date_of_birth.ToString()),
                new Claim(ClaimTypes.Uri, responseDataDTO.avatar.ToString()),
                new Claim(ClaimTypes.Role, responseDataDTO.role_name.ToString())
            };
            var token = new JwtSecurityToken(
                issuer: Environment.GetEnvironmentVariable("Issuer"),
                audience: Environment.GetEnvironmentVariable("Audience"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials

            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string UploadImage(IFormFile file, int userId)
        {
            var uploadFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            var fileExtension = Path.GetExtension(file.FileName);
            var userFolder = Path.Combine(uploadFolderPath + "user" + userId.ToString());
            Directory.CreateDirectory(userFolder);
            var filePath = Path.Combine(userFolder, "avatar" + fileExtension);
            using (FileStream ms = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(ms);
            }
            return filePath;
        }
        public string UpdateImage(IFormFile file, string filePath)
        {
            var fileExtension = Path.GetExtension(file.FileName);
            var directoryPath = Path.GetDirectoryName(filePath);
            var newFilePath = Path.Combine(directoryPath, Path.GetFileNameWithoutExtension(filePath) + fileExtension);
            if (File.Exists(filePath))
                File.Delete(filePath);
            using (FileStream ms = new FileStream(newFilePath, FileMode.Create))
            {
                file.CopyTo(ms);
            }
            return newFilePath;
        }
        public string DeleteImage(string filePath)
        {
            string getFolder = Path.Combine(filePath);
            if (!Directory.Exists(filePath))
            {
                return null;
            }
            else
            {
                Directory.Delete(filePath, true);
                return filePath;
            }
        }
        public bool IsValidImageFile(IFormFile file)
        {
            var validTypes = new[] { "image/jpeg", "image/png", "image/jpg" };
            return file != null && validTypes.Contains(file.ContentType.ToLower());
        }
        public bool HasValidExtension(string fileName)
        {
            var validExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension(fileName)?.ToLower();
            return validExtensions.Contains(extension);
        }
        public bool IsValidFileSize(IFormFile file, long maxFileSizeInBytes)
        {
            return file != null && file.Length <= maxFileSizeInBytes;
        }
        public bool IsUserNameTaken(string userName)
        {
            return appDbContext.Users.Any(u => u.UserName == userName);
        }
    }
}
