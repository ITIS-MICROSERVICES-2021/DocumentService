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

        private static VacationDTO GetVacationDto()
        {
            return new VacationDTO()
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
            };
        }

        [Fact]
        public void NotInTypeList_DoesntCauseExceptions()
        {
            var documentService = CreateDocumentService();

            documentService.FillInTemplate("not in type list!!!!", 1, GetVacationDto());
        }

        [Fact]
        //что за клоуны...
        public void PredefinedTemplateInTheirPath()
        {
            var fileName = "blank-zayavleniya-na-otpusk.doc";

            var inputDirectory = @"C:\.NetITIS\Dev\DocumentService\data";
            var inputPath = $@"{inputDirectory}\{fileName}";
            var outputPath = $@"{inputDirectory}\vacation.doc";

            if (!Directory.Exists(inputDirectory))
                Directory.CreateDirectory(inputDirectory);
            File.Copy($@"./TestData/{fileName}", inputPath);

            FillInVacationTemplate_NewOutputFileCreated(inputPath, outputPath);
            
            if (File.Exists(inputPath))
                File.Delete(inputPath);
            if (Directory.Exists(inputDirectory))
                Directory.Delete(inputDirectory);
        }

        [Theory]
        [InlineData(@".\vacation_input.doc", @".\vacation_output.doc")]
        public void FillInVacationTemplate_NewOutputFileCreated(string inputPath, string outputPath)
        {
            var documentService = CreateDocumentService();

            if (File.Exists(outputPath))
                File.Delete(outputPath);

            documentService.FillInTemplate("vacation", 1, GetVacationDto());

            Assert.True(File.Exists(outputPath));
            
            if (File.Exists(outputPath))
                File.Delete(outputPath);
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
