using Microsoft.EntityFrameworkCore;
using MovieManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager
{
    public class MovieManagerDbContext : DbContext
    {

         public MovieManagerDbContext(DbContextOptions<MovieManagerDbContext> options) : base(options)
         {
         }
         public DbSet<User> Users { get; set; }

        public DbSet<Movie> Movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<Movie>().ToTable("Movies");
         }

        
    }
}
