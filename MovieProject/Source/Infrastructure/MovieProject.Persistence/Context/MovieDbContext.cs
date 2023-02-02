using Microsoft.EntityFrameworkCore;
using MovieProject.Application.Abstracts;
using MovieProject.Domain.Entity;

namespace MovieProject.Persistence.Context
{
    public class MovieDbContext:DbContext,IMovieDbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Movie");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Film> Film { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
