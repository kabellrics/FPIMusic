using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Models.Mediatheque
{
    public class MediathequeSong:Song
    {
        public MediathequeSong() { SongType = SongType.Mediatheque; }
        public int AlbumId { get; set; }
    }
}
