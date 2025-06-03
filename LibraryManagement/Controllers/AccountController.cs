using LibraryManagement.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Authorize(Roles =UserRoles.Admin)]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="NewUserRole"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("changeRole")]
        public async Task<IActionResult> ChangeUserRole(string UserId, string NewUserRole)
        {
            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }
            else
            {
                // Remove any existing roles (optional)
                var roles = await _userManager.GetRolesAsync(user);
                foreach (var role in roles)
                {
                    await _userManager.RemoveFromRoleAsync(user, role);
                }
                //User registration with the help of default UserManager
                await _userManager.SetUserNameAsync(user, user.UserName);
                await _userManager.SetEmailAsync(user, user.Email);
                var result= await _userManager.AddToRoleAsync(user, NewUserRole);
                if (result.Succeeded)
                {
                    return Ok("User role updated successfully.");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
                //return Ok(new { UserName = UserId, NewUserRole = NewUserRole });
            }
        }
        
    }
}
