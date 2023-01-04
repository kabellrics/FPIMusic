using FPIMusic.Services.Deezer.ExtendeObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Deezer.Interface
{
    public interface IDeezerArtisteService
    {
        DeezerExtendedArtiste GetById(int id);
        IEnumerable<DeezerExtendedArtiste> GetByName(string name);
        IEnumerable<DeezerExtendedArtiste> GetAll();
        IEnumerable<IGrouping<char, DeezerExtendedArtiste>> GetGrouped();
    }
}
