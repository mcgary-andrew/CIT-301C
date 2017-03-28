using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "The RM",
                         ReleaseDate = DateTime.Parse("2002-1-31"),
                         Genre = "Comedy",
                         Rating = "PG",
                         Price = 7.99M
                     },

                     new Movie
                     {
                         Title = "The Best Two Years",
                         ReleaseDate = DateTime.Parse("2004-2-20"),
                         Genre = "Comedy",
                         Rating = "PG",
                         Price = 8.99M
                     },

                     new Movie
                     {
                         Title = "The Testaments",
                         ReleaseDate = DateTime.Parse("2000-3-24"),
                         Genre = "Religious Film",
                         Rating = "Unrated",
                         Price = 9.99M
                     }

                );
                context.SaveChanges();
            }
        }
    }
}
