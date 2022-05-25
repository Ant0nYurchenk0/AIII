using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AIII.Models
{
    public class SearchInfo
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Genres { get; set; }
        public double ImdbRating { get; set; }

        public string Image { get; set; }
        [DefaultValue("")]
        public string Tag { get; set; }

    }
}