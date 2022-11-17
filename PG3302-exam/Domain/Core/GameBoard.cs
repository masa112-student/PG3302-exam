﻿using Domain.Enemies;
using Domain.Data;

namespace Domain.Core
{
    public class GameBoard : IGameBoard
    {
        private readonly Dimension _boardDimensions;
        private readonly EntityMover _entityMover;
        private readonly EnemyDamage _enemyDamage;
        private readonly EnemySpawner _enemySpawner;

		private Player _player;

        private readonly List<Bullet> _bullets;
        private List<Enemy> _enemies;
		
	private bool _fire;
        
        public GameBoard(Dimension boardDimensions) {
            _boardDimensions = boardDimensions;

            _entityMover = new(boardDimensions);
            _enemyDamage = new();
            _enemySpawner = new();

            _enemies = new();
            _bullets = new();
        }

        public GameBoard(int boardWidth, int boardHeight) 
            : this (new Dimension(boardWidth, boardHeight)) { }

        public int Score { get; set; }
        public bool IsGameActive { get; set; }

        public void Start() {
            _enemies.Clear();
            _bullets.Clear();
            _fire = false;

            _player = new Player();
            _player.ActiveSprite = SpriteConfig.PlayerSprite;
            _player.Pos = new Point(_boardDimensions.Width / 2, _boardDimensions.Height - _player.Size.Height - 1);

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
            // Cleanup dead entities
            _enemies.RemoveAll(enemy => enemy.IsDead);
            _bullets.RemoveAll(bullet =>
                bullet.IsDestroyed ||
                !_boardDimensions.IsPointInside(bullet.Pos)
            );

            // Player updates
            _entityMover.Move(_player, clamp: true);
            if (_fire && _player.CanAttack)
                _bullets.Add(_player.Attack());

            // Enemies updates
            if (_enemies.Count == 0) {
                if(Score > 0) {
                    _enemySpawner.AddTypeToSpawnPool(EnemyType.Fast);
                }
                if (Score > 500) {
                    _enemySpawner.AddTypeToSpawnPool(EnemyType.FastAttack);
                }
                if (Score > 1000)
                {
                    _enemySpawner.AddTypeToSpawnPool(EnemyType.Strong);
                }
                
                _enemySpawner.EnemySpawnChecker();
                _enemies = _enemySpawner.Enemies;
            }

            _enemies.ForEach(enemy => {
                EnemyMovement.UpdateMoveDir(enemy, _boardDimensions);
                _entityMover.Move(enemy, clamp: true);

                if(enemy.CanAttack && enemy.ShouldAttack) {
                    _bullets.Add(enemy.Attack());
                }
            });

            // Bullet updates
            _bullets.ForEach(bullet => {
                if (bullet.IsDestroyed) 
                    return;
                    
                _entityMover.Move(bullet);

                _enemies.ForEach(enemy => {
                    if (bullet.Hit(enemy)) {
                        if (!enemy.IsDead) {
                            _enemyDamage.Damage(enemy);
                            bullet.Destroy();

                            Score += enemy.Value;
                        }
                    } else if (bullet.Hit(_player)) {
                        IsGameActive = false;
                    }
                });
            });
                        
            // Gamestate update
            if (_enemies.Any(enemy => (enemy.Pos.Y + enemy.Size.Height) > _boardDimensions.Height - _player.Size.Height )) {
                IsGameActive = false;
            }

            // Reset input vars
            _player.MoveDir = new Point();
            _fire = false;
        }
    }
}
