using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FPIMusic.Models.Player
{
    public class PlayerCurrentList
    {
        private Queue<Song> SongToPlay;
        private Queue<Song> ShuffleSongToPlay;
        private Stack<Song> SongPrioritizetoPlay;
        private List<Song> SongAlreadyPlay;
        private List<Song> ShuffleSongAlreadyPlay;
        public Song CurrentSong { get; set; }
        private bool _IsShuffle;
        public bool IsShuffle
        {
            get { return _IsShuffle; }
            set { _IsShuffle = value; SetShuffleValue(); }
        }
        public bool IsEmpty
        {
            get { return (!SongPrioritizetoPlay.Any() && !SongToPlay.Any()); }
        }


        public PlayerCurrentList()
        {
            ReInit();
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
                    CurrentSong = SongToPlay.Dequeue();
                    //return CurrentSong;
                }
                else
                {
                    CurrentSong = ShuffleSongToPlay.Dequeue();
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

    }
}
