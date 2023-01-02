using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services
{
    public class SettingService : ISettingService
    {
        public string CompilationPath { get; set; }

        public string MediathequePath { get; set; }

        public string DeezerPath { get; set; }
    }
}
