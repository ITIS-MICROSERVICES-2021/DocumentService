using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Extensions.Options;
using System.Reflection;
using Newtonsoft.Json;

using DocumentService.DTOs;
using DocumentService.Options;

namespace DocumentService.Services
{
    /// <summary>
    /// Document service implementation
    /// </summary>
    public class DocumentService : IDocumentService
    {
        private readonly ILogger<DocumentService> _logger;
        private readonly RedisService _redisService;
        
        /// <summary>
        /// DI constructor
        /// </summary>
        public DocumentService(ILogger<DocumentService> logger, IOptions<RedisOptions> redisOptions)
        {
            _logger = logger;
             
            _redisService = new RedisService(redisOptions.Value.ConnectionString, 2);
        }
        
        /// <summary>
        /// Fill in template method implementation
        /// </summary>
        public void FillInTemplate(string type, long userId, VacationDTO dto)
        {
            Word._Document oDoc = null;
            Word._Application oWord = null;
            try
            {

                object oMissing = Missing.Value;
                oWord = new Word.Application();           
                object oTemplate = null;
                string filledFilePath = null;
                string[] dtoParams = null;
               
                _redisService.AddAsync("testKey", dto);
                Console.WriteLine(_redisService.GetAsync<VacationDTO>("testKey"));
                switch (type)
                {
                    case "vacation":
                        oTemplate = @"C:\.NetITIS\Dev\DocumentService\data\blank-zayavleniya-na-otpusk.doc";
                        filledFilePath = @"C:\.NetITIS\Dev\DocumentService\data\vacation.doc";
                        dtoParams = new string[] {dto.DateDay, dto.DateMonth, dto.DateYear, dto.Duration,
                            dto.EndDateMonth, dto.EndDateYear, dto.EndDateDay, dto.FromWhom,
                                dto.FullName, dto.StartDateDay, dto.StartDateMonth, dto.StartDateYear, dto.ToWhom };
                        break;
                    case "dismissal":
                        oTemplate = @"C:\.NetITIS\Dev\DocumentService\data\blank-zayavleniya-na-uvolnenie-po-sobstvennomu-zhelaniyu.doc";
                        filledFilePath = @"C:\.NetITIS\Dev\DocumentServicedata\dismissal.doc";
                        dtoParams = new string[] {dto.DateDay, dto.DateMonth, dto.DateYear, dto.FromWhom,
                                dto.FullName, dto.StartDateDay, dto.StartDateMonth, dto.StartDateYear, dto.ToWhom };
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