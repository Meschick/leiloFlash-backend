using leiloFlash_backend.DTO.Leilao;
using leiloFlash_backend.DTO.Response;
using leiloFlash_backend.Enums;
using leiloFlash_backend.Models;
using leiloFlash_backend.Repositories.Leilao;

namespace leiloFlash_backend.Services.Leilao
{
    public class LeilaoService : ILeilaoService
    {

        private readonly ILeilaoRepository _leilaoRepository;

        public LeilaoService(ILeilaoRepository leilaoRepository)
        {
            _leilaoRepository = leilaoRepository;
        }

        public async Task<bool> AtualizarLeilao(int id, LeilaoDTO leilaoDto)
        {
            var leilao = await _leilaoRepository.GetByIdAsync(id);

            if (leilao is null) throw new Exception("Leilão não encontrado");


            leilao.Nome = leilaoDto.Nome;
            leilao.Descricao = leilaoDto.Descricao;
            leilao.DataInicio = leilaoDto.DataInicio;
            leilao.DataFim = leilaoDto.DataFim;
            leilao.UsuarioId = leilaoDto.UsuarioId;


            await _leilaoRepository.UpdateAsync(leilao);
            return true;


        }
        public async Task<LeilaoResponseDTO> CriarLeilaoAsync(LeilaoDTO leilaoDto)
        {
            var leilao = new LeilaoModel
            {
                Nome = leilaoDto.Nome,
                Descricao = leilaoDto.Descricao,
                DataInicio = leilaoDto.DataInicio,
                DataFim = leilaoDto.DataFim,
                UsuarioId = leilaoDto.UsuarioId,
                StatusLeilao = StatusLeilaoEnum.Ativo
            };

            await _leilaoRepository.CreateAsync(leilao);

            return new LeilaoResponseDTO
            {
                Id = leilao.Id,
                Nome = leilao.Nome,
                Descricao = leilao.Descricao,
                DataInicio = leilao.DataInicio,
                DataFim = leilao.DataFim,
                UsuarioId = leilao.UsuarioId
            };
        }



        public async Task<bool> DeletarLeilao(int id)
        {
            var sucesso = await _leilaoRepository.DeleteLeilaoAsync(id);

            if (!sucesso)
                throw new Exception("Leilão não encontrado."); // regra de negócio

            return true;
        }

        public async Task<List<LeilaoDTO>> ListarLeiloes()
        {
            var leiloes = await _leilaoRepository.GetAllAsync();

            var leiloesDto = leiloes.Select(l => new LeilaoDTO
            {
                Nome = l.Nome,
                Descricao = l.Descricao,
                DataInicio = l.DataInicio,
                DataFim = l.DataFim,
                UsuarioId = l.UsuarioId
            }).ToList();

            return leiloesDto;
        }

        public async Task<LeilaoDTO> ObterLeilaoPorId(int id)
        {
            var leilao = await _leilaoRepository.GetByIdAsync(id);

            if (leilao is null) throw new Exception("Leilão não encontrado");

            return new LeilaoDTO
            {
                Nome = leilao.Nome,
                Descricao = leilao.Descricao,
                DataInicio = leilao.DataInicio,
                DataFim = leilao.DataFim,
                UsuarioId = leilao.UsuarioId
            };
        }
    }
}
