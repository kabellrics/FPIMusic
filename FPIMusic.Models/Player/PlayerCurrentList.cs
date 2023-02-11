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
        private Stack<Song> SongPrioritizetoPlay;
        private List<Song> SongAlreadyPlay;
        private Song CurrentSong;
        public PlayerCurrentList()
        {
            ReInit();
        }

        public void ReInit()
        {
            SongToPlay = new Queue<Song>();
            SongPrioritizetoPlay = new Stack<Song>();
            SongAlreadyPlay = new List<Song>();
            CurrentSong = null;
        }
        public PlayerListStatus GetPlayerListStatus()
        {
            var status = new PlayerListStatus();
            status.CurrentSong = CurrentSong;
            status.SongAlreadyPlay = SongAlreadyPlay;
            status.SongToPlay = new List<Song>();
            foreach(var item in SongPrioritizetoPlay)
            {
                status.SongToPlay.Add(item);
            }
            foreach(var item in SongToPlay)
            {
                status.SongToPlay.Add(item);
            }
            return status;
        }
        public void AddSong(Song item)
        {
            SongToPlay.Enqueue(item);
        }
        public void AddPrioritizeSong(Song item)
        {
            SongPrioritizetoPlay.Push(item);
        }
        public void SongFinishePlay()
        {
            SongAlreadyPlay.Add(CurrentSong);
        }
        public Song GetNextSongToPlay()
        {
            if(SongPrioritizetoPlay.Any())
            {
                CurrentSong = SongPrioritizetoPlay.Pop();
                return CurrentSong;
            }
            CurrentSong = SongToPlay.Dequeue();
            return CurrentSong;
            //return CurrentSong;

        }
    }

    public class PlayerListStatus
    {
        public List<Song> SongAlreadyPlay { get; set; }
        public List<Song> SongToPlay { get; set; }
        public Song CurrentSong { get; set; }

    }
}
