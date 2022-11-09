using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using View;

namespace Domain
{
    public class GameBoard : IGameBoard
    {
        public int Score { get; set; }
        public bool IsGameActive { get; set; }

        private Player _player;
        private List<BaseEnemy> _enemies;
        private List<Bullet> _bullets;


        private Point _moveDir;
        private bool _fire;

        private int _boardWidth;
        private int _boardHeight;

        public GameBoard(int boardWidth, int boardHeight) {
            _boardWidth = boardWidth;
            _boardHeight = boardHeight;

        }
        public void Start() {
            _enemies = new();
            _bullets = new();
            _moveDir = new();
            _fire = false;

            IsGameActive = true;
            Score = 0;

            _player = new Player(_boardWidth);
            _player.ActiveSprite = new Sprite(" ^ \n^^^");
            _player.Pos = new Point(_boardWidth / 2, _boardHeight - 2);

            Point enemyStartPos = new Point(0, 8);
            Sprite enemySprite = new Sprite("xxx\n x ");

            for (int i = 0; i < 10; i++) {
                BaseEnemy enemy = new BaseEnemy();
                enemy.Pos = enemyStartPos + new Point(i * 4, 0);

                enemy.ActiveSprite = new Sprite(enemySprite);
                _enemies.Add(enemy);
            }

            _enemies.ForEach(enemy => Trace.WriteLine(enemy.Pos.X));
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
                    _moveDir = new Point(-1, 0);
                    break;
                case IGameBoard.MoveDir.Right:
                    _moveDir = new Point(1, 0);
                    break;
            }
        }

        public void PlayerAttack() {
            _fire = true;
        }

        public void Update() {
            _player.Pos += _moveDir;
            if (_fire && _player.CanAttack)
                _bullets.Add(_player.Attack());

            // TODO: BULLET POOL
            _bullets.ForEach(bullet => {
                bullet.Update();
                _enemies.ForEach(enemy => {
                    if (bullet.Hit(enemy)) {
                        if (!enemy.IsDead) {
                            enemy.IsDead = true;
                            Score += 100;
                        }
                    }
                });
            });
            _bullets.RemoveAll(bullet => bullet.Pos.Y < -1);
            //_enemies.RemoveAll(enemy => enemy.isDead);
            // Reset input vars
            _moveDir = new Point();
            _fire = false;
        }
    }
}
