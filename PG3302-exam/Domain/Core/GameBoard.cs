using Domain.Enemies;
using Domain.Data;
using System.Reflection.Metadata.Ecma335;
using View;
using System.Diagnostics;

namespace Domain.Core
{

    public class GameBoard : IGameBoard
    {
        private readonly Dimension _boardDimensions;
        private readonly EntityMover _entityMover;

        private Player _player;

        private List<Bullet> _bullets;
        private EnemySpawner _enemySpawner;
        private List<Enemy> _enemies = new();

        private bool _fire;
        
        public GameBoard(Dimension boardDimensions) {
            _boardDimensions = boardDimensions;
            _entityMover = new EntityMover(boardDimensions);
        }

        public GameBoard(int boardWidth, int boardHeight) 
            : this (new Dimension(boardWidth, boardHeight)) { }

        public int Score { get; set; }
        public bool IsGameActive { get; set; }

        public void Start() {
            _enemies = new();
            _bullets = new();
            _fire = false;
            _enemySpawner = new EnemySpawner();

            _player = new Player();
            _player.ActiveSprite = new Sprite(" ^ \n^^^");
            _player.Pos = new Point(_boardDimensions.Width / 2, _boardDimensions.Height - 2);

            IsGameActive = true;
            Score = 0;
        }

        public List<Sprite> GetSprites() {
            var sprites = new List<Sprite>();
            sprites.Add(_player.ActiveSprite);
            _enemies.ForEach(enemy => sprites.Add(enemy.ActiveSprite));
            _bullets.ForEach(bullet => sprites.Add(bullet.ActiveSprite));
            return sprites;
        }

        public void MovePlayer(IGameBoard.MoveDir dir) {
            switch (dir) {
                case IGameBoard.MoveDir.Left:
                    _player.MoveDir = new Point(-1, 0);
                    break;
                case IGameBoard.MoveDir.Right:
                    _player.MoveDir = new Point(1, 0);
                    break;
            }
        }

        public void PlayerAttack() {
            _fire = true;
        }

        public void Update() {
            _entityMover.Move(_player, clamp: true);

            if (_fire && _player.CanAttack)
                _bullets.Add(_player.Attack());

            if (_enemies.Count == 0) {
                if(Score > 0) {
                    _enemySpawner.AddTypeToSpawnPool(EnemyType.Fast);
                }

                _enemySpawner.EnemySpawnChecker();
                _enemies = _enemySpawner.Enemies;
            }

            _enemies.ForEach(enemy => {
                EnemyMovement.Update(enemy, _boardDimensions);
                _entityMover.Move(enemy, clamp: true);
            });
            _enemies.RemoveAll(enemy => enemy.IsDead);


            _bullets.RemoveAll(bullet => 
                bullet.IsDestroyed || 
                !_boardDimensions.IsPointInside(bullet.Pos)
            );

            // TODO: BULLET POOL
            _bullets.ForEach(bullet => {
                if (bullet.IsDestroyed) 
                    return;
                    
                _entityMover.Move(bullet);

                _enemies.ForEach(enemy => {
                    if (bullet.Hit(enemy)) {
                        if (!enemy.IsDead) {
                            enemy.Damage();
                            bullet.Destroy();

                            Score += 100;
                        }
                    }
                });
            });

            if(_enemies.Any(enemy => (enemy.Pos.Y + enemy.Size.Height) > _boardDimensions.Height - _player.Size.Height )) {
                IsGameActive = false;
            }

            // Reset input vars
            _player.MoveDir = new Point();
            _fire = false;
        }
    }
}
