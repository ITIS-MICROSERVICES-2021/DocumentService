using DocumentService.DTOs;
using Microsoft.Extensions.Logging;
using Xunit;
using Service = DocumentService.Services.DocumentService;

namespace DocumentService.Tests
{
    public class DocumentServiceTests
    {
        private static Services.DocumentService CreateDocumentService() =>
            new(new Logger<Services.DocumentService>(new LoggerFactory()));

        [Fact]
        public void Test1()
        {
            var documentService = CreateDocumentService();
            
            documentService.FillInTemplate("not in type list!!!!", 1, new VacationDTO()
            {
                Duration = "1",
                DateDay = "1",
                DateMonth = "1",
                DateYear = "1",
                FromWhom = "1",
                FullName = "1",
                ToWhom = "1",
                EndDateDay = "1",
                EndDateMonth = "1",
                EndDateYear = "1",
                StartDateDay = "1",
                StartDateMonth = "1",
                StartDateYear = "1",
            });
        }
    }
}