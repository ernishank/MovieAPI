using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Entity;

namespace MovieDatabase.DatabaseContext
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) 
        {
        }

        public DbSet<Actor> Actors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting a primary key in OurHero model
            modelBuilder.Entity<Actor>().HasKey(x => x.Id);

            // Inserting record in OurHero table
            modelBuilder.Entity<Actor>().HasData(
                new Actor
                {
                    Id = 1,
                    FirstName = "System",
                    LastName = "",
                    BirthDate = Convert.ToDateTime("23/Oct/1993"),
                }
            );
        }
    }
}
