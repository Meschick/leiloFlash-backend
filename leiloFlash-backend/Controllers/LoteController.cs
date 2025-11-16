using AutoMapper;
using leiloFlash_backend.DTO.Lote;
using leiloFlash_backend.DTO.Response;
using leiloFlash_backend.Services.Lote;
using Microsoft.AspNetCore.Mvc;

namespace leiloFlash_backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LoteController : Controller
    {
        private readonly ILoteService _loteService;
        private readonly IMapper _mapper;

        public LoteController(ILoteService loteService, IMapper mapper)
        {
            _loteService = loteService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterLotePorId(int id)
        {
            try
            {
                var lote = await _loteService.ObterLotePorId(id);

                var response = new ApiResponseDTO<LoteResponseDTO>(

                    sucesso: true,
                    mensagem: "Lote encontrado com sucesso.",
                    data: _mapper.Map<LoteResponseDTO>(lote)
                    );

                return Ok(response);



            } catch (Exception e) {

                var response = new ApiResponseDTO<object>(
                    sucesso: false,
                    mensagem: e.Message
                    );
                return NotFound(response);
            }
        }

        //[HttpGet("arrematados/{usuarioId}")]
        //public async Task<IActionResult> ObterLotesArrematadosPorUsuario(int usuarioId)
        //{
        //    try
        //    {
        //        var lotes = await _loteService.ObterLotesArramatados(usuarioId);

        //        var response = new ApiResponseDTO<List<LoteResponseDTO>>(
        //            sucesso: true,
        //            mensagem: "Lotes arrematados encontrados com sucesso.",
        //            data: _mapper.Map<List<LoteResponseDTO>>(lotes)
        //            );
        //        return Ok(response);
        //    }
        //    catch (Exception e)
        //    {
        //        var response = new ApiResponseDTO<object>(
        //            sucesso: false,
        //            mensagem: e.Message
        //            );
        //        return NotFound(response);
        //    }
        //}

        [HttpPost("{loteId}/finalizar")]
        public async Task<IActionResult> FinalizarLote(int loteId)
        {
            try
            {
                var loteFinalizado = await _loteService.FinalizarLote(loteId);

                var response = new ApiResponseDTO<FinalizarLoteResponseDTO>
                {
                    Sucesso = true,
                    Mensagem = "Lote finalizado com sucesso",
                    Data  = _mapper.Map<FinalizarLoteResponseDTO>(loteFinalizado)
                };

                return Ok(response);
            }
            catch(Exception e){

                var response = new ApiResponseDTO<object>(
                    sucesso: false,
                    mensagem: e.Message
                    );
                return NotFound(response);
            }
        }
    }
}
