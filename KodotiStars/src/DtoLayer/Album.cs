using System;

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
    }

    public class AlbumCreateDto : AlbumBaseDto
    {
    }
}