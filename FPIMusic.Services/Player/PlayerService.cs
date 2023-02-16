using FPIMusic.DataAccess;
using FPIMusic.Models;
using FPIMusic.Models.Player;
using NetCoreAudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPIMusic.Services.Player
{
    public class PlayerService : IPlayerService
    {
        private IRepoUnit context;
        private PlayerCurrentList PlayerCurrentList;
        private NetCoreAudio.Player Player;
        public PlayerService(IRepoUnit context)
        {
            this.context = context;
            PlayerCurrentList = new PlayerCurrentList();
            Player = new NetCoreAudio.Player();
            Player.PlaybackFinished += Player_PlaybackFinished;
        }

        private void Player_PlaybackFinished(object? sender, EventArgs e)
        {
            GetNextSongToPlay();
            this.Play();
        }

        public PlayerListStatus GetPlayerListStatus()
        {
            var status = PlayerCurrentList.GetPlayerListStatus();
            status.Pausing = Player.Paused;
            status.Playing= Player.Playing;
            return status;
        }
        public void PlaySong(int itemID, int songType)
        {
            PlayerCurrentList.ReInit();
            if ((SongType)songType == SongType.Mediatheque)
            {
                var item = context.MediathequeSongs.GetById(itemID);
                PlayerCurrentList.AddSong(item);
            }
            else if ((SongType)songType == SongType.Compilation)
            {
                var item = context.CompilationSongs.GetById(itemID);
                PlayerCurrentList.AddSong(item);
            }
            else if ((SongType)songType == SongType.Deezer)
            {
                var item = context.DeezerSongs.GetById(itemID);
                PlayerCurrentList.AddSong(item);
            }
            this.Play();
        }
        public void AddSong(int itemID, int songType)
        {
            if ((SongType)songType == SongType.Mediatheque)
            {
                var item = context.MediathequeSongs.GetById(itemID);
                PlayerCurrentList.AddSong(item);
            }
            else if ((SongType)songType == SongType.Compilation)
            {
                var item = context.CompilationSongs.GetById(itemID);
                PlayerCurrentList.AddSong(item);
            }
            else if ((SongType)songType == SongType.Deezer)
            {
                var item = context.DeezerSongs.GetById(itemID);
                PlayerCurrentList.AddSong(item);
            }
            if (PlayerCurrentList.IsEmpty) { this.Play(); }
        }
        public void AddPrioritizeSong(int itemID, int songType)
        {
            if ((SongType)songType == SongType.Mediatheque)
            {
                var item = context.MediathequeSongs.GetById(itemID);
                PlayerCurrentList.AddPrioritizeSong(item);
            }
            else if ((SongType)songType == SongType.Compilation)
            {
                var item = context.CompilationSongs.GetById(itemID);
                PlayerCurrentList.AddPrioritizeSong(item);
            }
            else if ((SongType)songType == SongType.Deezer)
            {
                var item = context.DeezerSongs.GetById(itemID);
                PlayerCurrentList.AddPrioritizeSong(item);
            }
            if (PlayerCurrentList.IsEmpty) { this.Play(); }
        }
        public void GetNextSongToPlay()
        {
            PlayerCurrentList.GetNextSongToPlay();
            Play();
        }
        public void GetPreviousSongToPlay()
        {
            PlayerCurrentList.GetPreviousSongToPlay();
            Play();
        }
        public void Play(Song song = null) 
        {
            if(song != null)
                Player.Play(song.Path);
            else
                Player.Play(PlayerCurrentList.CurrentSong.Path);
        }
        public void Pause() { Player.Pause(); }
        public void Resume() { Player.Resume(); }
        public void Stop() { Player.Stop(); }
        public void SetVolume(byte volume) { Player.SetVolume(volume); }
    }
}
