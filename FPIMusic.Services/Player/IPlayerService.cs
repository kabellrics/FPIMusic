using FPIMusic.Models;
using FPIMusic.Models.Player;

namespace FPIMusic.Services.Player
{
    public interface IPlayerService
    {
        void PlaySong(int itemID, int songType);
        void AddPrioritizeSong(int itemID, int songType);
        void AddSong(int itemID, int songType);
        void GetNextSongToPlay();
        PlayerListStatus GetPlayerListStatus();
        void GetPreviousSongToPlay();
        void Pause();
        void Play(Song song = null);
        void Resume();
        void SetVolume(byte volume);
        void Stop();
    }
}