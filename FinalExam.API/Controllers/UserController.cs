using Final_Exam___Sales_Management_System.DTOs;
using Final_Exam___Sales_Management_System.Entities;
using Final_Exam___Sales_Management_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Final_Exam___Sales_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserInformationService _userInformationService;

        public UserController(IUserService userService, IUserInformationService userInformationService)
        {
            _userService = userService;
            _userInformationService = userInformationService;
        }


        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] UserAuthDto user)
        {
            try
            {
                var newUser = _userService.SignUp(user.Username, user.Password);
                return Ok(newUser);
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            } 
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserAuthDto user)
        {
            try
            {
                var token = _userService.Login(user.Username, user.Password);
                if (token == null)
                {
                    return BadRequest("Invalid username or password");
                }
                return Ok(new { token });
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [Authorize]
        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(Guid userId)
        {
            try
            {
                var userIdentity = User.Identity as ClaimsIdentity;
                if (userIdentity == null || !userIdentity.IsAuthenticated)
                {
                    return Unauthorized("User is not authenticated.");
                }

                var userIdClaim = userIdentity.FindFirst(ClaimTypes.Sid)?.Value;
                var userRoleClaim = userIdentity.FindFirst(ClaimTypes.Role)?.Value;

                Console.WriteLine("User role claim: "+userRoleClaim);

                if(userRoleClaim == null || userRoleClaim != Role.Admin.ToString())
                {
                    return BadRequest("You don't have the access to perform this action.");
                }

                _userService.DeleteUser(userId);

                return Ok();

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
