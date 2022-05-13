using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AIII.Models
{
    public class CustomMovie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Image { get; set; }

        [Display(Name ="Release Date")]
        public DateTime ReleaseDate { get; set; }

        public string Genres { get; set; }

        public string Type { get; set; }

        public string Countries { get; set; }

        public string Plot { get; set; }

        public string Budget { get; set; }

        public string Stars { get; set; }

        [Display(Name = "Box office")]
        public string CumulativeWorldWideGross { get; set; }

    }
}