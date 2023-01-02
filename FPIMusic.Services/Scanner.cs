using FPIMusic.DataAccess;
using FPIMusic.Services.Implémentation;
using FPIMusic.Services.Interface;
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
        public Scanner(IRepoUnit context)
        {
            _context = context;
            Compilation = new ScanCompilation(_context);
            Mediatheque = new ScanMediatheque(_context);
            Deezer = new ScanDeezer(_context);
        }
        public IScanCompilation Compilation { get; private set; }

        public IScanMediatheque Mediatheque { get; private set; }

        public IScanDeezer Deezer { get; private set; }
    }
}
