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

        public async Task CreateComprador(CompradorModel comprador)
        {
            if (comprador == null) 
                throw new ArgumentNullException(nameof(comprador), "O comprador não pode ser nulo");

            if (comprador.UsuarioId <= 0)
                throw new ArgumentNullException(nameof(comprador.UsuarioId), "Usuário vinculado está inválido");

            await _compradorRepository.CreateComprador(comprador);
        }
    }
}
