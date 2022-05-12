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
        public string Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Genres { get; set; }

        public string Type { get; set; }

        public string Countries { get; set; }

        public string Plot { get; set; }

        public string Budget { get; set; }

        public string Stars { get; set; }

    }
}