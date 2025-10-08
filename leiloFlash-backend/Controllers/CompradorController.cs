using leiloFlash_backend.DTO;
using leiloFlash_backend.Models;
using leiloFlash_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace leiloFlash_backend.Controllers
{
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
