using FPIMusic.Services.Compilation;
using FPIMusic.Services.Deezer;
using FPIMusic.Services.Mediatheque;
using FPIMusic.Services.Scan.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services
{
    public interface IService
    {
        ICompilationService Compilation { get; }
        IMediathequeService Mediatheque { get; }
        IDeezerService Deezer { get; }
    }
}
