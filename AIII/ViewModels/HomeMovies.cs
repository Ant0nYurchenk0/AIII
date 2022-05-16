using AIII.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIII.ViewModels
{
    public class HomeMovies
    {
        public List<MovieShortInfoDto> PopularMovies { get; set; }
        public List<MovieShortInfoDto> PopularTVs { get; set; }
        public List<MovieShortInfoDto> CustomMovies { get; set; }
    }
}