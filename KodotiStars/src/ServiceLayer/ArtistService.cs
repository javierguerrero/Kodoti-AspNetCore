﻿using AutoMapper;
using CommonLayer;
using DomainLayer;
using DtoLayer;
using Microsoft.Extensions.Logging;
using PersistenceLayer;
using System;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IArtistService
    {
        Task<ResponseHelper> Create(ArtistCreateDto model);
    }

    public class ArtistService : IArtistService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ArtistService> _logger;

        public ArtistService(ApplicationDbContext context, ILogger<ArtistService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ResponseHelper> Create(ArtistCreateDto model)
        {
            var result = new ResponseHelper();

            try
            {
                var entry = Mapper.Map<Artist>(model);
                entry.LogoUrl = "default.jpg";

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