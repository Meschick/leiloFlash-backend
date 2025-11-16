namespace leiloFlash_backend.DTO.Lote
{
    public class LotesArrematadosResponseDTO
    {
        public string NomeLeilao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int VeiculoId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
    }
}
