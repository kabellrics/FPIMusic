using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Models
{
    public class EnumContainer
    {
    }
    public enum SongType
    {
        Mediatheque,
        Compilation,
        Deezer
    }
    public enum AutoPlaylistElementType
    {
        MediathequeArtiste,
        MediathequeAlbum,
        CompilationArtiste,
        CompilationAlbum,
        DeezerArtiste,
        DeezerAlbum,
        DeezerPlaylist
    }
}
