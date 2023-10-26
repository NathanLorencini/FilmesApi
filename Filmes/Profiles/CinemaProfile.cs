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

            CreateMap<Cinema, ReadCinemaDto>()
                .ForMember(dto => dto.ReadEnderecoDto,
                opt
                    => opt.MapFrom(cinema => cinema.Endereco))
                .ForMember(dto => dto.Sessoes,
                    opt
                        => opt.MapFrom(cinema => cinema.Sessoes))
                .ReverseMap();

            CreateMap<Cinema, UpdateCinemaDto>().ReverseMap();


        }
    }
}
