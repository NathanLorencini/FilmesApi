using AutoMapper;
using Filmes.Data.Dtos;
using Filmes.Models;

namespace Filmes.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<Endereco, CreateEnderecoDto>().ReverseMap();
        
        CreateMap<Endereco, ReadEnderecoDto>().ReverseMap();
        
        CreateMap<Endereco, UpdateEnderecoDto>().ReverseMap();
    }
}