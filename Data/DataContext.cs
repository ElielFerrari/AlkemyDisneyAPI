using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Character> Characters { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Seed(modelBuilder);
        }
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre() { GenreId = 1, Name = "Acción", Image = null, Movies = null, },
                new Genre() { GenreId = 2, Name = "Anime", Image = null, Movies = null, },
                new Genre() { GenreId = 3, Name = "Comedia", Image = null, Movies = null, },
                new Genre() { GenreId = 4, Name = "Fantasía", Image = null, Movies = null, },
                new Genre() { GenreId = 5, Name = "Documentales", Image = null, Movies = null, },
                new Genre() { GenreId = 6, Name = "Romance", Image = null, Movies = null, },
                new Genre() { GenreId = 7, Name = "Sci-fi", Image = null, Movies = null, },
                new Genre() { GenreId = 8, Name = "De Argentina", Image = null, Movies = null, },
                new Genre() { GenreId = 9, Name = "Internacionales", Image = null, Movies = null, },
                new Genre() { GenreId = 10, Name = "Independientes", Image = null, Movies = null, },
                new Genre() { GenreId = 11, Name = "Terror", Image = null, Movies = null, },
                new Genre() { GenreId = 12, Name = "Suspenso", Image = null, Movies = null, }
                );
        }
    }
}
