using Todo_api.Models.Domain;
using Todo_api.Models.DTO;

namespace Todo_api.Repositories.IRepositories
{
    public interface IUserRepository
    {
        UserWithTaskDTO userWithTaskDTOs(int userId, int pageSize, int pageNumber);
        UserListResultDTO getUserListResult(int pageSize, int pageNumber);
        UserLoginDTO userLogin(string userName);
        bool ValidatePassword(string userName, string inputPassword);
        ResponseUserDataDTO ResponseData(string userName);
        string GenerateJwtToken(ResponseUserDataDTO responseDataDTO);
        UserRequestFormDTO registerUser(UserRequestFormDTO addUserDTO);
        UserRequestFormDTO userUpdateFormDTO(int userId, UserRequestFormDTO updateDTO);
        User deleteUser(int userId);
    }
}
