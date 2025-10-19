namespace leiloFlash_backend.DTO.Veiculo
{
    public class VeiculoDTO
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }
        public decimal KmAtual { get; set; }
        public decimal valorInicial { get; set; }
    }
}
