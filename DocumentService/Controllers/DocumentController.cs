using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using DocumentService.Services;
using DocumentService.DTOs;

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
        [Produces("application/json")]
        [Route(nameof(FillInTemplate))]
        public IActionResult FillInTemplate(string type, long userId, VacationDTO dto)
        {
            _documentService.FillInTemplate(type, userId, dto);
            return Ok();
        }
    }
}