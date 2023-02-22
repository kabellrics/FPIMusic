using FPIMusic.DataAccess;
using FPIMusic.Models;
using FPIMusic.Models.Player;
using FPIMusic.Services.Settings;
using LibVLCSharp.Shared;
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
        private IHubContext<Models.MessageHub> messageHub;
        LibVLC libvlc;
        MediaPlayer mediaPlayer;
        public PlayerService( IHubContext<Models.MessageHub> _messageHub)
        {
            //this.context = context;
            messageHub = _messageHub;
            this.PlayerCurrentList = new PlayerCurrentList();
            libvlc = new LibVLC(enableDebugLogs:true);
            mediaPlayer = new MediaPlayer(libvlc);
            mediaPlayer.EndReached += MediaPlayer_EndReached;
        }

        private void MediaPlayer_EndReached(object? sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(_=> Player_SongFinished());
            
        }

        private void Player_PlaybackFinished(object? sender, EventArgs e)
        {
            Player_SongFinished();
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
            status.Pausing = !mediaPlayer.IsPlaying;
            status.Playing= mediaPlayer.IsPlaying;
            status.Volume= mediaPlayer.Volume;
            return status;
        }
        public void PlaySong(Song item)
        {
            this.PlayerCurrentList.ReInit();
            this.PlayerCurrentList.CurrentSong = item;
            this.Play();
        }
        public void AddSong(Song item)
        {
            if (this.PlayerCurrentList.IsEmpty)
            {
                this.PlayerCurrentList.AddSong(item);
                GetNextSongToPlay();
                Play();
            }
            else
            {
                this.PlayerCurrentList.AddSong(item);
            }
        }
        public void AddPrioritizeSong(Song item)
        {
            this.PlayerCurrentList.AddPrioritizeSong(item);
            if (this.PlayerCurrentList.IsEmpty) { this.Play(); }
        }
        public void GetNextSongToPlay()
        {
            this.PlayerCurrentList.GetNextSongToPlay();
        }
        public void GetPreviousSongToPlay()
        {
            this.PlayerCurrentList.GetPreviousSongToPlay();
        }
        public void NextSong()
        {
            this.PlayerCurrentList.SongFinishedPlay();
            this.PlayerCurrentList.GetNextSongToPlay();
        }
        public void PreviousSong()
        {
            this.PlayerCurrentList.GetPreviousSongToPlay();
        }
        public void Play(Song song = null) 
        {
            //this.PlayerCurrentList.Play();
            try
            {
                var currentsong = song;
                if (currentsong == null)
                    currentsong = PlayerCurrentList.CurrentSong;

                if (PlayerCurrentList.CurrentSong != null)
                {
                    var media = new Media(libvlc, new Uri(currentsong.Path));
                    //mediaPlayer.Stop();
                    mediaPlayer.Play(media);
                    messageHub.Clients.All.SendAsync("Synchro", "Play"); 
                }
            }
            catch (Exception ex)
            {
                //throw;
            }
        }
        public void Pause() {

            this.mediaPlayer.Pause();
            messageHub.Clients.All.SendAsync("Synchro", "Pause");
        }
        public void Resume() {
            //this.PlayerCurrentList.Resume();
                this.mediaPlayer.Play();
                messageHub.Clients.All.SendAsync("Synchro", "Resume");
        }
        public void Stop() {
            this.mediaPlayer.Stop();
            messageHub.Clients.All.SendAsync("Synchro", "Stop");
        }
        public void SetVolume(int volume)
        {
            if(volume>=0 && volume <=100)
            mediaPlayer.Volume =volume;
            messageHub.Clients.All.SendAsync("Synchro", "Volume");
        }
        public void Schuffle()
        {
            this.PlayerCurrentList.Schuffle();
            //PlayerCurrentList.IsShuffle = !PlayerCurrentList.IsShuffle;
            messageHub.Clients.All.SendAsync("Synchro", "Schuffle");
        }
    }
}
