using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace AIII.Models
{
    public class CustomMoviesDbContext : DbContext, IAlllDbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserRating> UserMovieRating { get; set; }
        public DbSet<CustomMovie> CustomMovies { get; set; }
    }
}