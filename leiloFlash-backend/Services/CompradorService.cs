using leiloFlash_backend.DTO;
using leiloFlash_backend.Models;
using leiloFlash_backend.Repositories;

namespace leiloFlash_backend.Services
{
    public class CompradorService : ICompradorService
    {
        private readonly ICompradorRepository _compradorRepository;

        public CompradorService(ICompradorRepository compradorRepository)
        {
            _compradorRepository = compradorRepository;
        }

        public async Task CreateComprador(CompradorDTO comprador)
        {
            if (comprador == null)
            {
                throw new ArgumentNullException(nameof(comprador), "O comprador não pode ser nulo.");
            }

            var compradorModel = new CompradorModel(comprador);
            await _compradorRepository.CreateComprador(compradorModel);
        }
    }
}
