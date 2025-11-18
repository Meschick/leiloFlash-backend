namespace leiloFlash_backend.DTO.Lote
{
    public class LotesArrematadosResponseDTO
    {
        public int LoteId { get; set; }
        public int NumeroLote { get; set; }

        public decimal ValorFinal { get; set; }

        public string? Tipo { get; set; }      
        public string? Descricao { get; set; }

        public string NomeVeiculo { get; set; }

        public string? ImagemUrl { get; set; }

        public int Ano { get; set; }

    }
}
