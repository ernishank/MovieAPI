using Microsoft.EntityFrameworkCore;
using MovieAPI.Entity;

namespace MovieAPI.Context
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Ratings> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.ActorId).HasName("PK__ActorId");

                entity.ToTable("Actor");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Nationality)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasKey(e => e.DirectorId).HasName("PK__DirectorId");

                entity.ToTable("Director");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(40)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasMaxLength(40)
                    .IsUnicode(false);
                entity.Property(e => e.Nationality)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.GenreId).HasName("PK__GenreId");

                entity.ToTable("Genre");

                entity.Property(e => e.GenreName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.MovieId).HasName("PK__MovieId");

                entity.ToTable("Movie");

                entity.Property(e => e.Plot)
                    .HasMaxLength(300)
                    .IsUnicode(false);
                entity.Property(e => e.Rating).HasColumnType("decimal(4, 2)");
                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Director).WithMany(p => p.Movies)
                    .HasForeignKey(d => d.DirectorId)
                    .HasConstraintName("FK__Movie__DirectorId");

                entity.HasOne(d => d.Genre).WithMany(p => p.Movies)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__Movie__GenreId");
            });

            modelBuilder.Entity<Ratings>(entity =>
            {
                entity.HasKey(e => e.RatingId).HasName("PK__RatingsId");

                entity.Property(e => e.Rating)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("Rating");
                entity.Property(e => e.Source)
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });
        }
    }
}
