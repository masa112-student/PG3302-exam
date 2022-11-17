using System.Media;

namespace Domain.Music
{
	public class WindowsMusicManager : IMusic{		

		public void PlayMenuMuisc()
		{		
			MusicPlayer menuMusic = new MusicPlayer(new SoundPlayer(@"Music\menuMusic.wav"));			
		}

		public void PlayGameLoopMusic()
		{
			MusicPlayer gameLoopMusic = new MusicPlayer(new SoundPlayer(@"Music\gameloopMusic.wav"));
		}

		public void PlayGameOverSound()
		{
			MusicPlayer gameOverSound = new MusicPlayer(new SoundPlayer(@"Music\gameOver.wav"));			
		}
	}	
	
}
