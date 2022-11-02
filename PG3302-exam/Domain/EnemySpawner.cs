using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using View;

namespace Domain
{
	public class EnemySpawner
	{
		
		public List<Enemy> enemies = new();
	

		public void UpdateCount()
		{
			if (enemies.Count == 0)
			{
				for (int i = 0; i < 10; i++)
					enemies.Add(new Enemy(Console.BufferWidth - enemies.Count * 4)
					{
					});
			}
		}

		public void SpawnEnemies()
		{		
				foreach (Enemy enemy in enemies)
				{
				enemy.Draw();
				}
			}
	}
	
	
}

