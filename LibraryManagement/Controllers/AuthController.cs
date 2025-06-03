using LibraryManagement.Interface;
using LibraryManagement.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    //[Authorize(Roles ="Admin,User")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
            //private readonly UserManager<ApplicationUser> _userManager;
            //private readonly SignInManager<ApplicationUser> _signInManager;
            private readonly IAuthService _authService;
            private readonly ILogger<AuthController> _logger;
            public AuthController(
            //UserManager<ApplicationUser> userManager,
            //SignInManager<ApplicationUser> signInManager,
             IAuthService authService, ILogger<AuthController> logger)
            {
                //_userManager = userManager;
               // _signInManager = signInManager;
                _authService = authService;
                _logger = logger;
            }

            [HttpPost]
            [Route("login")]
            public async Task<IActionResult> Login(Login model)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest("Invalid payload");
                    var (status, message) = await _authService.Login(model);
                    if (status == 0)
                        return BadRequest(message);
                    return Ok(message);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            /// <summary>
            /// User registration
            /// </summary>
            /// <param name="model"></param>
            /// <returns></returns>
            [HttpPost]
            [Route("register")]
            public async Task<IActionResult> Register(RegistrationUser model)
            {
                try
                {
                    if (!ModelState.IsValid)
                        return BadRequest("Invalid payload");
                //var (status, message) = await _authService.Registeration(model, UserRoles.User);
                var (status, message) = await _authService.Registeration(model, UserRoles.Admin);
                if (status == 0)
                    {
                        return BadRequest(message);
                    }
                    return CreatedAtAction(nameof(Register), model);

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
        
    }
}
