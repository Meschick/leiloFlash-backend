using AutoMapper;
using leiloFlash_backend.Data;
using leiloFlash_backend.DTO.Lance;
using leiloFlash_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace leiloFlash_backend.Services.Lance
{
    public class LanceService
    {
        private readonly LeiloDbContext _context;
        private readonly IMapper _mapper;

        public LanceService(LeiloDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LanceResponseDTO> DarLanceAsync(LanceRequestDTO request)
        {
            var lote = await _context.Lote.FirstOrDefaultAsync(l => l.Id == request.LoteId);

            if (lote == null)
                throw new Exception("Lote não encontrado.");

            var lanceAtual = lote.ValorAtual ?? lote.ValorInicial;
            if (request.Valor <= lanceAtual)
                throw new Exception("O valor do lance deve ser maior que o lance atual.");

            // Usa AutoMapper pra converter o DTO em entidade
            var novoLance = _mapper.Map<LanceModel>(request);
            novoLance.DataHora = DateTime.Now;

            // Atualiza o valor do lote
            lote.ValorAtual = request.Valor;

            _context.Lance.Add(novoLance);
            await _context.SaveChangesAsync();

            // Retorna o DTO de resposta mapeado
            return _mapper.Map<LanceResponseDTO>(novoLance);
        }
    }
}
