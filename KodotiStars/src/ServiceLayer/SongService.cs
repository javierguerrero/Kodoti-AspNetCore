using AutoMapper;
using CommonLayer;
using DomainLayer;
using DtoLayer;
using Microsoft.Extensions.Logging;
using PersistenceLayer;
using System;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface ISongService
    {
        Task<ResponseHelper> Create(SongCreateDto model);
    }

    public class SongService : ISongService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public SongService(ApplicationDbContext context, ILogger<SongService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseHelper> Create(SongCreateDto model)
        {
            var result = new ResponseHelper();

            try
            {
                var entry = Mapper.Map<Song>(model);
                entry.DurationTime = TimeSpan.FromSeconds(model.DurationTime);

                await _context.AddAsync(entry);
                await _context.SaveChangesAsync();

                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return result;
        }
    }
}
