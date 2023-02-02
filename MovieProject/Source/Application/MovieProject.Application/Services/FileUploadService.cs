using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MovieProject.Application.Abstracts;
using MovieProject.Application.Options;

namespace MovieProject.Application.Services
{
    public class FileUploadService:IFileUploadService
    {
        private readonly string rootPath;
        public FileUploadService(IOptions<FilePaths> opt)
        {
            rootPath = opt.Value.RootPath;
        }

        public async Task<string> UploadFileAsync(IFormFile file, string path)
        {

            if (file.Length > 0)
            {
                path = Path.Combine(rootPath + path);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var RandomFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                using (var fileStream = new FileStream(Path.Combine(path + RandomFileName), FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return RandomFileName;
            }

            return String.Empty;


        }
    }
}
