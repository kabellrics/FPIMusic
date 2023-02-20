using FPIMusic.Models;
using FPIMusic.Models.Player;

namespace FPIMusic.Services.Player
{
    public interface IPlayerService
    {
        void PlaySong(Song item);
        void AddPrioritizeSong(Song item);
        void AddSong(Song item);
        void GetNextSongToPlay();
        PlayerListStatus GetPlayerListStatus();
        void GetPreviousSongToPlay();
        void Pause();
        void Play(Song song = null);
        void Resume();
        void SetVolume(int volume);
        void Stop(); void NextSong(); void PreviousSong();
    }
}