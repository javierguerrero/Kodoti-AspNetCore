using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class Song
    {
        public long SongId { get; set; }
        public string Name { get; set; }
        public TimeSpan DurationTime { get; set; }

        public Album Album { get; set; }
        public int AlbumId { get; set; }
    }
}
