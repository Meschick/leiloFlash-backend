using AutoMapper;
using leiloFlash_backend.Data;
using leiloFlash_backend.DTO.Lance;
using leiloFlash_backend.Models;
using leiloFlash_backend.Repositories.Lance;
using leiloFlash_backend.Repositories.Lote;
using Microsoft.EntityFrameworkCore;

namespace leiloFlash_backend.Services.Lance
{
    public class LanceService : ILanceService
    {
        private readonly ILoteRepository _loteRepository;
        private readonly ILanceRepository _lanceRepository;
        private readonly IMapper _mapper;

        public LanceService(ILoteRepository loteRepository,ILanceRepository lanceRepository,  IMapper mapper)
        {
            _loteRepository = loteRepository;
            _lanceRepository = lanceRepository;
            _mapper = mapper;
        }
        public async Task<LanceResponseDTO> DarLanceAsync(LanceRequestDTO request)
        {
            var lote = await _loteRepository.GetByIdAsync( request.LoteId);
            if (lote == null)
                throw new Exception("Lote não encontrado.");

            var lanceAtual = lote.ValorAtual ?? lote.ValorInicial;
            if (request.Valor <= lanceAtual)
                throw new Exception("O valor do lance deve ser maior que o atual.");

            var novoLance = new LanceModel
            {
                LoteId = request.LoteId,
                UsuarioId = request.UsuarioId,
                Valor = request.Valor,
                DataHora = DateTime.Now
            };

            lote.ValorAtual = request.Valor;
            lote.UltimoLanceUsuarioId = request.UsuarioId;

            await _lanceRepository.AdicionarLanceAsync(novoLance);
            await _loteRepository.UpdateAsync(lote);

            await _lanceRepository.SalvarAsync();

            return _mapper.Map<LanceResponseDTO>(novoLance);
        }
    }
}
