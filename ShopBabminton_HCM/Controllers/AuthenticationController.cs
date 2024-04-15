using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBabminton_HCM.DTOs.AuthenticationDTO;
using ShopBabminton_HCM.Services.AuthenticationService;

namespace ShopBabminton_HCM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService) 
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpDTO SignUp)
        {
            var result = await _authenticationService.SignUpAsync(SignUp);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignInDTO SignIn)
        {
            var result = await _authenticationService.SignInAsync(SignIn);
            return Ok(result);
        }
    }
}
