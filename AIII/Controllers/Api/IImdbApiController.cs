using AIII.Dtos;
using System.Collections.Generic;

namespace AIII.Controllers.Api
{
    public interface IImdbApiController
    {
        MovieFullInfoDto GetMovie(string id);
        List<MovieShortInfoDto> GetPopularMovies();
        List<MovieShortInfoDto> GetPopularTVs();
        List<MovieShortInfoDto> GetTopMovies();
        List<MovieShortInfoDto> GetTopTVs();
        List<MovieFullInfoDto> Search(string expression, string country, string type, List<string> genres, List<string> releaseDate, List<string> userRating);
    }
}