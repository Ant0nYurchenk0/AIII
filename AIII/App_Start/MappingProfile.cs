using AIII.Dtos;
using AIII.Models;
using AutoMapper;

namespace AIII.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<CustomMovie, MovieShortInfoDto>();
            Mapper.CreateMap<MovieShortInfoDto, CustomMovie>();

            Mapper.CreateMap<CustomMovie, MovieFullInfoDto>();
            Mapper.CreateMap<MovieFullInfoDto, CustomMovie>();

            Mapper.CreateMap<UserRating, UserRatingDto>();
            Mapper.CreateMap<UserRatingDto, UserRating>();

            Mapper.CreateMap<TeamMember, TeamMember>();
            Mapper.CreateMap<UserRating, UserRating>();
            Mapper.CreateMap<CustomMovie, CustomMovie>();

            Mapper.CreateMap<MovieFullInfoDto, MovieShortInfoDto>();
            Mapper.CreateMap<MovieShortInfoDto, MovieFullInfoDto>();

            Mapper.CreateMap<MovieFullInfoDto, SearchInfoDto>();
            Mapper.CreateMap<SearchInfoDto, MovieFullInfoDto>();

            Mapper.CreateMap<CustomMovie, SearchInfoDto>();
            Mapper.CreateMap<SearchInfoDto, CustomMovie>();

            Mapper.CreateMap<SearchInfo, SearchInfoDto>();
            Mapper.CreateMap<SearchInfoDto, SearchInfo>();

            Mapper.CreateMap<MovieShortInfoDto, SearchInfoDto>();
            Mapper.CreateMap<SearchInfoDto, MovieShortInfoDto>();

            Mapper.CreateMap<MovieShortInfo, MovieShortInfoDto>();
            Mapper.CreateMap<MovieShortInfoDto, MovieShortInfo>();

        }
    }
}