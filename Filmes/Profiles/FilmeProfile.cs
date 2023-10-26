using AutoMapper;
using Filmes.Data.Dtos;
using Filmes.Models;

namespace Filmes.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>().ReverseMap();
        
        CreateMap<UpdateFilmeDto, Filme>().ReverseMap();
        
        CreateMap<Filme, ReadFilmeDto>().ReverseMap();

    }
}