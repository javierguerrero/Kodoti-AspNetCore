using AutoMapper;
using DtoLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PersistenceLayer;
using System;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IInvoiceNumberService
    {
        Task<InvoiceNumberDto> GetCurrent();
    }

    public class InvoiceNumberService : IInvoiceNumberService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public InvoiceNumberService(ApplicationDbContext context, ILogger<ProductService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<InvoiceNumberDto> GetCurrent()
        {
            var result = new InvoiceNumberDto();

            try
            {
                result = Mapper.Map<InvoiceNumberDto>(
                    await _context.InvoiceNumbers.SingleAsync(x => x.Year == DateTime.Now.Year)
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }
    }
}