#define HAS_STUPID_REDIS_SERVICE_WITHOUT_DI

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using DocumentService.DTOs;
using DocumentService.Services;
using HarmonyLib;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

using DocumentServiceClass = DocumentService.Services.DocumentService;

namespace DocumentService.Tests
{
    public class DocumentServiceTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public DocumentServiceTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        private static DocumentServiceClass CreateDocumentService()
        {
#if HAS_STUPID_REDIS_SERVICE_WITHOUT_DI
            var harmony = new Harmony("harmony");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            
            return new DocumentServiceClass(new Logger<DocumentServiceClass>(new LoggerFactory()));
#else
            return new DocumentServiceClass(new Logger<DocumentServiceClass>(new LoggerFactory()));
#endif
        }

        [Fact]
        public void NotInTypeList_DoesntCauseExceptions()
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

        [Fact]
        public void FillInVacationTemplate_NewOutputFileCreated()
        {
            var documentService = CreateDocumentService();

            const string inputPath = @".\vacation_input.doc";
            const string outputPath = @".\vacation_output.doc";
            if (File.Exists(outputPath))
                File.Delete(outputPath);

            documentService.FillInTemplate("vacation", 1, new VacationDTO()
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

            Assert.True(File.Exists(outputPath));
        }

        [Fact]
        public void DoesNotContain_RedisService_WithoutDependencyInjection()
        {
            var type = typeof(DocumentServiceClass);
            var redisType = typeof(RedisService);

            var anyCtorWithType = type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .SelectMany(x => x.GetParameters())
                .Any(x => x.ParameterType == redisType);

            var anyPropertyWithType = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Any(x => x.PropertyType == redisType);

            var anyFieldWithType = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Any(x => x.FieldType == redisType);

            var anyUsage = anyFieldWithType || anyPropertyWithType;

            Assert.False(anyUsage ^ anyCtorWithType);
        }
    }
}
