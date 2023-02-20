using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FPIMusic.Models.Player
{
    public class PlayerCurrentList
    {
        //private static PlayerCurrentList instance = null;
        //private static readonly object padlock = new object();

        private Queue<Song> SongToPlay;
        private Queue<Song> ShuffleSongToPlay;
        private Stack<Song> SongPrioritizetoPlay;
        private List<Song> SongAlreadyPlay;
        private List<Song> ShuffleSongAlreadyPlay;
        //private NetCoreAudio.Player Player;
        public Song CurrentSong { get; set; }
        private bool _Paused;
        public bool Paused
        {
            get { return /*Player.Paused;*/false; }
            //set { _Paused = value; SetShuffleValue(); }
        }
        private bool _Playing;
        public bool Playing
        {
            get { return /*Player.Playing;*/false; }
            //set { _Paused = value; SetShuffleValue(); }
        }
        private bool _IsShuffle;
        public bool IsShuffle
        {
            get { return _IsShuffle; }
            set { _IsShuffle = value; SetShuffleValue(); }
        }
        private bool _IsLooping;
        public bool IsLooping
        {
            get { return _IsLooping; }
            set { _IsLooping = value; SetShuffleValue(); }
        }
        public bool IsEmpty
        {
            get { return (!SongPrioritizetoPlay.Any() && !SongToPlay.Any() && CurrentSong == null); }
        }
        //public static PlayerCurrentList Instance
        //{
        //    get
        //    {
        //        lock (padlock)
        //        {
        //            if (instance == null)
        //            {
        //                instance = new PlayerCurrentList();
        //            }
        //            return instance;
        //        }
        //    }
        //}

        public PlayerCurrentList()
        {
            ReInit();
            //Player.PlaybackFinished += Player_PlaybackFinished;
        }
        private void Player_PlaybackFinished(object? sender, EventArgs e)
        {
            PlaybackFinished();
        }
        private void PlaybackFinished()
        {
            this.SongFinishedPlay();
            GetNextSongToPlay();
            this.Play();
        }
        public void ReInit()
        {
            IsShuffle = false;
            SongToPlay = new Queue<Song>();
            ShuffleSongToPlay = new Queue<Song>();
            SongPrioritizetoPlay = new Stack<Song>();
            SongAlreadyPlay = new List<Song>();
            ShuffleSongAlreadyPlay = new List<Song>();
            CurrentSong = null;
        }
        public void Play()
        {
            if (CurrentSong != null)
            {
                //Thread.Sleep(60000); PlaybackFinished();
                //Player.Stop();
                //    Player.Play(CurrentSong.Path);
                //Watch.Restart();
            }
        }
        private void SetShuffleValue()
        {
            if (IsShuffle)
            {
                var listtoplay = new List<Song>();
                listtoplay.AddRange(SongAlreadyPlay);
                foreach (var item in SongToPlay)
                {
                    listtoplay.Add(item);
                }
                Random rand = new Random();
                foreach (var item in listtoplay.OrderBy(_ => rand.Next()).ToList())
                {
                    ShuffleSongToPlay.Enqueue(item);
                }
            }
            else
            {
                ShuffleSongToPlay = new Queue<Song>();
                ShuffleSongAlreadyPlay = new List<Song>();
            }
        }
        public PlayerListStatus GetPlayerListStatus()
        {
            var status = new PlayerListStatus();
            status.CurrentSong = CurrentSong;
            status.IsLooping= IsLooping;
            status.IsShuffle = IsShuffle;
            status.SongAlreadyPlay = IsShuffle ? ShuffleSongAlreadyPlay : SongAlreadyPlay;
            status.SongToPlay = new List<Song>();
            foreach (var item in SongPrioritizetoPlay)
            {
                status.SongToPlay.Add(item);
            }
            if (IsShuffle)
            {
                foreach (var item in ShuffleSongToPlay)
                {
                    status.SongToPlay.Add(item);
                }
            }
            else
            {
                foreach (var item in SongToPlay)
                {
                    status.SongToPlay.Add(item);
                }
            }
            return status;
        }
        public void AddSong(Song item)
        {
            if (IsShuffle)
            {
                ShuffleSongToPlay.Enqueue(item);
            }
                SongToPlay.Enqueue(item);
        }
        public void AddPrioritizeSong(Song item)
        {
            SongPrioritizetoPlay.Push(item);
        }
        public void Pause()
        {
            //Player.Pause();
        }
        public void Resume()
        {
            //if (Player.Paused)
            //{
            //    Player.Resume();
            //}
            //else
            //{
            //    this.Play();
            //}
        }
        public void Stop()
        {
            //Player.Stop();
        }
        public void SetVolume(byte volume)
        {
            //Player.SetVolume(volume);
        }
        public void Schuffle()
        {
            IsShuffle = !IsShuffle;
        }
        public void SongFinishedPlay()
        {
            SongAlreadyPlay.Add(CurrentSong);
            if (IsShuffle) { ShuffleSongAlreadyPlay.Add(CurrentSong); }
        }
        public void GetNextSongToPlay()
        {
            if (SongPrioritizetoPlay.Any())
            {
                CurrentSong = SongPrioritizetoPlay.Pop();
                //return CurrentSong;
            }
            else
            {
                if (!IsShuffle)
                {
                    if (SongToPlay.Any())
                        CurrentSong = SongToPlay.Dequeue();
                    else
                        CurrentSong = null;
                    //return CurrentSong;
                }
                else
                {
                    if (ShuffleSongToPlay.Any())
                        CurrentSong = ShuffleSongToPlay.Dequeue();
                    else
                        CurrentSong = null;
                    //return CurrentSong;
                }
            }
        }
        public void GetPreviousSongToPlay()
        {
            if (!IsShuffle)
            {
                if (SongAlreadyPlay.Any())
                {
                    AddPrioritizeSong(CurrentSong);
                    var previoussong = SongAlreadyPlay.Last();
                    SongAlreadyPlay.Remove(previoussong);
                    CurrentSong = previoussong;
                }
            }
            else
            {
                if (ShuffleSongAlreadyPlay.Any())
                {
                    AddPrioritizeSong(CurrentSong);
                    var previoussong = ShuffleSongAlreadyPlay.Last();
                    ShuffleSongAlreadyPlay.Remove(previoussong);
                    CurrentSong = previoussong;
                }
            }
            //return CurrentSong;

        }
    }

    public class PlayerListStatus
    {
        public List<Song> SongAlreadyPlay { get; set; }
        public List<Song> SongToPlay { get; set; }
        public Song CurrentSong { get; set; }
        public bool Playing { get; set; }
        public bool Pausing { get; set; }
        public bool IsShuffle { get; set; }
        public bool IsLooping { get; set; }
        public int Volume { get; set; }

    }
}
