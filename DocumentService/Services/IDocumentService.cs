using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using DocumentService.DTOs;

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
        void FillInTemplate(string filePath, long userId, VacationDTO dto);
    }
}