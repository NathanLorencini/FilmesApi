using AutoMapper;
using Filmes.Data.Dtos;
using Filmes.Models;

namespace Filmes.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<Cinema, CreateCinemaDto>().ReverseMap();

            CreateMap<Cinema, ReadCinemaDto>().ReverseMap();

            CreateMap<Cinema, UpdateCinemaDto>().ReverseMap();
        }
    }
}
