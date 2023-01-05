using FPIMusic.Models.Compilation;
using FPIMusic.Models.Mediatheque;
using FPIMusic.Models.Deezer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPIMusic.Models;
using System.Reflection.Emit;

namespace FPIMusic.DataAccess
{
    public class FPIMusicRepository : DbContext
    {
        public DbSet<CompilationAlbum> CompilationAlbums { get; set; }
        public DbSet<CompilationArtiste> CompilationArtistes { get; set; }
        public DbSet<CompilationSong> CompilationSongs { get; set; }
        public DbSet<MediathequeAlbum> MediathequeAlbums { get; set; }
        public DbSet<MediathequeArtiste> MediathequeArtistes { get; set; }
        public DbSet<MediathequeSong> MediathequeSongs { get; set; }
        public DbSet<DeezerAlbum> DeezerAlbums { get; set; }
        public DbSet<DeezerArtiste> DeezerArtistes { get; set; }
        public DbSet<DeezerPlaylist> DeezerPlaylists { get; set; }
        public DbSet<DeezerSong> DeezerSongs { get; set; }
        public DbSet<DBParameter> Parametre { get; set; }
        public string DbPath { get; }

        public FPIMusicRepository()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Path.Combine(Environment.GetFolderPath(folder),"FPIMusic");
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(folder), "FPIMusic")))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(folder), "FPIMusic"));
            DbPath = System.IO.Path.Join(path, "FPIMusic.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
        //{
        //options.UseSqlite("Filename=bookzilla.db");
        //options.UseSqlite("Data Source=bookzilla.db");
        //Database.EnsureCreated();
        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CompilationSong>()
                .HasIndex(u => u.Path)
                .IsUnique();
            builder.Entity<DeezerSong>()
                .HasIndex(u => u.Path)
                .IsUnique();
            builder.Entity<MediathequeSong>()
                .HasIndex(u => u.Path)
                .IsUnique();

            builder.Entity<DBParameter>().HasData(
                new DBParameter()
                {
                    Id = 1,
                    Key = "MediathequePath",
                    Value = string.Empty,
                });
            builder.Entity<DBParameter>().HasData(
                new DBParameter()
                {
                    Id = 2,
                    Key = "CompilationPath",
                    Value = string.Empty,
                });
            builder.Entity<DBParameter>().HasData(
                new DBParameter()
                {
                    Id = 3,
                    Key = "DeezerPath",
                    Value = string.Empty,
                });
        }
    }
}
