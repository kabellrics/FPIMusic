using FPIMusic.DataAccess;
using FPIMusic.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Implémentation
{
    public class ScanDeezer : IScanDeezer
    {
        private IRepoUnit context;

        public ScanDeezer(IRepoUnit context)
        {
            this.context = context;
        }
    }
}
