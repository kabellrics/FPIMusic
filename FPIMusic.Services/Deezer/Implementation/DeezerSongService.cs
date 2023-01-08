using FPIMusic.DataAccess;
using FPIMusic.Models.Compilation;
using FPIMusic.Models.Deezer;
using FPIMusic.Services.Compilation.ExtendedObject;
using FPIMusic.Services.Deezer.Interface;
using FPIMusic.Services.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Deezer.Implementation
{
    public class DeezerSongService : IDeezerSongService
    {
        private IRepoUnit context;
        private ISettingService settings;

        public DeezerSongService(IRepoUnit context, ISettingService settings)
        {
            this.context = context;
            this.settings = settings;
        }
        public DeezerSong Update(DeezerSong item)
        {
            return context.DeezerSongs.Save(item);
        }
        public DeezerSong GetById(int id)
        {
            return context.DeezerSongs.GetById(id);
        }
        public IEnumerable<DeezerSong> GetByArtisteId(int id)
        {
            return context.DeezerSongs.Find(x => x.ArtisteId == id).OrderBy(x => x.Piste);
        }

        public IEnumerable<DeezerSong> GetByAlbumId(int id)
        {
            return context.DeezerSongs.Find(x => x.AlbumId == id).OrderBy(x => x.Piste); ;
        }
        public IEnumerable<DeezerSong> GetByPlaylistid(int id)
        {
            return context.DeezerSongs.Find(x => x.PlaylistId == id).OrderBy(x => x.Piste); ;
        }
    }
}
