using System;
using System.Collections;
using System.Collections.Generic;

namespace DtoLayer
{
    public abstract class AlbumBaseDto
    {
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ArtistId { get; set; }
    }

    public class AlbumDto : AlbumBaseDto
    {
        public ArtistDto Artist { get; set; }
        public IEnumerable<SongDto> Songs { get; set; }
    }

    public class AlbumCreateDto : AlbumBaseDto
    {
    }
}