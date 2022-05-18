using AIII.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIII.Dtos
{
    public class MovieFullInfoDto
    {
        public string Id { get; set; }
        public string  Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Type { get; set; }       
        public string Image { get; set; }
        public string Plot { get; set; }
        public string Directors { get; set; }
        public string Stars { get; set; }
        public string Genres { get; set; }
        public double ImdbRating { get; set; }
        public string Countries { get; set; }
        public string Budget { get; set; }
        public string CumulativeWorldwideGross { get; set; }
        public UserRatingDto UserRating { get; set; }
    }
}