using Microsoft.Extensions.Logging;
using System;

namespace KODOTI.Services
{
    public class EmailProviderAService : IEmailProviderService
    {
        private readonly ILogger _logger;

        public EmailProviderAService(ILogger<EmailProviderAService> logger)
        {
            _logger = logger;
        }

        public string Send()
        {
            _logger.LogInformation($"Trabajando con {this.GetType().Name}");

            var success = false;

            if (success)
            {
                _logger.LogInformation("Se pudo conectar al proveedor");
            }
            else
            {
                _logger.LogWarning("No se pudo conectar al proveedor");
            }

            var body = "cuerpo del mensaje";
            var subject = "asunto del mensaje";

            _logger.LogInformation("Se preparó el cuerpo");

            try
            {
                throw new Exception("se perdió la conexión con el proveedor");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return this.GetType().Name;
        }
    }

    public class EmailProviderBService : IEmailProviderService
    {
        public string Send()
        {
            return this.GetType().Name;
        }
    }
}