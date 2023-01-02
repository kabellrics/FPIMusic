using FPIMusic.DataAccess;
using FPIMusic.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Implémentation
{
    public class ScanCompilation : IScanCompilation
    {
        private IRepoUnit context;

        public ScanCompilation(IRepoUnit context)
        {
            this.context = context;
        }
    }
}
