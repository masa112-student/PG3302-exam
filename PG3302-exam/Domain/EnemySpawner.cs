using Domain.Enemies;

namespace Domain
{
	public class EnemySpawner
	{

		public EnemySpawner(BoardDimensions boardDimensions) {
			_boardDimensions = boardDimensions;
		}

		private BoardDimensions _boardDimensions;

		private List<BaseEnemy> _enemies = new();

		private static Random random = new Random();


		Point enemyStartPos = new Point(0, 4);
		Sprite enemySprite = new Sprite("1------2------3\n      \\4/      ");


		public void EnemySpawnChecker() {
			_enemies = new();
			int randomInt = random.Next(1, 4);

			for (int i = 0; i < randomInt; i++) {
				BaseEnemy enemy = new BaseEnemy(_boardDimensions);
				enemy.Pos = enemyStartPos + new Point(i * (enemySprite.Size.Width + 1), 0);
				enemy.ActiveSprite = new Sprite(enemySprite);
				_enemies.Add(enemy);
			}
		}
		public List<BaseEnemy> Enemies {
			get { return _enemies; }
		}

	}
}

