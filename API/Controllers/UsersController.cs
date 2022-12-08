using Application.Services;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(UsersService usersService, ILogger<UsersController> logger)
        {
            _usersService = usersService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a user by id")]
        public async Task<ActionResult<UserDTO>> GetById(int id)
        {
            _logger.LogInformation("Getting user with id {id}", id);
            var user = await _usersService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add a new user")]
        public async Task<ActionResult<User>> AddUser(UserDTO user)
        {
            _logger.LogInformation("Adding user with name {firstName}", user.Name);
            var created = await _usersService.CreateUserAsync(user);
            return Ok(created);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing user")]
        public async Task<ActionResult<User>> UpdateUser(UserDTO user)
        {
            _logger.LogInformation("Updating user with id {id}", user.UserId);
            var existingUser = await _usersService.UpdateUserAsync(user);
            if (existingUser == null)
            {
                return NotFound();
            }

            return Ok(existingUser);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a user")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            _logger.LogInformation("Deleting user with id {id}", id);
            var user = await _usersService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            await _usersService.DeleteUserAsync(user);
            return Ok();
        }
    }
}