using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Music
{
	public class MusicPlayer
	{
		private SoundPlayer? _soundPlayer;
		
		public MusicPlayer(SoundPlayer _soundPlayer)
		{
			this._soundPlayer = _soundPlayer;
			_soundPlayer.Load();
			_soundPlayer.Play();
		}		
	}		
}
