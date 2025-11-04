using leiloFlash_backend.DTO.Veiculo;
using leiloFlash_backend.Repositories.Veiculo;

namespace leiloFlash_backend.Services.Veiculo
{
    public class VeiculoService : IVeiculoService
    {

        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<List<VeiculoDTO>> ListarVeiculos()
        {
            var veiculos =  await _veiculoRepository.GetAllAsync();

            return veiculos.Select(veiculo => new VeiculoDTO
            {
                Id = veiculo.Id,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Ano = veiculo.Ano,
                Cor = veiculo.Cor,
                KmAtual = veiculo.kmAtual,
                valorInicial = veiculo.ValorInicial
            }).ToList();
        }


        public async Task<VeiculoDTO> ObterVeiculoPorId(int id)
        {
            var veiculo = await _veiculoRepository.GetByIdAsync(id);

            if (veiculo is null) throw new Exception("Veiculo não encontrado");

           return new VeiculoDTO
            {
                Id = veiculo.Id,
                Marca = veiculo.Marca,
                Modelo = veiculo.Modelo,
                Ano = veiculo.Ano,
                Cor = veiculo.Cor,
                KmAtual = veiculo.kmAtual,
                valorInicial = veiculo.ValorInicial

           };
        }
    }
}
