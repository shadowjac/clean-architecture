using System;
using Microsoft.Extensions.Logging;
using Movies.Core.Entities;

namespace Movies.Infrastructure.Data
{
    public class MovieContextSeed
    {
        public static async Task SeedAsync(MovieContext movieContext, ILoggerFactory loggerFactory, int retry = 0)
        {
            var retryForAvailability = retry;

            try
            {
                await movieContext.Database.EnsureCreatedAsync();
                if (!movieContext.Movies.Any())
                {
                    movieContext.Movies.AddRange(GetMovies());
                    await movieContext.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<MovieContextSeed>();
                    log.LogError("Exception ocurred while connecting..., {Message}", ex.Message);
                    await SeedAsync(movieContext, loggerFactory, retryForAvailability);
                }
            }

        }

        private static IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {DirectedBy = "Martin Scorcese", Name = "The Wolf of Wall Street", ReleaseYear = 2013},
                new Movie {DirectedBy = "Chris Nolan", Name = "Inception", ReleaseYear = 2015},
            };
        }

    }
}

