using System.Threading.Tasks;
using DocumentService.Dto;
using Microsoft.AspNetCore.Mvc;

namespace DocumentService.Services
{
    /// <summary>
    /// Document service interface
    /// </summary>
    public interface IDocumentService
    {
        /// <summary>
        /// Fill in template method
        /// </summary>
        Task<FileContentResult> FillInTemplate(string filePath, DocumentDto dto);
    }
}
