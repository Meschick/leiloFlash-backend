using leiloFlash_backend.DTO.Pagamento;
using leiloFlash_backend.DTO.Pagamento.Cartao;
using leiloFlash_backend.DTO.Pagamento.Pix;
using leiloFlash_backend.DTO.Response;
using leiloFlash_backend.Services.Pagamento;
using Microsoft.AspNetCore.Mvc;

namespace leiloFlash_backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PagamentoController : Controller
    {
        private readonly IPagamentoService _pagamentoService;

        public PagamentoController(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        // ===================== PIX =====================
        [HttpPost("pix")]
        public async Task<IActionResult> CriarPagamentoPix([FromBody] CriarPagamentoPixRequestDTO dto)
        {
            var resultado = await _pagamentoService.CriarPagamentoPix(dto);

            return Ok(new ApiResponseDTO<CriarPagamentoPixResponseDTO>(
                sucesso: true,
                mensagem: "Pagamento PIX criado com sucesso.",
                data: resultado
            ));
        }


        // ===================== CARTÃO =====================
        [HttpPost("cartao")]
        public async Task<IActionResult> CriarPagamentoCartao([FromBody] CriarPagamentoCartaoRequestDTO dto)
        {
            var resultado = await _pagamentoService.CriarPagamentoCartao(dto);

            return Ok(new ApiResponseDTO<CriarPagamentoCartaoResponseDTO>(
                sucesso: true,
                mensagem: "Pagamento com cartão criado com sucesso.",
                data: resultado
            ));
        }
    }
}
