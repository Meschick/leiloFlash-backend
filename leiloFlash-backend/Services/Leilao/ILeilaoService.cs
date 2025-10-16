using leiloFlash_backend.DTO.Leilao;
using leiloFlash_backend.DTO.Response;

namespace leiloFlash_backend.Services.Leilao
{
    public interface ILeilaoService
    {
        Task<LeilaoResponseDTO> CriarLeilaoAsync(LeilaoDTO leilaoDto);
        Task<bool> AtualizarLeilao(int id, LeilaoDTO leilaoDto);
        Task<bool> DeletarLeilao(int id);
        Task<List<LeilaoDTO>> ListarLeiloes();
        Task<LeilaoDTO> ObterLeilaoPorId(int id);
    }
}
