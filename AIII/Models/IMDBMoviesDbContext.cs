using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AIII.Models
{
    public class IMDBMoviesDbContext : DbContext,IAlllDbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserRating> UserMovieRating { get; set; }
        public DbSet<CustomMovie> CustomMovies { get; set; }

        public IMDBMoviesDbContext() : base ("IdentityConnection") { }
    }
}