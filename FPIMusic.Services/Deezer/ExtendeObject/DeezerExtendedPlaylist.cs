using FPIMusic.Models.Deezer;
using FPIMusic.Services.Mediatheque.ExtendedObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Deezer.ExtendeObject
{
    public class DeezerExtendedPlaylist:DeezerPlaylist
    {
        public int NbSong { get; set; }
        public int NbAlbum { get; set; }
        public int NbArtiste { get; set; }
    }
    public class GroupedDeezerExtendedPlaylist
    {
        public string Key { get; set; }
        public IEnumerable<DeezerExtendedPlaylist> Items { get; set; }
    }
}
