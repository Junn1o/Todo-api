using Microsoft.AspNetCore.Mvc;
using Todo_api.Data;
using Todo_api.Models.DTO;
using Todo_api.Repositories.Funtion;
using Todo_api.Repositories.IRepositories;

namespace Todo_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IUserRepository _userRepository;
        private readonly Functions _functions;
        public UserController(AppDbContext appDbContext, IUserRepository userRepository, Functions functions)
        {
            _appDbContext = appDbContext;
            _userRepository = userRepository;
            _functions = functions;
        }
        [HttpPost("register")]
        public IActionResult registerUser([FromForm] UserRequestFormDTO adduserDTO)
        {
            if (_userRepository.IsUserNameTaken(adduserDTO.user_name))
                return BadRequest("Username is already taken.");
            if (!_functions.IsValidImageFile(adduserDTO.file_uri) || !_functions.HasValidExtension(adduserDTO.file_uri.FileName))
            {
                return BadRequest("Invalid image file type.");
            }

            if (!_functions.IsValidFileSize(adduserDTO.file_uri, 2 * 2048 * 2048))
            {
                return BadRequest("File size exceeds limit.");
            }
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
                return NotFound();
        }
        [HttpGet("user")]
        public IActionResult getUserListResult([FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            var userList = _userRepository.getUserListResult(pageSize, pageNumber);
            if (userList != null)
                return Ok(userList);
            else
                return NotFound();
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
