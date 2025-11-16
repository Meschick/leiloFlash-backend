using leiloFlash_backend.DTO.Imagem;
using leiloFlash_backend.Models;

namespace leiloFlash_backend.DTO.Veiculo
{
    public class VeiculoResponseDTO
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }
        public bool PossuiChave { get; set; }
        public decimal KmAtual { get; set; }
        public decimal ValorInicial { get; set; }

        public List<ImagemResponseDTO> Imagens { get; set; }
    }
}
