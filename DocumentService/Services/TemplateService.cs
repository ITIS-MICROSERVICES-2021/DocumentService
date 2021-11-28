using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;

namespace DocumentService.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly IConfiguration _config;

        public TemplateService(IConfiguration config)
        {
            _config = config;
        }

        public async Task CreateAsync(IFormFile file)
        {
            var dir = _config["FileDirectoryPath"];
            var filePath = Path.Combine(dir, file.FileName);

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
        }

        public async Task<FileContentResult> GetAsync(string name)
        {
            var dir = _config["FileDirectoryPath"];
            var filePath = Path.Combine(dir, name);

            var provider = new FileExtensionContentTypeProvider();
            var gotContentType = provider.TryGetContentType(filePath, out var contentType);
            if (!gotContentType)
                contentType = "application/octet-stream";

            var bytes = await File.ReadAllBytesAsync(filePath);
            return new FileContentResult(bytes, contentType);
        }
    }
}
