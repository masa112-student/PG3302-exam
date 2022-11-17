using Domain.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace View
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
