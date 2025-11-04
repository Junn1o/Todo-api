using Microsoft.AspNetCore.Identity;
using Todo_api.Models.Domain;

namespace Todo_api.Repositories.Funtion
{
    public class Functions
    {
        private readonly PasswordHasher<object> passwordHasher;
        public Functions()
        {
            passwordHasher = new PasswordHasher<object>();
        }
        public string HashPassword(string password)
        {
            return passwordHasher.HashPassword(null, password);
        }
        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var result = passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
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
    }
}
