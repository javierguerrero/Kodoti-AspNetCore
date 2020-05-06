using DtoLayer;
using FrontEnd.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ServiceLayer;
using System;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class ArtistController : Controller
    {
        private readonly IArtistService _artistService;
        private readonly IAlbumService _albumService;
        private readonly ISongService _songService;
        private readonly IMemoryCache _memoryCache;

        private const string ArtistDetailKey = "ArtistDetailKey_{0}";

        public ArtistController(
            IMemoryCache memoryCache,
            IArtistService artistService,
            IAlbumService albumService,
            ISongService songService,
            IHostingEnvironment hostingEnvironment)
        {
            _memoryCache = memoryCache;
            _artistService = artistService;
            _albumService = albumService;
            _songService = songService;
        }

        public async Task<IActionResult> Index(int p = 1)
        {
            ViewData["page"] = p;

            return View(
                await _artistService.GetPaged(p)
            );
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ArtistCreateDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _artistService.Create(model);
                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }

                throw new Exception("NO se pudo crear el artista");
            }

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet("/a/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var key = string.Format(ArtistDetailKey, id);
            var result = _memoryCache.Get<ArtistDto>(key);

            if (result == null)
            {
                result = await _artistService.GetFull(id);
                _memoryCache.Set(key, result, TimeSpan.FromDays(1));
            }

            return View(result);
        }

        public async Task<IActionResult> Update(int id)
        {
            return View(await _artistService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ArtistUpdateDto model, IFormFile file = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _artistService.Update(model, file);

                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }

                throw new Exception("No se pudo actualizar el artista");
            }

            return View(model);
        }

        [HttpGet("/artist/{artistId}/album")]
        public async Task<IActionResult> Album(int artistId)
        {
            var artist = await _artistService.Get(artistId);
            var albums = await _albumService.GetAllByArtist(artistId);

            return View(new AlbumViewModel { 
                ArtistId = artist.ArtistId,
                ArtistName = artist.Name,
                Albums = albums
            });
        }

        public async Task<IActionResult> AddAlbum(AlbumCreateDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _albumService.Create(model);
                
                if (result.IsSuccess)
                {
                    return RedirectToAction("Album", new { artistId = model.ArtistId });
                }
                throw new Exception("No se puedo agregar el album.");
            }

            // volvemos a pasar el modelo en caso falle para que cargue la data de nuevo
            var artist = await _artistService.Get(model.ArtistId);
            var albums = await _albumService.GetAllByArtist(model.ArtistId);
            var resultViewModel = new AlbumViewModel
            {
                ArtistId = artist.ArtistId,
                ArtistName = artist.Name,
                Albums = albums
            };

            // especificamos la ruta de la vista manualmente
            return View("Album", resultViewModel);
        }

        public async Task<IActionResult> AddSong(SongCreateDto model, int artistId)
        {
            if (ModelState.IsValid)
            {
                var result = await _songService.Create(model);

                if (result.IsSuccess)
                {
                    return RedirectToAction("Album", new { artistId });
                }
                throw new Exception("No se puedo agregar el album.");
            }
            else
            {
                ModelState.AddModelError("SongCreation", "No se pudo registrar la canción");
            }

            // volvemos a pasar el modelo en caso falle para que cargue la data de nuevo
            var artist = await _artistService.Get(artistId);
            var albums = await _albumService.GetAllByArtist(artistId);
            var resultViewModel = new AlbumViewModel
            {
                ArtistId = artist.ArtistId,
                ArtistName = artist.Name,
                Albums = albums
            };

            // especificamos la ruta de la vista manualmente
            return View("Album", resultViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _artistService.Delete(id);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }

            throw new Exception("No se puede eliminar el artista");
        }
    }
}