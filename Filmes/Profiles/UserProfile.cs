using AutoMapper;
using Filmes.Data.Dtos;
using Filmes.Models;

namespace Filmes.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>().ReverseMap();
        
        CreateMap<LoginUserDto, User>().ReverseMap();

    }
}