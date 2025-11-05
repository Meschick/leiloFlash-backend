using leiloFlash_backend.DTO.Lance;
using leiloFlash_backend.Services.Lance;
using Microsoft.AspNetCore.Mvc;

namespace leiloFlash_backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LanceController : Controller
    {
        private readonly ILanceService _lanceService;

        public LanceController(ILanceService lanceService)
        {
            _lanceService = lanceService;
        }

        [HttpPost("dar-lance")]
        public async Task<IActionResult> DarLance([FromBody] LanceRequestDTO request)
        {
            try
            {
                var resultado = await _lanceService.DarLanceAsync(request);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}
