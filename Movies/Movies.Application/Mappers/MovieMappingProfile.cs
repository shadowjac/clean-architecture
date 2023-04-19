using System;
using AutoMapper;
using Movies.Application.Commands;
using Movies.Application.Responses;
using Movies.Core.Entities;

namespace Movies.Application.Mappers
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<Movie, MovieResponse>()
               .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.DirectedBy))
               .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Name))
               .ReverseMap();
            CreateMap<Movie, CreateMovieCommand>().ReverseMap();
        }
    }
}

