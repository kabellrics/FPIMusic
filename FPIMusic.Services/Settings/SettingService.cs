using FPIMusic.DataAccess;
using FPIMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Settings
{
    public class SettingService : ISettingService
    {
        private readonly ISettingsRepository _context;
        public SettingService(ISettingsRepository context)
        {
            _context = context;
        }
        public void SetCompilationPath(string path)
        {
            var setting = _context.GetById(2);
            setting.Value = path;
            _context.Save(setting);
        }
        public void SetMediathequePath(string path)
        {
            var setting = _context.GetById(1);
            setting.Value = path;
            _context.Save(setting);
        }
        public void SetDeezerPath(string path)
        {
            var setting = _context.GetById(3);
            setting.Value = path;
            _context.Save(setting);
        }
        public DBParameter CompilationPath { get { return _context.GetById(2); } }

        public DBParameter MediathequePath { get { return _context.GetById(1); } }

        public DBParameter DeezerPath { get { return _context.GetById(3); } }


    }
}
