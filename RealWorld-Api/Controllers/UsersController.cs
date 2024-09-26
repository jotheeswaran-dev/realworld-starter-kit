//Add a UsersController class to the Controllers folder. This class will be responsible for handling all requests to the /api/users endpoint.

// Path: realworld-starter-kit/RealWorld-Api/Controllers/UsersController.cs

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealWorld_Api.Models.Requests;
using RealWorld_Api.Models.Responses;
using RealWorld_Api.Services;

namespace RealWorld_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost(Name = "RegisterUser")]
        public async Task<ActionResult<UserResponse>> RegisterUser([FromBody] RegisterUserRequest request)
        {
            var user = await _userService.RegisterUser(request);
            return Ok(user);
        }
        //add a new method to the UsersController class that will handle POST requests to the /api/users/login endpoint.
        [HttpPost("login", Name = "LoginUser")]
        public async Task<ActionResult<UserResponse>> LoginUser([FromBody] LoginUserRequest request)
        {
            var user = await _userService.LoginUser(request);
            return Ok(user);
        }
        //add a new method to the UsersController class that will handle GET requests to the /api/user endpoint.
        [HttpGet(Name = "GetCurrentUser")]
        public async Task<ActionResult<UserResponse>> GetCurrentUser()
        {
            var user = await _userService.GetCurrentUser();
            return Ok(user);
        }
        
        //add a new method to the UsersController class that will handle PUT requests to the /api/user endpoint.
        [HttpPut(Name = "UpdateUser")]
        public async Task<ActionResult<UserResponse>> UpdateUser([FromBody] UpdateUserRequest request)
        {
            var user = await _userService.UpdateUser(request);
            return Ok(user);
        }
    }
}