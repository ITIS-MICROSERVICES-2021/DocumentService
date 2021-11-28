using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentService.Services
{
    public interface ITemplateService
    {
        Task CreateAsync(IFormFile file);

        Task<FileContentResult> GetAsync(string name);
    }
}
