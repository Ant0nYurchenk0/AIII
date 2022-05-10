using System;
using AIII.Dtos;
using AIII.Models;
using AutoMapper;

namespace AIII.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();
        }
    }
}