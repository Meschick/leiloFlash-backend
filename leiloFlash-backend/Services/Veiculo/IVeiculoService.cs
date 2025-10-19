
namespace leiloFlash_backend.DTO.
namespace leiloFlash_backend.Services.Veiculo
{
    public interface IVeiculoService
    {
        Task<List<VeiculoDTO>> ListarVeiculos();
    }
}