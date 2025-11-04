using leiloFlash_backend.Models;

namespace leiloFlash_backend.DTO.Imagem
{
    public class ImagemResponseDTO
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime DataUpload { get; set; }
    }
}
