using System.Threading.Tasks;
using DocumentService.Dto;
using Microsoft.AspNetCore.Mvc;
using DocumentService.Services;

namespace DocumentService.Controllers
{
    /// <summary>
    /// Document controller
    /// </summary>
    [ApiController]
    [Route(nameof(DocumentController))]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        /// <summary>
        /// DI constructor
        /// </summary>
        public DocumentController(IDocumentService documentService) =>
            _documentService = documentService;

        /// <summary>
        /// Fill in template
        /// </summary>
        [HttpPost]
        [Route(nameof(FillInTemplate))]
        public async Task<FileContentResult> FillInTemplate(string type, DocumentDto dto) =>
            await _documentService.FillInTemplate(type, dto);
    }
}
