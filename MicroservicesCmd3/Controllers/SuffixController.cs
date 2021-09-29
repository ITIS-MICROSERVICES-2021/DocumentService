using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroservicesCmd3.Controllers
{
    [ApiController]
    [Route("/api/suffix")]
    public class SuffixController : ControllerBase
    {
        private readonly ILogger<SuffixController> _logger;

        public SuffixController(ILogger<SuffixController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get(string text)
        {
            return text + "_" + Guid.NewGuid();
        }
    }
}