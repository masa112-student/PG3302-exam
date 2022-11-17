using System.Media;

namespace Domain.Music
{
	public class MusicPlayer
	{
		private SoundPlayer _soundPlayer;
		
		public MusicPlayer(SoundPlayer soundPlayer) {
			_soundPlayer = soundPlayer;
			_soundPlayer.Load();
			_soundPlayer.Play();
		}		
	}		
}
