using System.Media;

namespace Domain.Music
{
	public class MusicPlayer
	{
		public SoundPlayer SoundPlayer { get; private set; }
		
		public MusicPlayer(SoundPlayer soundPlayer) {
			SoundPlayer = soundPlayer;
			SoundPlayer.Load();
			SoundPlayer.Play();
		}		
	}		
}
