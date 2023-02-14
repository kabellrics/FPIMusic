using FPIMusic.Models;
using FPIMusic.Models.Player;

namespace FPIMusic.Services.Player
{
    public interface IPlayerService
    {
        void AddPrioritizeSong(int itemID, SongType SongType);
        void AddSong(int itemID, SongType SongType);
        Song GetNextSongToPlay();
        PlayerListStatus GetPlayerListStatus();
        Song GetPreviousSongToPlay();
        void Pause();
        void Play(Song song);
        void Resume();
        void SetVolume(byte volume);
        void Stop();
    }
}