using Domain.Enemies;

namespace Domain.EnemyDecorators
{
    public class BaseEnemyDecorator : IEnemy
    {

        protected readonly IEnemy _enemy;

        public BaseEnemyDecorator(IEnemy moreSpeedEnemy) {
            _enemy = moreSpeedEnemy;
        }
        
        public Point Pos { get => _enemy.Pos; set => _enemy.Pos = value; }
        public Sprite ActiveSprite { get => _enemy.ActiveSprite; set => _enemy.ActiveSprite = value; }

        public int Speed() => _enemy.Speed();

        public void Move() => _enemy.Move();

        public void Update() {
            _enemy.Update();
        }
    }
}
