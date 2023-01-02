using FPIMusic.DataAccess;
using FPIMusic.Services.Compilation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Compilation.Implementation
{
    public class CompilArtisteService : ICompilArtisteService
    {
        private IRepoUnit context;
        private ISettingService settings;

        public CompilArtisteService(IRepoUnit context, ISettingService settings)
        {
            this.context = context;
            this.settings = settings;
        }
    }
}
