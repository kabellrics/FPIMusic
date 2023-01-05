using FPIMusic.DataAccess;
using FPIMusic.Models.Compilation;
using FPIMusic.Services.Compilation.ExtendedObject;
using FPIMusic.Services.Compilation.Interface;
using FPIMusic.Services.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Compilation.Implementation
{
    public class CompilSongService : ICompilSongService
    {
        private IRepoUnit context;
        private ISettingService settings;

        public CompilSongService(IRepoUnit context, ISettingService settings)
        {
            this.context = context;
            this.settings = settings;
        }
        public CompilationSong Update(CompilationSong item)
        {
            return context.CompilationSongs.Save(item);
        }
        public CompilationSong GetById(int id)
        {
            return context.CompilationSongs.GetById(id);
        }
        public IEnumerable<CompilationSong> GetByArtisteId(int id)
        {
            return context.CompilationSongs.Find(x=>x.ArtisteId == id).OrderBy(x=>x.Piste);
        }

        public IEnumerable<CompilationSong> GetByAlbumId(int id)
        {
            return context.CompilationSongs.Find(x => x.AlbumId == id).OrderBy(x => x.Piste); ;
        }
    }
}
