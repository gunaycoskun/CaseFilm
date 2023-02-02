using Microsoft.AspNetCore.Http;

namespace MovieProject.Application.Abstracts
{
    public interface IFileUploadService
    {
        Task<string> UploadFileAsync(IFormFile file, string path);
    }
}
