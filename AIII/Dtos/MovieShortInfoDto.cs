using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIII.Dtos
{
    public class MovieShortInfoDto
    {
        public int MovieId { get; set; }

        public int? ImdbMovieId { get; set; }

        public string Title { get; set; }

        public string Poster { get; set; }

        public string Plot { get; set; }

        public string RatingIMDB { get; set; }
    }
}