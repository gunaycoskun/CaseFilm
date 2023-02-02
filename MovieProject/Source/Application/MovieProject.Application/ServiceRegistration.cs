using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MovieProject.Application.Abstracts;
using MovieProject.Application.Services;
using System.Reflection;

namespace MovieProject.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();           
            services.AddMediatR(assm);
            services.AddAutoMapper(assm);
            services.AddTransient<IFileUploadService, FileUploadService>();
        }
    }
}
