using System.Diagnostics;
using System.Media;

namespace Domain.Music
{
	public class WindowsMusicManager : IMusicManager {

		private MusicPlayer? _activePlayer;

		public void PlayMenuMuisc()
		{
            PlayIfNotRunning(@"Music\menuMusic.wav");
        }

		public void PlayGameLoopMusic()
		{
            PlayIfNotRunning(@"Music\gameloopMusic.wav");
		}

		public void PlayGameOverSound()
		{
			PlayIfNotRunning(@"Music\gameOver.wav");
        }

		private void PlayIfNotRunning(string soundLoc) {
            if (_activePlayer == null || _activePlayer.SoundPlayer.SoundLocation != soundLoc)
                _activePlayer = new MusicPlayer(new SoundPlayer(soundLoc));
        }

	}	
	
}
