using leiloFlash_backend.DTO.Response;
using leiloFlash_backend.DTO.Veiculo;
using leiloFlash_backend.Services.Veiculo;
using Microsoft.AspNetCore.Mvc;

namespace leiloFlash_backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VeiculoController : Controller
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarVeiculos()
        {
            var veiculos = await _veiculoService.ListarVeiculos();

            var response = new ApiResponseDTO<IEnumerable<VeiculoDTO>>(
                sucesso: true,
                mensagem: "Veículos listados com sucesso.",
                data: veiculos
            );

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterVeiculoPorId(int id)
        {
            try
            {
                var veiculo = await _veiculoService.ObterVeiculoPorId(id);

                var response = new ApiResponseDTO<VeiculoDTO>(
                    sucesso: true,
                    mensagem: "Veículo encontrado com sucesso.",
                    data: veiculo
                );

                return Ok(response);
            }
            catch (Exception e )
            {
                var erroResponse = new ApiResponseDTO<object>(
                    sucesso: false,
                    mensagem: e.Message
                );
                    
                return NotFound(erroResponse);

            }
        }
    }
}
