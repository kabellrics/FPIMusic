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
    public class CompilArtisteService : ICompilArtisteService
    {
        private IRepoUnit context;
        private ISettingService settings;

        public CompilArtisteService(IRepoUnit context, ISettingService settings)
        {
            this.context = context;
            this.settings = settings;
        }
        private CompilExtendedArtiste CreateExtended(CompilationArtiste alb)
        {
            CompilExtendedArtiste extalb = (CompilExtendedArtiste)alb;
            var songs = context.CompilationSongs.Find(x => x.ArtisteId == extalb.Id);
            extalb.NbSong = songs.Count();
            extalb.NbAlbum = songs.GroupBy(x => x.AlbumId).Count();
            return extalb;
        }
        public CompilExtendedArtiste Update(CompilationArtiste item)
        {
            return CreateExtended(context.CompilationArtistes.Save(item));
        }
        public CompilExtendedArtiste GetById(int id)
        {
            return CreateExtended(context.CompilationArtistes.GetById(id));
        }
        public IEnumerable<CompilExtendedArtiste> GetByName(string name)
        {
            return context.CompilationArtistes.Find(x => x.Name.Contains(name)).Select(x => CreateExtended(x));
        }
        public IEnumerable<CompilExtendedArtiste> GetAll()
        {
            return context.CompilationArtistes.GetAll().Select(x => CreateExtended(x));
        }
        public IEnumerable<IGrouping<char, CompilExtendedArtiste>> GetGrouped()
        {
            var arts = context.CompilationArtistes.GetAll();
            return from art in arts
                   group CreateExtended(art) by art.Name[0];
        }
    }
}
