using FPIMusic.Models.Deezer;
using FPIMusic.Services.Deezer.ExtendeObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Deezer.Interface
{
    public interface IDeezerAlbumService
    {
        DeezerExtendedAlbum Update(DeezerAlbum item);
        DeezerExtendedAlbum GetById(int id);
        IEnumerable<DeezerExtendedAlbum> GetByName(string name);
        IEnumerable<DeezerExtendedAlbum> GetAll();
        IEnumerable<GroupedDeezerExtendedAlbum> GetGrouped();
    }
}
