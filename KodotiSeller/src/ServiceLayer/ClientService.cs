using AutoMapper;
using DtoLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PersistenceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAll();
    }

    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public ClientService(ApplicationDbContext context, ILogger<ClientService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<ClientDto>> GetAll()
        {
            var result = new List<ClientDto>();

            try
            {
                var records = await _context.Clients.OrderBy(x => x.Name).ToListAsync();
                result = Mapper.Map<List<ClientDto>>(records);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }
    }
}
