using FPIMusic.Models.Deezer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Deezer.ExtendeObject
{
    public class DeezerExtendedAlbum:DeezerAlbum
    {
        public int NbSong { get; set; }
        public int NbPlaylist { get; set; }
        public int NbArtiste { get; set; }
    }
}
