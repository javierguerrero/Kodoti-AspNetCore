using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KODOTI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KODOTI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IEmailProviderService _emailProviderService;
        private readonly ILogger _logger;

        public DefaultController(
            IEmailProviderService emailProviderService, 
            ILogger<DefaultController> logger)
        {
            _emailProviderService = emailProviderService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Hello world");
            return Ok(_emailProviderService.Send());
        }
    }
}