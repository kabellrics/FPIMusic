using FPIMusic.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services
{
    public interface ISettingService
    {
        public string CompilationPath { get; }
        public string MediathequePath { get; }
        public string DeezerPath { get; }
    }
}
