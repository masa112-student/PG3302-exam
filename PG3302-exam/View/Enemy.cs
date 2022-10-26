using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace View
{
    internal class Enemy
    {
		private readonly int _maxWidth;

		private int _xPos;

		private System.Timers.Timer enemyTimer;

		public int SpirteHeight { get; set; }
		public int SpirteWidth { get; set; }

		public int XPos
		{
			get => _xPos;
			set
			{
				if (value <= 0)
					_xPos = 0;
				else if (value >= _maxWidth - SpirteWidth)
					_xPos = _maxWidth - SpirteWidth;
				else
					_xPos = value;
			}
		}

		public Enemy(int maxWidth)
		{

			enemyTimer = new System.Timers.Timer();
			enemyTimer.Elapsed += EnemyTimer_Elapsed;
			enemyTimer.Interval = 500;
			enemyTimer.Start();

			_maxWidth = maxWidth;

			XPos = _maxWidth / 2;

			SpirteHeight = 2;
			SpirteWidth = 2;

		}

		private void EnemyTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
		{			
			XPos += 1;
		}

		public void Draw()
		{
			Console.SetCursorPosition(XPos, 2);
			Console.Write("X");
			Console.Write("X");
			Console.SetCursorPosition(XPos, 1);

			Console.Write("X");
			Console.Write("X");
		}
	}
}
