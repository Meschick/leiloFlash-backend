using leiloFlash_backend.DTO.Veiculo;

namespace leiloFlash_backend.Services.Veiculo
{
    public interface IVeiculoService
    {
        Task<List<VeiculoDTO>> ListarVeiculos();
        Task<VeiculoDTO> ObterVeiculoPorId(int id);
    }
}
