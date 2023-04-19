using System;
using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;

namespace Movies.Infrastructure.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}

