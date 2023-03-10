using FPIMusic.Models.Deezer;
using FPIMusic.Services.Deezer.ExtendeObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Deezer.Interface
{
    public interface IDeezerPlaylistService
    {
        DeezerExtendedPlaylist Update(DeezerPlaylist item);
        DeezerExtendedPlaylist GetById(int id);
        IEnumerable<DeezerExtendedPlaylist> GetByName(string name);
        IEnumerable<DeezerExtendedPlaylist> GetAll();
        IEnumerable<GroupedDeezerExtendedPlaylist> GetGrouped();
    }
}
