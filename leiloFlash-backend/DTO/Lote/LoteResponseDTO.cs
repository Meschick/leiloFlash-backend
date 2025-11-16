using leiloFlash_backend.DTO.Leilao;
using leiloFlash_backend.DTO.Usuario;
using leiloFlash_backend.DTO.Veiculo;
using leiloFlash_backend.Models;

namespace leiloFlash_backend.DTO.Lote
{
    public class LoteResponseDTO
    {

        public int Id { get; set; }
        public int NumeroLote { get; set; }
        public decimal ValorInicial { get; set; }
        public decimal ValorAtual { get; set; }
        public decimal? ValorFinal { get; set; }

        public string Tipo { get; set; }

        public string TipoRetomado { get; set; }

        public decimal ValorMercado { get; set; }

        public string Localizacao { get; set; }
        
        public string? Descricao { get; set; }

        public int? LeilaoId { get; set; }
        public int? UsuarioId { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public VeiculoResponseDTO? Veiculo { get; set; }
        public UsuarioResponseDTO? Usuario { get; set; }
    }
}
