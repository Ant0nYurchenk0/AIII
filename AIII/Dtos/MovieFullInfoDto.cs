using System;

namespace AIII.Dtos
{
    public class MovieFullInfoDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public string Plot { get; set; }
        public string Directors { get; set; }
        public string Stars { get; set; }
        public string Genres { get; set; }
        public double? ImdbRating { get; set; }
        public string Countries { get; set; }
        public string Budget { get; set; }
        public string CumulativeWorldWideGross { get; set; }
        public string Video { get; set; }
        public string Seasons { get; set; }
        public UserRatingDto UserRating { get; set; }
    }
}