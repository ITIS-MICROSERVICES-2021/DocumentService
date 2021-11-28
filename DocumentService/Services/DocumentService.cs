using System;
using System.Globalization;
using System.IO;
using Microsoft.Extensions.Logging;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Threading.Tasks;
using DocumentService.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RedisIO.Services;

namespace DocumentService.Services
{
    /// <summary>
    /// Document service implementation
    /// </summary>
    public class DocumentService : IDocumentService
    {
        private readonly ILogger<DocumentService> _logger;
        private readonly IRedisIOService _redis;
        private readonly IConfiguration _config;
        private readonly IUserService _users;
        private readonly ITemplateService _templates;

        private const string GenDirectorFullName = "Жерард Жира Георгиович";
        private const string VacationFileName = "blank-zayavleniya-na-otpusk.doc";
        private const string DismissalFileName = "blank-zayavleniya-na-uvolnenie-po-sobstvennomu-zhelaniyu.doc";

        /// <summary>
        /// DI constructor
        /// </summary>
        public DocumentService(ILogger<DocumentService> logger, IRedisIOService redis, IConfiguration config,
            IUserService users, ITemplateService templates)
        {
            _logger = logger;
            _redis = redis;
            _config = config;
            _users = users;
            _templates = templates;
        }

        /// <summary>
        /// Fill in template method implementation
        /// </summary>
        public async Task<FileContentResult> FillInTemplate(string type, DocumentDto dto)
        {
            var dir = _config["FileDirectoryPath"];
            Word._Document oDoc = null;
            Word._Application oWord = null;
            try
            {
                object oMissing = Missing.Value;
                oWord = new Word.Application();
                object oTemplate = null;
                string filledFilePath = null;
                string filledFileName = null;
                string[] dtoParams = null;
                var userDto = _users.GetDocumentUser(dto.AuthorId);

                await _redis.AddAsync("testKey", dto);
                Console.WriteLine(await _redis.GetAsync<DocumentDto>("testKey"));
                switch (type)
                {
                    case "vacation":
                        filledFileName = "vacation.doc";
                        oTemplate = Path.Combine(dir, VacationFileName);
                        filledFilePath = Path.Combine(dir, filledFileName);
                        dtoParams = new string[]
                        {
                            dto.CreationDate.Day.ToString(),
                            dto.CreationDate.ToString("MMMM", CultureInfo.CreateSpecificCulture("ru")),
                            (dto.CreationDate.Year % 100).ToString(),
                            (dto.EndDate - dto.StartDate).Days.ToString(),
                            dto.EndDate.ToString("MMMM", CultureInfo.CreateSpecificCulture("ru")),
                            (dto.EndDate.Year % 100).ToString(),
                            dto.EndDate.Day.ToString(),
                            userDto.AuthorFullName,
                            userDto.AuthorFullName,
                            dto.StartDate.Day.ToString(),
                            dto.StartDate.ToString("MMMM", CultureInfo.CreateSpecificCulture("ru")),
                            (dto.StartDate.Year % 100).ToString(),
                            GenDirectorFullName
                        };
                        break;
                    case "dismissal":
                        filledFileName = "dismissal.doc";
                        oTemplate = Path.Combine(dir, DismissalFileName);
                        filledFilePath = Path.Combine(dir, filledFileName);
                        dtoParams = new string[]
                        {
                            dto.CreationDate.Day.ToString(),
                            dto.CreationDate.ToString("MMMM", CultureInfo.CreateSpecificCulture("ru")),
                            (dto.CreationDate.Year % 100).ToString(),
                            userDto.AuthorFullName,
                            userDto.AuthorFullName,
                            dto.StartDate.Day.ToString(),
                            dto.StartDate.ToString("MMMM", CultureInfo.CreateSpecificCulture("ru")),
                            (dto.StartDate.Year % 100).ToString(),
                            GenDirectorFullName
                        };
                        break;
                }

                oDoc = oWord.Documents.Add(ref oTemplate, ref oMissing,
                    ref oMissing, ref oMissing);

                Word.Bookmarks wBookmarks = oDoc.Bookmarks;
                Word.Range wRange;

                int i = 0;
                foreach (Word.Bookmark mark in wBookmarks)
                {
                    wRange = mark.Range;
                    wRange.Text = dtoParams[i];
                    i++;
                }

                if (File.Exists(filledFilePath))
                {
                    File.Delete(filledFilePath);
                }
                oDoc.SaveAs(filledFilePath);
                oDoc.Close();
                oDoc = null;
                oWord.Quit();

                return await _templates.GetAsync(filledFileName);
            }
            catch (Exception exc)
            {
                oDoc = null;
                oWord.Quit();
                _logger.LogError("Error on template fill in", exc);
                throw;
            }
        }
    }
}
