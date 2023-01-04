using FPIMusic.Services.Compilation.ExtendedObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Compilation.Interface
{
    public interface ICompilAlbumService
    {
        CompilExtendedAlbum GetById(int id);
        IEnumerable<CompilExtendedAlbum> GetByName(string name);
        IEnumerable<CompilExtendedAlbum> GetAll();
        IEnumerable<IGrouping<char, CompilExtendedAlbum>> GetGrouped();
    }
}
