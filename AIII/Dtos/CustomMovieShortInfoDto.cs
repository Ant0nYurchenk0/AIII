using System;

namespace AIII.Dtos
{
    public class CustomMovieShortInfoDto
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public string Poster { get; set; }

        public string Plot { get; set; }

        public string RatingIMDB { get; set; }
    }
}