using leiloFlash_backend.DTO.Leilao;

namespace leiloFlash_backend.Services.Leilao
{
    public interface ILeilaoService
    {
        Task<LeilaoResponseDTO> CriarLeilaoAsync(LeilaoDTO leilaoDto);
        Task<bool> AtualizarLeilao(int id, LeilaoDTO leilaoDto);
        Task<bool> DeletarLeilao(int id);
        Task<List<LeilaoResponseDTO>> ListarLeiloes();
        Task<LeilaoResponseDTO> ObterLeilaoPorId(int id);
    }
}
