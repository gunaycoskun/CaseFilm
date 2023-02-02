using Microsoft.EntityFrameworkCore;
using MovieProject.Domain.Entity;

namespace MovieProject.Application.Abstracts
{
    public interface IMovieDbContext:IDbContextBase
    {
        DbSet<Film> Film { get; set; }
        DbSet<Actor> Actor { get; set; }
        DbSet<Comment> Comment { get; set; }
    }
}
