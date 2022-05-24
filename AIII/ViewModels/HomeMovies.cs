using AIII.Dtos;
using System.Collections.Generic;

namespace AIII.ViewModels
{
    public class HomeMovies
    {
        public List<MovieShortInfoDto> PopularMovies { get; set; }
        public List<MovieShortInfoDto> PopularTVs { get; set; }
        public List<MovieShortInfoDto> CustomMovies { get; set; }
    }
}