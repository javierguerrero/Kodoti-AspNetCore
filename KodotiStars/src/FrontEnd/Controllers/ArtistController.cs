﻿using DtoLayer;
using FrontEnd.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IHostingEnvironment _hostingEnvironment;

        public ArtistController(
            IArtistService artistService,
            IAlbumService albumService,
            IHostingEnvironment hostingEnvironment)
        {
            _artistService = artistService;
            _albumService = albumService;
            _hostingEnvironment = hostingEnvironment;
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

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}