using Todo_api.Models.Domain;
using Todo_api.Models.DTO;

namespace Todo_api.Repositories.IRepositories
{
    public interface IUserRepository
    {
        List<UserWithTaskDTO> userWithTaskDTOs(Guid userId, int pageSize, int pageNumber);
        List<UserListResultDTO> getUserListResult(Guid userId, int pageSize, int pageNumber);
        UserLoginDTO userLogin(UserLoginDTO userLoginDTO);
        UserRequestFormDTO userRequestFormDTO(UserRequestFormDTO addUserDTO);
        UserRequestFormDTO userUpdateFormDTO(UserRequestFormDTO updateDTO);
        User deleteUser(Guid userId);
    }
}
