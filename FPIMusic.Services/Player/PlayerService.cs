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
            this.Play(GetNextSongToPlay());
        }

        public PlayerListStatus GetPlayerListStatus()
        {
            var status = PlayerCurrentList.GetPlayerListStatus();
            status.Pausing = Player.Paused;
            status.Playing= Player.Playing;
            return status;
        }
        public void AddSong(int itemID, SongType SongType)
        {
            if (SongType == SongType.Mediatheque)
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
            if (Player.Playing == false) { this.Play(GetNextSongToPlay()); }
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
        public Song GetNextSongToPlay() { return PlayerCurrentList.GetNextSongToPlay(); }
        public Song GetPreviousSongToPlay() { return PlayerCurrentList.GetPreviousSongToPlay(); }
        public void Play(Song song) { Player.Play(song.Path); }
        public void Pause() { Player.Pause(); }
        public void Resume() { Player.Resume(); }
        public void Stop() { Player.Stop(); }
        public void SetVolume(byte volume) { Player.SetVolume(volume); }
    }
}
