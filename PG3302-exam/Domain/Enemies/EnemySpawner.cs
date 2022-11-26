using System.Diagnostics;

using Domain.Core;
using Domain.Data;
using Domain.Enemies.Factories;

namespace Domain.Enemies
{
    public class EnemySpawner
    {
        private readonly Random _random;

        private readonly Point _enemyStartPos;
        private readonly List<EnemyType> _enemyTypes;
        private readonly List<Enemy> _enemies;

        private readonly Dimension _boardDimension;

        private const int MAX_ENEMIES = 30;
        private int _minEnemies;
        private int _maxEnemies;

        public EnemySpawner(Dimension boardDimension) {
            _boardDimension = boardDimension;
            _random = new();
            _enemyStartPos = new(0, 4);
            _enemyTypes =  new() { EnemyType.Basic };
            _enemies = new();

            _minEnemies = 1;
            _maxEnemies = 3;
        }


        public void AddTypeToSpawnPool(EnemyType type)
        {
            _maxEnemies = Math.Min(_maxEnemies + 1, MAX_ENEMIES);
            _minEnemies = Math.Min(_minEnemies + 1, _maxEnemies - 1);

            if (!_enemyTypes.Contains(type)) {
                _enemyTypes.Add(type);
            }
        }

        public void EnemySpawnChecker()
        {
            _enemies.Clear();

            int enemyCount = _random.Next(_minEnemies, _maxEnemies);

            Point enemySpawnPoint = _enemyStartPos;
            EnemyType typeToSpawn;
            int typeToSpawnIndex;
            int highestSpriteThisRow = 0;

            for (int i = 0; i < enemyCount; i++) {
                typeToSpawnIndex = _random.Next(_enemyTypes.Count);
                typeToSpawn = _enemyTypes[typeToSpawnIndex];

                // Create a new enemy from the factory.
                Enemy enemy = EnemyFactoryMaker.MakeFactory(typeToSpawn).getEnemy();

                if ((enemySpawnPoint.X + enemy.Size.Width) > _boardDimension.Width) {
                    enemySpawnPoint.X = 0;
                    enemySpawnPoint.Y += highestSpriteThisRow;
                    highestSpriteThisRow = 0;
                }

                // The position of each enemy is derived from the width of the sprite and also the speed at which they move. (Faster sprites needs a bigger gap, otherwise they will overlap)
                enemy.Pos = enemySpawnPoint;
                enemySpawnPoint.X += enemy.Size.Width + enemy.Speed;

                highestSpriteThisRow = Math.Max(highestSpriteThisRow, enemy.Size.Height);
                _enemies.Add(enemy);
            }

            //DebugSpawnEnemyTypes();
        }

        public void Update(int currentScore) {
            if (Enemies.Count == 0) {
                if (currentScore > 0) {
                    AddTypeToSpawnPool(EnemyType.Fast);
                }
                if (currentScore > 500) {
                    AddTypeToSpawnPool(EnemyType.FastAttack);
                }
                if (currentScore > 1000) {
                    AddTypeToSpawnPool(EnemyType.Strong);
                }
                if (currentScore > 10000) {
                    AddTypeToSpawnPool(EnemyType.Boss);
                }

                EnemySpawnChecker();
            }

        }

        public List<Enemy> Enemies 
        {
            get { return _enemies; }
        }


        [Conditional("DEBUG")]
        private void DebugSpawnEnemyTypes() {
            int y = 4;
            int fastY = 4; // In case the fast one is too fast to spawn as far down as the others during testing
            Enemy enemy;

            enemy = EnemyFactoryMaker.MakeFactory(EnemyType.Basic).getEnemy();
            enemy.Pos = _enemyStartPos + new Point(0 * (enemy.ActiveSprite.Size.Width + enemy.Speed), y);
            _enemies.Add(enemy);

            enemy = EnemyFactoryMaker.MakeFactory(EnemyType.Strong).getEnemy();
            enemy.Pos = _enemyStartPos + new Point(1 * (enemy.ActiveSprite.Size.Width + enemy.Speed), y);
            _enemies.Add(enemy);

            enemy = EnemyFactoryMaker.MakeFactory(EnemyType.FastAttack).getEnemy();
            enemy.Pos = _enemyStartPos + new Point(2 * (enemy.ActiveSprite.Size.Width + enemy.Speed), y);
            _enemies.Add(enemy);

            enemy = EnemyFactoryMaker.MakeFactory(EnemyType.Fast).getEnemy();
            enemy.Pos = _enemyStartPos + new Point(3 * (enemy.ActiveSprite.Size.Width + enemy.Speed), fastY);
            _enemies.Add(enemy);

            enemy = EnemyFactoryMaker.MakeFactory(EnemyType.Boss).getEnemy();
            enemy.Pos = _enemyStartPos + new Point(0 * (enemy.ActiveSprite.Size.Width + enemy.Speed), 0);
            _enemies.Add(enemy);
        }

    }
}

