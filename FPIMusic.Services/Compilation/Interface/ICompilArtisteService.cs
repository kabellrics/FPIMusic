using FPIMusic.Models.Compilation;
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
        CompilExtendedArtiste Update(CompilationArtiste item);
        CompilExtendedArtiste GetById(int id);
        IEnumerable<CompilExtendedArtiste> GetByName(string name);
        IEnumerable<CompilExtendedArtiste> GetAll();
        IEnumerable<GroupedCompilExtendedArtiste> GetGrouped();
        IEnumerable<CompilExtendedArtiste> GetMostSongArtiste();
        IEnumerable<CompilExtendedArtiste> GetMostAlbumArtiste();
    }
}
