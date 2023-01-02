using FPIMusic.DataAccess;
using FPIMusic.Services.Scan.Implémentation;
using FPIMusic.Services.Scan.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services
{
    public class Scanner : IScanner
    {
        private readonly IRepoUnit _context;
        private readonly ISettingService _settings;
        public Scanner(IRepoUnit context, ISettingService settings)
        {
            _context = context;
            _settings = settings;
            Compilation = new ScanCompilation(_context, _settings);
            Mediatheque = new ScanMediatheque(_context, _settings);
            Deezer = new ScanDeezer(_context, _settings);
        }
        public IScanCompilation Compilation { get; private set; }

        public IScanMediatheque Mediatheque { get; private set; }

        public IScanDeezer Deezer { get; private set; }
    }
}
