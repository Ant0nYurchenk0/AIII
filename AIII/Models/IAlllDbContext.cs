using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AIII.Models
{
    public interface IAlllDbContext
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<UserRating> UserMovieRating { get; set; }
        DbSet<CustomMovie> CustomMovies { get; set; }
        int SaveChanges();
    }
}