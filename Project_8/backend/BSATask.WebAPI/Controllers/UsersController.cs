using BSATask.DAL.Models.Users;
using BSATask.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BSATask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILinqService _linqService;

        public UsersController(IUserService userService, ILinqService linqService)
        {
            _userService = userService;
            _linqService = linqService;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<UserDto>))]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">User Id</param>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            return Ok(await _userService.GetUserById(id));
        }

        /// <summary>
        /// Create new user
        /// </summary>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(UserCreateDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserCreateDto>> CreateUser([FromBody] UserCreateDto user)
        {
            return Ok(await _userService.CreateUser(user));
        }

        /// <summary>
        /// Edit user
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(UserEditDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserEditDto>> UpdateUser([FromBody] UserEditDto user, int id)
        {
            user.Id = id;
            return Ok(await _userService.UpdateUser(user));
        }

        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="id">User Id</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);

            return NoContent();
        }

        /// <summary>
        /// Get a list of users alphabetically by firstName in ascending order with tasks sorted by the length of name (in descending order).
        /// </summary>
        [HttpGet]
        [Route(LinqRoutes.GetSortedUsersWithSortedTasksAsync)]
        [ProducesResponseType(200, Type = typeof(List<UserWithTasksDto>))]
        [ProducesResponseType(204)]
        public async Task<ActionResult<List<UserWithTasksDto>>> GetSortedUsersWithSortedTasks()
        {
            return Ok(await _linqService.GetSortedUsersWithSortedTasks());
        }


        /// <summary>
        /// Get UserInfoDto(user, last project created by user, number of tasks under last project, 
        /// number of unfinished or canceled tasks under last project, and longest user task) by user id
        /// </summary>
        /// <param name="userId">User Id</param>
        [HttpGet]
        [Route(LinqRoutes.GetUserInfoAsync)]
        [ProducesResponseType(200, Type = typeof(UserInfoDto))]
        [ProducesResponseType(204)]
        public async Task<ActionResult<UserInfoDto>> GetUserInfo(int userId)
        {
            return Ok(await _linqService.GetUserInfo(userId));
        }
    }
}
