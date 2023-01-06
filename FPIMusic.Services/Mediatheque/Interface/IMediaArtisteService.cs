using FPIMusic.Models.Mediatheque;
using FPIMusic.Services.Mediatheque.ExtendedObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Mediatheque.Interface
{
    public interface IMediaArtisteService
    {
        MediaExtendedArtiste Update(MediathequeArtiste item);
        MediaExtendedArtiste GetById(int id);
        IEnumerable<MediaExtendedArtiste> GetByName(string name);
        IEnumerable<MediaExtendedArtiste> GetAll();
        IEnumerable<IGrouping<string, MediaExtendedArtiste>> GetGrouped();
    }
}
