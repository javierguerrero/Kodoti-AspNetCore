using DtoLayer;
using System.Collections.Generic;

namespace FrontEnd.ViewModels
{
    public class AlbumViewModel
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public IEnumerable<AlbumDto> Albums { get; set; }
    }
}