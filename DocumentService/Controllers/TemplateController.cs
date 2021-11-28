using System.Threading.Tasks;
using DocumentService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentService.Controllers
{
    [ApiController]
    [Route(nameof(DocumentController))]
    public class TemplateController : Controller
    {
        private readonly ITemplateService _service;

        public TemplateController(ITemplateService service)
        {
            _service = service;
        }

        /// <summary>
        /// Save document on service
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(IFormFile file)
        {
            await _service.CreateAsync(file);
            return Ok();
        }

        /// <summary>
        /// Get document by name
        /// </summary>
        [HttpGet]
        public async Task<FileContentResult> Get(string name) =>
            await _service.GetAsync(name);
    }
}
