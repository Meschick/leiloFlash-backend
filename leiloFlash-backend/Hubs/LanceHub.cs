using leiloFlash_backend.DTO.Lance;
using leiloFlash_backend.Services.Lance;
using Microsoft.AspNetCore.SignalR;

namespace leiloFlash_backend.Hubs
{
    public class LanceHub: Hub
    {
        private readonly ILanceService _lanceService;

        public LanceHub(ILanceService lanceService)
        {
            _lanceService = lanceService;
        }

        public async Task EnviarLance(LanceRequestDTO request, string nomeUsuario)
        {
            try
            {
                var lance = await _lanceService.DarLanceAsync(request);

                // Notifica todos conectados (front-end)
                await Clients.All.SendAsync("ReceberLance", new
                {
                    LoteId = lance.LoteId,
                    Valor = lance.Valor,
                    Usuario = nomeUsuario,
                    DataHora = lance.DataHora
                });
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("ErroAoDarLance", ex.Message);
            }
        }
    }
}
