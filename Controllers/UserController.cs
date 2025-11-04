using Microsoft.AspNetCore.Mvc;
using Todo_api.Data;
using Todo_api.Models.DTO;
using Todo_api.Repositories.IRepositories;

namespace Todo_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUserRepository _userRepository;
        public UserController(AppDbContext appDbContext, IUserRepository userRepository)
        {
            _appDbContext = appDbContext;
            _userRepository = userRepository;
        }
        [HttpPost("register")]
        public IActionResult registerUser([FromForm] UserRequestFormDTO adduserDTO)
        {
            var userAdd = _userRepository.registerUser(adduserDTO);
            return Ok(userAdd);
        }
        [HttpPost("login")]
        public IActionResult login([FromForm] UserLoginDTO loginDTO)
        {
            var credential = _userRepository.userLogin(loginDTO.user_name);
            if (credential == null || !_userRepository.ValidatePassword(loginDTO.user_name, loginDTO.user_name))
                return Unauthorized();
            var loginResponse = _userRepository.ResponseData(loginDTO.user_name);
            var token = _userRepository.GenerateJwtToken(loginResponse);
            return Ok(new { token });
        }
        [HttpGet("user/{userId}")]
        public IActionResult userWithTaskDTOs([FromQuery] int userId, [FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            var userList = _userRepository.userWithTaskDTOs(userId, pageSize, pageNumber);
            if (userList != null)
                return Ok(userList);
            else
                return Ok("Data or User not Found");
        }
        [HttpGet("user")]
        public IActionResult getUserListResult([FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            var userList = _userRepository.getUserListResult(pageSize, pageNumber);
            if (userList != null)
                return Ok(userList);
            else
                return Ok("Data or User not Found");
        }
        [HttpPut("user")]
        public IActionResult userUpdateFormDTO([FromForm] int userId, [FromForm] UserRequestFormDTO updateDTO)
        {
            var updateUser = _userRepository.userUpdateFormDTO(userId, updateDTO);
            if (updateUser != null)
                return Ok(updateUser);
            else
                return StatusCode(404);
        }
        [HttpDelete("user")]
        public IActionResult userDelete([FromForm] int userId)
        {
            var deleteUser = _userRepository.deleteUser(userId);
            if (deleteUser != null)
                return Ok("User Deleted");
            else
                return StatusCode(404);
        }
    }
}
