using Microsoft.AspNetCore.Mvc;
using leiloFlash_backend.DTO.Leilao;
using leiloFlash_backend.Services.Leilao;

namespace leiloFlash_backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LeilaoController : ControllerBase
    {
        private readonly ILeilaoService _leilaoService;

        public LeilaoController(ILeilaoService leilaoService)
        {
            _leilaoService = leilaoService;
        }

        // GET: api/v1/leilao
        [HttpGet]
        public async Task<IActionResult> ListarLeiloes()
        {
            var leiloes = await _leilaoService.ListarLeiloes();
            return Ok(leiloes); // 200 OK
        }

        // GET: api/v1/leilao/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterLeilaoPorId(int id)
        {
            try
            {
                var leilao = await _leilaoService.ObterLeilaoPorId(id);
                return Ok(leilao); // 200 OK
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message }); // 404 Not Found
            }
        }

        // POST: api/v1/leilao
        [HttpPost]
        public async Task<IActionResult> CriarLeilao([FromBody] LeilaoDTO leilaoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var leilaoCriado = await _leilaoService.CriarLeilaoAsync(leilaoDto);

            return CreatedAtAction(nameof(ObterLeilaoPorId),
                                   new { id = leilaoCriado.Id },
                                   leilaoCriado);
        }

        // PUT: api/v1/leilao/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarLeilao(int id, [FromBody] LeilaoDTO leilaoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // 400 Bad Request

            try
            {
                await _leilaoService.AtualizarLeilao(id, leilaoDto);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message }); // 404 Not Found
            }
        }

        // DELETE: api/v1/leilao/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarLeilao(int id)
        {
            try
            {
                await _leilaoService.DeletarLeilao(id);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message }); // 404 Not Found
            }
        }
    }
}
