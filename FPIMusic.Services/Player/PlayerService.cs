using FPIMusic.DataAccess;
using FPIMusic.Models;
using FPIMusic.Models.Player;
using FPIMusic.Services.Hub;
using Microsoft.AspNetCore.SignalR;
using NetCoreAudio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private IHubContext<MessageHub, IMessageHubClient> messageHub;
        public PlayerService(IRepoUnit context, IHubContext<MessageHub, IMessageHubClient> _messageHub)
        {
            this.context = context;
            messageHub = _messageHub;
            PlayerCurrentList = new PlayerCurrentList();
            Player = new NetCoreAudio.Player();
            Player.PlaybackFinished += Player_PlaybackFinished;
        }

        private void Player_PlaybackFinished(object? sender, EventArgs e)
        {
            PlayerCurrentList.SongFinishedPlay();
            GetNextSongToPlay();
            this.Play();
        }
        private void Player_SongFinished()
        {
            PlayerCurrentList.SongFinishedPlay();
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
                PlayerCurrentList.CurrentSong = item;
            }
            else if ((SongType)songType == SongType.Compilation)
            {
                var item = context.CompilationSongs.GetById(itemID);
                PlayerCurrentList.CurrentSong = item;
            }
            else if ((SongType)songType == SongType.Deezer)
            {
                var item = context.DeezerSongs.GetById(itemID);
                PlayerCurrentList.CurrentSong = item;
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
            if (!Player.Playing) { GetNextSongToPlay();Play(); }
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
            PlayerCurrentList.SongFinishedPlay();
            PlayerCurrentList.GetNextSongToPlay();
            //Play();
        }
        public void GetPreviousSongToPlay()
        {
            PlayerCurrentList.GetPreviousSongToPlay();
            //Play();
        }
        public void Play(Song song = null) 
        {
            var currentsong = song;
            if (currentsong == null)
                currentsong = PlayerCurrentList.CurrentSong;

            if (currentsong != null)
            {
                var songduration = TagLib.File.Create(currentsong.Path).Properties.Duration;
                if (song != null)
                    Player.Play(song.Path);
                else
                    Player.Play(PlayerCurrentList.CurrentSong.Path);
                messageHub.Clients.All.SendSynchroToClient("Synchro");
                //Watch.Restart();
            }
        }
        public void Pause() { Player.Pause();
            messageHub.Clients.All.SendSynchroToClient("Synchro");
        }
        public void Resume() {
            if (Player.Paused)
            {
                Player.Resume();
                messageHub.Clients.All.SendSynchroToClient("Synchro");
            }
            else
            {
                this.Play();
            }
        }
        public void Stop() { Player.Stop();
            messageHub.Clients.All.SendSynchroToClient("Synchro");
        }
        public void SetVolume(byte volume) { Player.SetVolume(volume); }
        public void Schuffle()
        {
            PlayerCurrentList.IsShuffle = !PlayerCurrentList.IsShuffle;
            messageHub.Clients.All.SendSynchroToClient("Synchro");
        }
    }
}
