using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieProject.Application.Abstracts;
using MovieProject.Persistence.Context;

namespace MovieProject.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddSharedDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<IMovieDbContext, MovieDbContext>(x =>
                x.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), npgsqlDbContextOptionsBuilder =>
                {
                    npgsqlDbContextOptionsBuilder.MigrationsHistoryTable("__ef_migrations_history", "Movie");
                }));
        }
    }
}
