using AutoMapper;
using Filmes.Data.Dtos;
using Filmes.Models;

namespace Filmes.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        
        CreateMap<UpdateFilmeDto, Filme>();
        
        CreateMap<Filme, UpdateFilmeDto>();
        
        CreateMap<Filme, ReadFilmeDto>();
    }

}