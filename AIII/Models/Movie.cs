using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIII.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        public int? ImdbMovieId { get; set; }

        public string Title { get; set; }

        public string Poster { get; set; }

        public DateTime Year { get; set; }

        public string Genre { get; set; }

        public string Type { get; set; }

        public string Country { get; set; }

        public string Cast { get; set; }

        public string Plot { get; set; }

        public double Budget { get; set; }

        public double BoxOffice { get; set; }

        public string RatingIMDB { get; set; }

        public double SiteUserRating { get; set; }

        public int GoodEmodjiAmount { get; set; }

        public int BadEmodjiAmount { get; set; }
    }
}