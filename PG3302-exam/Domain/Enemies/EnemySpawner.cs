using System.Collections.Immutable;
using Domain.Core;
using Domain.Data;

namespace Domain.Enemies
{
    public class EnemySpawner
    {

        private List<Enemy> _enemies = new();

        private static Random random = new Random();

        private Point enemyStartPos = new Point(0, 4);
        private Sprite enemySprite = new Sprite("xxx\n\\x/");

        private List<EnemyType> _enemyTypes = new() { EnemyType.Basic };

        private EnemyFactoryMaker _enemyFactoryMaker;

        public EnemySpawner()
        {
            _enemyFactoryMaker = new();
        }

        public void AddTypeToSpawnPool(EnemyType type)
        {
            //if (!_enemyTypes.Contains(type)) {
            _enemyTypes.Add(type);
            //}
        }

        public void EnemySpawnChecker()
        {
            _enemies = new();
            int enemyCount = random.Next(1, 10);

            EnemyType typeToSpawn;
            int typeToSpawnIndex;
            for (int i = 0; i < enemyCount; i++)
            {
                typeToSpawnIndex = random.Next(_enemyTypes.Count);
                typeToSpawn = _enemyTypes[typeToSpawnIndex];

                // Create a new enemy from the factory. The position of each enemy is derived from the width of the sprite and also the speed at which they move.
                // (Faster sprites needs a bigger gap, otherwise they will overlap)
                Enemy enemy = _enemyFactoryMaker.MakeFactory(typeToSpawn).getEnemy();
                enemy.Pos = enemyStartPos + new Point(i * (enemySprite.Size.Width + enemy.Speed), 0);
                enemy.ActiveSprite = new Sprite(enemySprite);
                _enemies.Add(enemy);
            }
        }
        public List<Enemy> Enemies
        {
            get { return _enemies; }
        }

    }
}

