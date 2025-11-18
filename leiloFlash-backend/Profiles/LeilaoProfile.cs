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
     
            CreateMap<LoteModel, LoteResponseDTO>();
            CreateMap<LoteDTO, LoteModel>();

            CreateMap<LeilaoModel, LeilaoResponseDTO>()
                .ForMember(dest => dest.StatusLeilao, opt => opt.MapFrom(src => src.StatusLeilao.ToString()));

            CreateMap<LoteModel, LoteResponseDTO>()
                 .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => src.Leilao.DataInicio))
                 .ForMember(dest => dest.DataFim, opt => opt.MapFrom(src => src.Leilao.DataFim));

            CreateMap<LoteDTO, LoteModel>();

            CreateMap<VeiculoModel, VeiculoResponseDTO>();

            CreateMap<ImagemModel, ImagemResponseDTO>();

            CreateMap<UsuarioModel, UsuarioResponseDTO>();

            CreateMap<LanceModel, LanceResponseDTO>();
            CreateMap<LanceRequestDTO, LanceModel>();

            CreateMap<LanceModel, HistoricoResponseDTO>()
                .ForMember(dest => dest.EmailUsuario,
                opt => opt.MapFrom(src => src.Usuario.Email));

            CreateMap<LoteModel, FinalizarLoteResponseDTO>()
                .ForMember(dest => dest.UsuarioVencedorId,
                    opt => opt.MapFrom(src => src.UltimoLanceUsuarioId))
                  .ForMember(dest => dest.EmailUsuarioVencedor,
                    opt => opt.MapFrom(src => src.UltimoLanceUsuario.Email))
     .                  ForMember(dest => dest.ValorFinal,
                          opt => opt.MapFrom(src => src.ValorFinal));


            CreateMap<LoteModel, LotesArrematadosResponseDTO>()
                .ForMember(dest => dest.LoteId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NomeVeiculo,
                     opt => opt.MapFrom(src =>
                     src.Veiculo != null ? $"{src.Veiculo.Marca} {src.Veiculo.Modelo}" : null))
                 .ForMember(dest => dest.Ano,
                     opt => opt.MapFrom(src => src.Veiculo != null ? src.Veiculo.Ano : 0))
                .ForMember(dest => dest.ImagemUrl,
                     opt => opt.MapFrom(src =>
                     src.Veiculo != null && src.Veiculo.Imagens.Any()
                  ? src.Veiculo.Imagens.First().Url
                  : null
             ));


        }
    }
}
