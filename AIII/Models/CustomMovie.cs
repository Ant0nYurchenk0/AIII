using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIII.Models
{
    public class CustomMovie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        public double? ImdbRating { get; set; }

        [Required]
        [Display(Name = "Poster URL")]
        public string Image { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Genres { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Countries { get; set; }

        [Required]
        public string Plot { get; set; }

        public string Budget { get; set; }

        public string Stars { get; set; }

        [Display(Name = "Box office")]
        public string CumulativeWorldWideGross { get; set; }

        [Required, Display(Name = "Trailer")]
        [MinLength(11)]
        public string Video { get; set; }
    }
}