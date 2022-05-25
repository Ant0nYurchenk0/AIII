using AIII.Dtos;
using System.Collections.Generic;

namespace AIII.Controllers.Api
{
    public interface IImdbApiController
    {
        MovieFullInfoDto GetMovie(string id);
        List<MovieFullInfoDto> GetPopularMovies();
        List<MovieFullInfoDto> GetPopularTVs();
        List<MovieFullInfoDto> GetTopMovies();
        List<MovieFullInfoDto> GetTopTVs();
        List<MovieFullInfoDto> Search(string expression, string country, string type, List<string> genres, List<string> releaseDate, List<string> userRating);
    }
}