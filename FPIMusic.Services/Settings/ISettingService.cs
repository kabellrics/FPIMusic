using FPIMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Settings
{
    public interface ISettingService
    {
        public DBParameter CompilationPath { get; }
        public DBParameter MediathequePath { get; }
        public DBParameter DeezerPath { get; }
        void SetCompilationPath(string path);
        void SetMediathequePath(string path);
        void SetDeezerPath(string path);
    }
}
