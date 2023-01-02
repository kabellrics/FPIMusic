using FPIMusic.DataAccess;
using FPIMusic.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Implémentation
{
    public class ScanMediatheque : IScanMediatheque
    {
        private IRepoUnit context;

        public ScanMediatheque(IRepoUnit context)
        {
            this.context = context;
        }
    }
}
