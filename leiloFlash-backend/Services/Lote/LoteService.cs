using AutoMapper;
using leiloFlash_backend.DTO.Lote;
using leiloFlash_backend.Repositories.Lance;
using leiloFlash_backend.Repositories.Lote;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace leiloFlash_backend.Services.Lote
{
    public class LoteService : ILoteService
    { 
        private readonly ILoteRepository _loteRepository;
        private readonly ILanceRepository _lanceRepository;
        private readonly IMapper _mapper;

        public LoteService(ILoteRepository loteRepository, ILanceRepository lanceRepository, IMapper mapper)
        {
            _loteRepository = loteRepository;
            _lanceRepository = lanceRepository;
            _mapper = mapper;
        }
        
        public async Task<LoteResponseDTO> ObterLotePorId(int id)
        {
            var lote = await _loteRepository.GetByIdAsync(id);

            if (lote is null) throw new Exception("Lote não encontrado");

            return _mapper.Map<LoteResponseDTO>(lote);
        }

        public async Task<FinalizarLoteResponseDTO> FinalizarLote(int loteId)
        {
            var lote = await _loteRepository.GetByIdAsync(loteId);

            if (lote is null) throw new Exception("Lote não encontrado");

            var ultimoLance = await _lanceRepository.GetUltimoLancePorLoteId(loteId);

            if (ultimoLance is null) throw new Exception("Nenhum lance encontrado para este lote");

            lote.ValorFinal = ultimoLance.Valor;

            lote.UltimoLanceUsuarioId = ultimoLance.UsuarioId;

            await _loteRepository.UpdateAsync(lote);

            return _mapper.Map<FinalizarLoteResponseDTO>(lote);
        }
    }
}
