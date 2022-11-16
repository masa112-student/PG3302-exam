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

		public WindowsMusicManager PlayMenuMuisc()
		{		
			MusicPlayer menuMusic = new MusicPlayer(new SoundPlayer(@"Music\menuMusic.wav"));			
			return this;			
		}

		WindowsMusicManager IMusic.PlayGameLoopMusic()
		{
			MusicPlayer gameLoopMusic = new MusicPlayer(new SoundPlayer(@"Music\gameloopMusic.wav"));
			return this;
		}

		WindowsMusicManager IMusic.PlayGameOverSound()
		{
			MusicPlayer gameOverSound = new MusicPlayer(new SoundPlayer(@"Music\gameOver.wav"));			
			return this;			
		}
	}	
	
}
