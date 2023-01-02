using FPIMusic.DataAccess;
using FPIMusic.Services.Compilation.Implementation;
using FPIMusic.Services.Compilation.Interface;
using FPIMusic.Services.Scan.Implémentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Compilation
{
    public class CompilationService: ICompilationService
    {
        private readonly IRepoUnit _context;
        private readonly ISettingService _settings;
        public CompilationService(IRepoUnit context, ISettingService settings)
        {
            _context = context;
            _settings = settings;
            Albums = new CompilAlbumService(_context, _settings);
            Artistes = new CompilArtisteService(_context, _settings);
            Song = new CompilSongService(_context, _settings);
        }
        public ICompilAlbumService Albums { get; private set; }
        public ICompilArtisteService Artistes { get; private set; }
        public ICompilSongService Song { get; private set; }
    }
}
