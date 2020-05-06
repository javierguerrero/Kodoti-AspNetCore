using DtoLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrontEnd.Views.Shared.Components.ArtistComponent
{
    public class ArtistComponent : ViewComponent
    {
        private readonly IArtistService _artistService;
        private readonly IMemoryCache _memoryCache;
        private const string key = "ArtistComponentKey";

        public ArtistComponent(IMemoryCache memoryCache, IArtistService artistService)
        {
            _memoryCache = memoryCache;
            _artistService = artistService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = _memoryCache.Get<IEnumerable<ArtistDto>>(key);

            if (result == null)
            {
                result = await _artistService.GetRandom();
                _memoryCache.Set(key, result, TimeSpan.FromHours(1));
            }

            return View(result);
        }
    }
}