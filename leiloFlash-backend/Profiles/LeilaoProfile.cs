using AutoMapper;
using leiloFlash_backend.DTO.Imagem;
using leiloFlash_backend.DTO.Lance;
using leiloFlash_backend.DTO.Leilao;
using leiloFlash_backend.DTO.Lote;
using leiloFlash_backend.DTO.Usuario;
using leiloFlash_backend.DTO.Veiculo;
using leiloFlash_backend.Models;

namespace leiloFlash_backend.Profiles
{
    public class LeilaoProfile : Profile
    {
        public LeilaoProfile()
        {
            // Lote
            CreateMap<LoteModel, LoteResponseDTO>();
            CreateMap<LoteDTO, LoteModel>();

            // Leilão
            CreateMap<LeilaoModel, LeilaoResponseDTO>()
                .ForMember(dest => dest.StatusLeilao, opt => opt.MapFrom(src => src.StatusLeilao.ToString()));

            // Lote
            CreateMap<LoteModel, LoteResponseDTO>();
            CreateMap<LoteDTO, LoteModel>();

            // Veículo
            CreateMap<VeiculoModel, VeiculoResponseDTO>();

            // Imagem
            CreateMap<ImagemModel, ImagemResponseDTO>();

            // Usuário
            CreateMap<UsuarioModel, UsuarioResponseDTO>();

            // 👇 Lance
            CreateMap<LanceModel, LanceResponseDTO>();
            CreateMap<LanceRequestDTO, LanceModel>();
        }
    }
}
