using FPIMusic.Services.Compilation.ExtendedObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Compilation.Interface
{
    public interface ICompilArtisteService
    {
        CompilExtendedArtiste GetById(int id);
        IEnumerable<CompilExtendedArtiste> GetByName(string name);
        IEnumerable<CompilExtendedArtiste> GetAll();
        IEnumerable<IGrouping<char, CompilExtendedArtiste>> GetGrouped();
    }
}
