using AutoMapper;
using Filmes.Data.Dtos;
using Filmes.Models;

namespace Filmes.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>().ReverseMap();
            
            CreateMap<ReadSessaoDto, Sessao>().ReverseMap();
        }
    }
}
