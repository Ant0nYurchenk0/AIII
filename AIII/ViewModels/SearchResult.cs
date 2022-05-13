using AIII.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIII.ViewModels
{
    public class SearchResult
    {
        public List<MovieShortInfoDto> Movies { get; set; }
        public string SearchString { get; set; }
    }
}