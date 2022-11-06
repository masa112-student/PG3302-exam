using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<BaseEnemy> _enemies = new ();
        private List<Bullet> _bullets = new();


        private Point _moveDir = new();
        private bool _fire = false;

        private int _boardWidth;
        private int _boardHeight;

        public GameBoard(int boardWidth, int boardHeight) {
            _boardWidth = boardWidth;
            _boardHeight = boardHeight;
            _player = new Player(_boardWidth);
            _player.ActiveSprite = new Sprite("  ^  \n ^^^ ");
            _player.Pos = new Point(boardWidth / 2, boardHeight - 2);
            _enemies.Add(new BaseEnemy());
            _enemies.First().ActiveSprite = new Sprite(" xxx \n  x  ");
            _enemies.First().pos = new Point(boardWidth/2, boardHeight/2);
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
                case IGameBoard.MoveDir.LEFT:
                    _moveDir = new Point(-1, 0);
                    break;
                case IGameBoard.MoveDir.RIGHT:
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



            // Reset input vars
            _moveDir = new Point();
            _fire = false;
        }
    }
}
