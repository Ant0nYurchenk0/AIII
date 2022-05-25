using AIII.Constants;
using AIII.Dtos;
using System.Collections.Generic;

namespace AIII.ViewModels
{
    public class SearchResult
    {
        public IEnumerable<MovieShortInfoDto> Movies { get; set; }
        public string Title { get; set; }
        public List<string> Genres { get; set; }
        public List<string> UserRating { get; set; }
        public Sorting Sorting { get; set; }
        public int NumberOfPages { get; set; }
        public int CurrentPage { get; set; }
        public string Tag { get; set; }


    }
}