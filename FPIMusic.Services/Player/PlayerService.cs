using FPIMusic.DataAccess;
using FPIMusic.Models;
using FPIMusic.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Player
{
    public class PlayerService
    {
        private IRepoUnit context;
        private PlayerCurrentList PlayerCurrentList;
        public PlayerService(IRepoUnit context)
        {
            this.context = context;
            PlayerCurrentList = new PlayerCurrentList();
        }
        public PlayerListStatus GetPlayerListStatus() { return PlayerCurrentList.GetPlayerListStatus();}
        public void AddSong(int itemID, SongType SongType)
        {
            if(SongType == SongType.Mediatheque)
            {
                var item = context.MediathequeSongs.GetById(itemID);
                PlayerCurrentList.AddSong(item);
            }
            else if (SongType == SongType.Compilation)
            {
                var item = context.CompilationSongs.GetById(itemID);
                PlayerCurrentList.AddSong(item);
            }
            else if (SongType == SongType.Deezer)
            {
                var item = context.DeezerSongs.GetById(itemID);
                PlayerCurrentList.AddSong(item);
            }
        }
        public void AddPrioritizeSong(int itemID, SongType SongType)
        {
            if (SongType == SongType.Mediatheque)
            {
                var item = context.MediathequeSongs.GetById(itemID);
                PlayerCurrentList.AddPrioritizeSong(item);
            }
            else if (SongType == SongType.Compilation)
            {
                var item = context.CompilationSongs.GetById(itemID);
                PlayerCurrentList.AddPrioritizeSong(item);
            }
            else if (SongType == SongType.Deezer)
            {
                var item = context.DeezerSongs.GetById(itemID);
                PlayerCurrentList.AddPrioritizeSong(item);
            }
        }
        public Song GetNextSongToPlay() { return PlayerCurrentList.GetNextSongToPlay();}
        public Song GetPreviousSongToPlay() { return PlayerCurrentList.GetPreviousSongToPlay();}
    }
}
