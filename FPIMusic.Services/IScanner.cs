using FPIMusic.Services.Scan.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services
{
    public interface IScanner
    {
        IScanCompilation Compilation { get; }
        IScanMediatheque Mediatheque { get; }
        IScanDeezer Deezer { get; }
    }
}
