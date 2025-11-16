using AutoMapper;
using leiloFlash_backend.DTO.Lance;
using leiloFlash_backend.DTO.Lote;
using leiloFlash_backend.DTO.Response;
using leiloFlash_backend.Services.Lance;
using Microsoft.AspNetCore.Mvc;

namespace leiloFlash_backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LanceController : Controller
    {
        private readonly ILanceService _lanceService;
        private readonly IMapper _mapper;

        public LanceController(ILanceService lanceService, IMapper mapper)
        {
            _lanceService = lanceService;
            _mapper = mapper;
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

        [HttpGet("historico/{loteId}")]
        public async Task<IActionResult> ObterHistoricoPorId(int loteId)
        {
            try
            {
                var historico = await _lanceService.HistoricoPorLote(loteId);

                var resultado = new ApiResponseDTO<IEnumerable<HistoricoResponseDTO>>
                {
                    Sucesso = true,
                    Mensagem = "Histórico de lances obtido com sucesso.",
                    Data = _mapper.Map<IEnumerable<HistoricoResponseDTO>>(historico)
                };

                return Ok(resultado);
            }
            catch (Exception e)
            {

                var response = new ApiResponseDTO<object>(
                    sucesso: false,
                    mensagem: e.Message
                );
                return NotFound(response);
            }
        }
    }
}
