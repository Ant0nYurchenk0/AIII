using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIII.Constants
{
    public class MovieProperties
    {
        public static readonly Dictionary<string, string> Genres = new Dictionary<string, string>
        {
            { "Comedy", "comedy"},
            { "Action", "action"},
            { "Family", "family"},
        };
        public static readonly Dictionary<string, string> Types = new Dictionary<string, string>
        {
            { "Feature Film", "feature"},
            { "TV series", "tv_series"},
        };
        public static readonly Dictionary<string, string> Countries = new Dictionary<string, string>
        {
            { "USA", "us"},
            { "United Kingdom", "gb"},
        };
    }
}