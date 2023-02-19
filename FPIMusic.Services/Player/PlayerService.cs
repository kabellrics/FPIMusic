using FPIMusic.DataAccess;
using FPIMusic.Models;
using FPIMusic.Models.Player;
using FPIMusic.Services.Hub;
using FPIMusic.Services.Settings;
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
        //private IRepoUnit context;
        private PlayerCurrentList PlayerCurrentList;
        private NetCoreAudio.Player Player;
        private IHubContext<Models.MessageHub> messageHub;
        public PlayerService(/*IRepoUnit context,*/ IHubContext<Models.MessageHub> _messageHub)
        {
            //this.context = context;
            messageHub = _messageHub;
            this.PlayerCurrentList = PlayerCurrentList.Instance;
            Player = new NetCoreAudio.Player();
            Player.PlaybackFinished += Player_PlaybackFinished;
        }

        private void Player_PlaybackFinished(object? sender, EventArgs e)
        {
            this.PlayerCurrentList.SongFinishedPlay();
            GetNextSongToPlay();
            this.Play();
        }
        private void Player_SongFinished()
        {
            this.PlayerCurrentList.SongFinishedPlay();
            GetNextSongToPlay();
            this.Play();
        }

        public PlayerListStatus GetPlayerListStatus()
        {
            var status = this.PlayerCurrentList.GetPlayerListStatus();
            status.Pausing = this.PlayerCurrentList.Paused;
            status.Playing= this.PlayerCurrentList.Playing;
            return status;
        }
        public void PlaySong(Song item)
        {
            this.PlayerCurrentList.Stop();
            this.PlayerCurrentList.ReInit();
            //this.Player = new NetCoreAudio.Player();
            this.PlayerCurrentList.CurrentSong = item;
            this.Play();
        }
        public void AddSong(Song item)
        {
            this.PlayerCurrentList.AddSong(item);
            if (this.PlayerCurrentList.Playing) { GetNextSongToPlay();Play(); }
        }
        public void AddPrioritizeSong(Song item)
        {
            this.PlayerCurrentList.AddPrioritizeSong(item);
            if (this.PlayerCurrentList.IsEmpty) { this.Play(); }
        }
        public void GetNextSongToPlay()
        {
            this.PlayerCurrentList.SongFinishedPlay();
            this.PlayerCurrentList.GetNextSongToPlay();
            //Play();
        }
        public void GetPreviousSongToPlay()
        {
            this.PlayerCurrentList.GetPreviousSongToPlay();
            //Play();
        }
        public void Play(Song song = null) 
        {
            this.PlayerCurrentList.Play();
            //var currentsong = song;
            //if (currentsong == null)
            //    currentsong = PlayerCurrentList.CurrentSong;

            //if (currentsong != null)
            //{
            //    var songduration = TagLib.File.Create(currentsong.Path).Properties.Duration;
            //    if (song != null)
            //        Player.Play(song.Path);
            //    else
            //        Player.Play(PlayerCurrentList.CurrentSong.Path);
                messageHub.Clients.All.SendAsync("Synchro","Play");
                //Watch.Restart();
            //}
        }
        public void Pause() {

            this.PlayerCurrentList.Pause();
            messageHub.Clients.All.SendAsync("Synchro", "Pause");
        }
        public void Resume() {
            this.PlayerCurrentList.Resume();
            //if (Player.Paused)
            //{
            //    Player.Resume();
                messageHub.Clients.All.SendAsync("Synchro", "Resume");
            //}
            //else
            //{
            //    this.Play();
            //}
        }
        public void Stop() {
            this.PlayerCurrentList.Stop();
            messageHub.Clients.All.SendAsync("Synchro", "Stop");
        }
        public void SetVolume(byte volume) { PlayerCurrentList.SetVolume(volume); }
        public void Schuffle()
        {
            this.PlayerCurrentList.Schuffle();
            //PlayerCurrentList.IsShuffle = !PlayerCurrentList.IsShuffle;
            messageHub.Clients.All.SendAsync("Synchro", "Schuffle");
        }
    }
}
