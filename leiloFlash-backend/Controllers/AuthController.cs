using leiloFlash_backend.DTO;
using leiloFlash_backend.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace leiloFlash_backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : Controller
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {

            var token = await _authService.LoginAsync(loginDto.Email, loginDto.Senha);
            if (token == null)
                return Unauthorized("Email ou Senha inválidos");

            return Ok(new { Token = token });
        }
    }
}
