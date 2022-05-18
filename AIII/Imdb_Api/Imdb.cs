using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIII.Imdb_Api
{
    public class Imdb
    {

        internal static string Title = "https://imdb-api.com/en/API/Title/{0}/";
        internal static string SearchTitle = "https://imdb-api.com/API/AdvancedSearch/{0}/";
        internal static string TopMovies = "https://imdb-api.com/en/API/Top250Movies/{0}";
        internal static string TopTVs = "https://imdb-api.com/en/API/Top250TVs/{0}";
        internal static string PopularMovies = "https://imdb-api.com/en/API/MostPopularMovies/{0}";
        internal static string PopularTVs = "https://imdb-api.com/en/API/MostPopularTVs/{0}";
        internal static string Trailer = "https://imdb-api.com/en/API/YouTubeTrailer/{0}/";

        internal static string DefaultKey = "k_l859g0cz";

    }
}   