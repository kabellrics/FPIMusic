using FPIMusic.Models.Deezer;
using FPIMusic.Services.Mediatheque.ExtendedObject;
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
    public class GroupedDeezerExtendedAlbum
    {
        public string Key { get; set; }
        public IEnumerable<DeezerExtendedAlbum> Items { get; set; }
    }
}
