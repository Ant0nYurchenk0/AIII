using System;

namespace AIII.Repositories
{
    public class CustomMovieRepository
    {
        public static string GetId()
        {
            var id = "aaa" + Guid.NewGuid().ToString("N");

            return id;
        }
    }
}