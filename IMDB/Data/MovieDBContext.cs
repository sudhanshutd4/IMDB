namespace IMDB.Data
{

    using Microsoft.EntityFrameworkCore;
    using IMDB.Entities;
    public class MovieDBContext : DbContext
    {
        public MovieDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Actors> actors { get; set; }
        public DbSet<Producers> producers { get; set; }

        public DbSet<Movies> movies { get; set; }

        public DbSet<MoviesActorMapping> movieactorMapping { get; set; }

    }
}
