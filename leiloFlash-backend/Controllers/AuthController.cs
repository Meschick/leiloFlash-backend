using leiloFlash_backend.DTO.Auth;
using leiloFlash_backend.DTO.Response;
using leiloFlash_backend.DTO.Usuario;
using leiloFlash_backend.Services.Auth;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {

            var token = await _authService.LoginAsync(loginDto.Email, loginDto.Senha);

            if (token == null)
                return Unauthorized( new LoginResponseDTO {
                    Sucesso = false,
                    Mensagem = "Credenciais inválidas",
                    Timestamp = DateTime.UtcNow
            });

            return Ok( new LoginResponseDTO
            {
                Sucesso = true,
                Mensagem = "Login realizado com sucesso",
                Token = token,
                Timestamp = DateTime.UtcNow
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] UsuarioDTO usuarioDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _authService.RegistrarUsuario(usuarioDto);

            if (resultado)
            {
                return Ok(new ApiResponseDTO<bool>(true, "Usuário registrado com sucesso!"));

            }

            return BadRequest(new ApiResponseDTO<bool>(false, "Erro ao registrar usuário."));
        }
    }
}
