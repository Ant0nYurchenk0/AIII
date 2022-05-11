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
            Mapper.CreateMap<CustomMovie, CustomMovieDto>();
            Mapper.CreateMap<CustomMovieDto, CustomMovie>();

            Mapper.CreateMap<UserRating, UserRatingDto>();
            Mapper.CreateMap<UserRatingDto, UserRating>();
        }
    }
}