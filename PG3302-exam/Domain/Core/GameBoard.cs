﻿using Domain.Enemies;
using Domain.Data;
using Domain.Enemies.Factories;

namespace Domain.Core
{
    /// <summary>
    /// The heart of the game. Where all the game logic happens
    /// 
    /// Check the interface for an overview of the usage of the public methods
    /// 
    /// Brefly about the struture of types in this class:
    ///     The player, enemies and bullets are all considered to be entities (having a position and size).
    ///     Movement and collision logic is the same for all entities so it can be made generic for all entities (the IMovable and IHittable interfaces).
    ///     On top of that, certain aspects could be modified by decorators (Movementspeed, Health). This makes it so that these aspects have to be updated from outside the classes themselves.
    ///     This is where the EntityMover and EnemyDamage classes come into play. The EntityMover works on all IMovable objects which means you could pass a basic enemy to it, 
    ///     or an enemy wrapped in one (or mutiple) speedy decorators and they would behave as expected.
    ///     
    ///     The same is true for the EnemyDamage class. Where a basic enemy, and a really tough enemy wrapped in multiple healthboost decorators, will both take the required amout of hits before the die.
    /// 
    /// </summary>
    public class GameBoard : IGameBoard
    {
        private readonly Dimension _boardDimensions;

        private readonly EntityMover _entityMover;
        private readonly EntityDamager _enemyDamage;
        private readonly EnemySpawner _enemySpawner;

		private Player _player;

        private readonly List<Bullet> _bullets;
		
	    private bool _fire;
        
        public GameBoard(Dimension boardDimensions) {
            _boardDimensions = boardDimensions;

            _entityMover = new(boardDimensions);
            _enemyDamage = new();
            _enemySpawner = new();

            _bullets = new();
        }

        public GameBoard(int boardWidth, int boardHeight) 
            : this (new Dimension(boardWidth, boardHeight)) { }

        public int Score { get; set; }
        public bool IsGameActive { get; set; }

        public void Start() {
            _bullets.Clear();
            _enemySpawner.Enemies.Clear();
            _fire = false;

            _player = new Player();
            _player.ActiveSprite = SpriteConfig.PlayerSprite;
            _player.Pos = new Point(_boardDimensions.Width / 2, _boardDimensions.Height - _player.Size.Height - 1);

            IsGameActive = true;
            Score = 0;
        }

        public List<Sprite> GetSprites() {
            List<Sprite> sprites = new() {
                _player.ActiveSprite
            };
            _enemySpawner.Enemies.ForEach(enemy => sprites.Add(enemy.ActiveSprite));
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
            _enemySpawner.Enemies.RemoveAll(enemy => enemy.IsDead);
            _bullets.RemoveAll(bullet =>
                bullet.IsDestroyed ||
                !_boardDimensions.IsPointInside(bullet.Pos)
            );

            // Player updates
            _entityMover.Move(_player, clamp: true);
            if (_fire && _player.CanAttack)
                _bullets.Add(_player.Attack());

            // Enemies updates
            if (_enemySpawner.Enemies.Count == 0) {
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
            }

            _enemySpawner.Enemies.ForEach(enemy => {
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

                // Bullet hit detection
                _enemySpawner.Enemies.ForEach(enemy => {
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
            if (_enemySpawner.Enemies.Any(enemy => (enemy.Pos.Y + enemy.Size.Height) > _boardDimensions.Height - _player.Size.Height )) {
                IsGameActive = false;
            }

            // Reset input vars
            _player.MoveDir = new Point();
            _fire = false;
        }
    }
}
