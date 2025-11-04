using leiloFlash_backend.Services.Pagamento;
using Microsoft.AspNetCore.Mvc;

namespace leiloFlash_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagamentoController : Controller
    {
        private readonly IPagamentoService _pagamentoService;

        public PagamentoController(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }


        [HttpPost("criar-preferencia/{loteId}")]
        public async Task<IActionResult> CriarPreferencia(int loteId)
        {
            var preference = await _pagamentoService.CriarPreferenciaPagamento(loteId);

            if (preference == null)
                return NotFound(new { mensagem = "Lote não encontrado" });

            return Ok(preference);
        }
    }
}
