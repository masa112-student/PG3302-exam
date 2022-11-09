using Domain.Enemies;
using View;

namespace Domain
{
    public struct BoardDimensions
    {
        public readonly int Width = 0;
        public readonly int Height = 0;

        public BoardDimensions(int width, int height) {
            Width = width;
            Height = height;
        }
    }


    public class GameBoard : IGameBoard
    {
        private Player _player;

        private List<Bullet> _bullets;
        private EnemySpawner _enemySpawner;
        private List<BaseEnemy> _enemies = new();

        private Point _moveDir;
        private bool _fire;

        private BoardDimensions _boardDimensions;

        public GameBoard(int boardWidth, int boardHeight) {
            _boardDimensions = new(boardWidth, boardHeight);
        }

        public int Score { get; set; }
        public bool IsGameActive { get; set; }

        public void Start() {
            _enemies = new();
            _bullets = new();
            _moveDir = new();
            _fire = false;
            _enemySpawner = new EnemySpawner(_boardDimensions);

            IsGameActive = true;
            Score = 0;

            _player = new Player();
            _player.ActiveSprite = new Sprite(" ^ \n^^^");
            _player.Pos = new Point(_boardDimensions.Width / 2, _boardDimensions.Height - 2);

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

            if (_enemies.Count == 0) {
                _enemySpawner.EnemySpawnChecker();
                _enemies = _enemySpawner.Enemies;
            }

            _enemies.ForEach(enemy => enemy.Update());


            _enemies.RemoveAll(enemy => enemy.IsDead);


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
