using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User>? Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie>? Movies { get; set; }
        public DbSet<Genre>? Genres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Seed(modelBuilder);
        }
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre() { GenreID = 1, Name = "Acción", Image = null, Movies = null, },
                new Genre() { GenreID = 2, Name = "Anime", Image = null, Movies = null, },
                new Genre() { GenreID = 3, Name = "Comedias", Image = null, Movies = null, },
                new Genre() { GenreID = 4, Name = "Fantasía", Image = null, Movies = null, },
                new Genre() { GenreID = 5, Name = "Documentales", Image = null, Movies = null, },
                new Genre() { GenreID = 6, Name = "Romance", Image = null, Movies = null, },
                new Genre() { GenreID = 7, Name = "Sci-fi", Image = null, Movies = null, },
                new Genre() { GenreID = 8, Name = "De Argentina", Image = null, Movies = null, },
                new Genre() { GenreID = 9, Name = "Internacionales", Image = null, Movies = null, },
                new Genre() { GenreID = 10, Name = "Independientes", Image = null, Movies = null, },
                new Genre() { GenreID = 11, Name = "Terror", Image = null, Movies = null, },
                new Genre() { GenreID = 12, Name = "Suspenso", Image = null, Movies = null, }
                );
        }
    }
}
