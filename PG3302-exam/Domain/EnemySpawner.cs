using Domain.Enemies;
using System.Collections.Immutable;

namespace Domain
{
	public class EnemySpawner
	{

		private List<Enemy> _enemies = new();

		private static Random random = new Random();

		private Point enemyStartPos = new Point(0, 4);
        private Sprite enemySprite = new Sprite("xxx\n\\x/");

		private List<EnemyType> _enemyTypes = new () { EnemyType.Basic };

        private BoardDimensions _boardDimensions;
		private EnemyFactoryMaker _enemyFactoryMaker;

        public EnemySpawner(BoardDimensions boardDimensions) {
            _boardDimensions = boardDimensions;
			_enemyFactoryMaker = new(boardDimensions);
        }

		public void AddTypeToSpawnPool(EnemyType type) {
			//if (!_enemyTypes.Contains(type)) {
				_enemyTypes.Add(type);
			//}
		}

        public void EnemySpawnChecker() {
			_enemies = new();
			int enemyCount = random.Next(1, 4);

			EnemyType typeToSpawn;
			int typeToSpawnIndex;
			for (int i = 0; i < enemyCount; i++) {
				typeToSpawnIndex = random.Next(_enemyTypes.Count);
				typeToSpawn = _enemyTypes[typeToSpawnIndex];

                Enemy enemy = _enemyFactoryMaker.MakeFactory(typeToSpawn).getEnemy();
				enemy.Pos = enemyStartPos + new Point(i * (enemySprite.Size.Width + 1), 0);
				enemy.ActiveSprite = new Sprite(enemySprite);
				_enemies.Add(enemy);
			}
		}
		public List<Enemy> Enemies {
			get { return _enemies; }
		}

	}
}

