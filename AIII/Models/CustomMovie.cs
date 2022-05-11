using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AIII.Models
{
    public class CustomMovie
    {
        [Key]
        public int MovieId { get; set; }

        public string Title { get; set; }

        public string Poster { get; set; }

        public DateTime Year { get; set; }

        public string Genre { get; set; }

        public string Type { get; set; }

        public string Country { get; set; }

        public string Plot { get; set; }

        public double Budget { get; set; }

        public string Cast { get; set; }

        [Display(Name ="Box office")]
        public double BoxOffice { get; set; }
    }
}