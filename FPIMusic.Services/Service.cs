using FPIMusic.DataAccess;
using FPIMusic.Services.Compilation;
using FPIMusic.Services.Deezer;
using FPIMusic.Services.Mediatheque;
using FPIMusic.Services.Scan.Implémentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services
{
    public class Service : IService
    {
        private readonly IRepoUnit _context;
        private readonly ISettingService _settings;
        public Service(IRepoUnit context, ISettingService settings)
        {
            _context = context;
            _settings = settings;
            Compilation = new CompilationService(_context, _settings);
            Mediatheque = new MediathequeService(_context, _settings);
            Deezer = new DeezerService(_context, _settings);
        }
        public ICompilationService Compilation { get; private set; }

        public IMediathequeService Mediatheque { get; private set; }

        public IDeezerService Deezer { get; private set; }
    }
}
