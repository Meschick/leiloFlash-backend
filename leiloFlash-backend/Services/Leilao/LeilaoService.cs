using AutoMapper;
using leiloFlash_backend.DTO.Leilao;
using leiloFlash_backend.Enums;
using leiloFlash_backend.Models;
using leiloFlash_backend.Repositories.Leilao;

namespace leiloFlash_backend.Services.Leilao
{
    public class LeilaoService : ILeilaoService
    {

        private readonly ILeilaoRepository _leilaoRepository;
        private readonly IMapper _mapper;

        public LeilaoService(ILeilaoRepository leilaoRepository, IMapper mapper)
        {
            _leilaoRepository = leilaoRepository;
            _mapper = mapper;
        }

        public async Task<bool> AtualizarLeilao(int id, LeilaoDTO leilaoDto)
        {
            var leilao = await _leilaoRepository.GetByIdAsync(id);

            if (leilao is null) throw new Exception("Leilão não encontrado");


            _mapper.Map(leilaoDto, leilao);

            await _leilaoRepository.UpdateAsync(leilao);
            return true;


        }
        public async Task<LeilaoResponseDTO> CriarLeilaoAsync(LeilaoDTO leilaoDto)
        {

            var leilao = _mapper.Map<LeilaoModel>(leilaoDto);

            leilao.StatusLeilao = StatusLeilaoEnum.Ativo;

            await _leilaoRepository.CreateAsync(leilao);

            return _mapper.Map<LeilaoResponseDTO>(leilao);
        }



        public async Task<bool> DeletarLeilao(int id)
        {
            var sucesso = await _leilaoRepository.DeleteLeilaoAsync(id);

            if (!sucesso)
                throw new Exception("Leilão não encontrado.");

            return true;
        }

        public async Task<List<LeilaoResponseDTO>> ListarLeiloes()
        {
            var leiloes = await _leilaoRepository.GetAllAsync();

            return _mapper.Map<List<LeilaoResponseDTO>>(leiloes);
        }

        public async Task<LeilaoResponseDTO> ObterLeilaoPorId(int id)
        {
            var leilao = await _leilaoRepository.GetByIdAsync(id);

            if (leilao is null) throw new Exception("Leilão não encontrado");

            return _mapper.Map<LeilaoResponseDTO>(leilao);
        }
    }
}
