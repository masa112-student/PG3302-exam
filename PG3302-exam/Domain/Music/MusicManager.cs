using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;

namespace Domain.Music
{
	public class MusicManager : IMusic
	{
		public WindowsMusicManager? PlayGameLoopMusic() => null;

		public WindowsMusicManager? PlayGameOverSound() => null;

		public WindowsMusicManager? PlayMenuMuisc() => null;
	}
}
