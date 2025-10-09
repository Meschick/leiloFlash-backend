using leiloFlash_backend.DTO.Comprador;
using leiloFlash_backend.Models;
using leiloFlash_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace leiloFlash_backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CompradorController : Controller
    {
        private readonly ICompradorService _compradorService;

        public CompradorController(ICompradorService compradorService)
        {
            _compradorService = compradorService;
        }

        [HttpPost]
        public async Task<IActionResult> PostComprador([FromBody] CompradorDTO compradorDto)
        {
            await _compradorService.CreateComprador(compradorDto);
                return Ok("Comprador criado com sucesso!");
        }
    }
}
