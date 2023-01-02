﻿using FPIMusic.DataAccess;
using FPIMusic.Services.Compilation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Compilation.Implementation
{
    public class CompilSongService : ICompilSongService
    {
        private IRepoUnit context;
        private ISettingService settings;

        public CompilSongService(IRepoUnit context, ISettingService settings)
        {
            this.context = context;
            this.settings = settings;
        }
    }
}