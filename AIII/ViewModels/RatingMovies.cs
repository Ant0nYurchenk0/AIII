using AIII.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIII.ViewModels
{
    public class RatingMovies
    {
        public MovieFullInfoDto Movie { get; set; }
        public UserRatingDto Rating { get; set; }
    }
}