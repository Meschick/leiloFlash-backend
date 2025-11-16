using AutoMapper;
using leiloFlash_backend.DTO.Leilao;
using leiloFlash_backend.DTO.Response;

using leiloFlash_backend.Services.Leilao;
using Microsoft.AspNetCore.Mvc;

namespace leiloFlash_backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LeilaoController : ControllerBase
    {
        private readonly ILeilaoService _leilaoService;
        private readonly IMapper _mapper;

        public LeilaoController(ILeilaoService leilaoService, IMapper mapper)
        {
            _leilaoService = leilaoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ListarLeiloes()
        {
            var leiloes = await _leilaoService.ListarLeiloes();

            var response = new ApiResponseDTO<IEnumerable<LeilaoResponseDTO>>(
                sucesso: true,
                mensagem: "Leilões listados com sucesso.",
                data: _mapper.Map<IEnumerable<LeilaoResponseDTO>>(leiloes)
            );

            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObterLeilaoPorId(int id)
        {
            try
            {
                var leilao = await _leilaoService.ObterLeilaoPorId(id);

                var response = new ApiResponseDTO<LeilaoResponseDTO>(
                    sucesso: true,
                    mensagem: "Leilão encontrado com sucesso.",
                    data: _mapper.Map<LeilaoResponseDTO>(leilao)
                );

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponseDTO<object>(
                    sucesso: false,
                    mensagem: ex.Message
                );
                return NotFound(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CriarLeilao([FromBody] LeilaoDTO leilaoDto)
        {
            if (!ModelState.IsValid)
            {
                var erroResponse = new ApiResponseDTO<object>(
                    sucesso: false,
                    mensagem: "Dados inválidos."
                );
                return BadRequest(erroResponse);
            }

            var leilaoCriado = await _leilaoService.CriarLeilaoAsync(leilaoDto);

            var response = new ApiResponseDTO<LeilaoResponseDTO>(
                sucesso: true,
                mensagem: "Leilão criado com sucesso.",
                data: _mapper.Map<LeilaoResponseDTO>(leilaoCriado)
            );

            return CreatedAtAction(
                nameof(ObterLeilaoPorId),
                new { id = leilaoCriado.Id },
                response
            );
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarLeilao(int id, [FromBody] LeilaoDTO leilaoDto)
        {
            if (!ModelState.IsValid)
            {
                var erroResponse = new ApiResponseDTO<object>(
                    sucesso: false,
                    mensagem: "Dados inválidos."
                );
                return BadRequest(erroResponse);
            }

            try
            {
                await _leilaoService.AtualizarLeilao(id, leilaoDto);

                var response = new ApiResponseDTO<object>(
                    sucesso: true,
                    mensagem: "Leilão atualizado com sucesso."
                );

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponseDTO<object>(
                    sucesso: false,
                    mensagem: ex.Message
                );
                return NotFound(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarLeilao(int id)
        {
            try
            {
                await _leilaoService.DeletarLeilao(id);

                var response = new ApiResponseDTO<object>(
                    sucesso: true,
                    mensagem: "Leilão deletado com sucesso."
                );

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponseDTO<object>(
                    sucesso: false,
                    mensagem: ex.Message
                );
                return NotFound(response);
            }
        }
    }
}
