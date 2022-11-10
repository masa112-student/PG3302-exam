using Domain.Enemies;

namespace Domain.EnemyDecorators
{
    public class BaseEnemyDecorator : Enemy
    {

        protected readonly Enemy _enemy;

        public BaseEnemyDecorator(Enemy enemy) {
            _enemy = enemy;
        }
        
        public override Point Pos { get => _enemy.Pos; set => _enemy.Pos = value; }
        public override Sprite ActiveSprite { get => _enemy.ActiveSprite; set => _enemy.ActiveSprite = value; }
        public override bool IsDead { get => _enemy.IsDead; set => _enemy.IsDead = value; }

        public override int Speed() => _enemy.Speed();

        public override void Move(Point direction) => _enemy.Move(direction);

        public override void Update() {
            _enemy.Update();
        }

        public override Bullet Attack() {
            return _enemy.Attack();
        }

        public override Point GetPos() {
            return _enemy.GetPos();
        }

        public override Dimension GetDimension() {
            return _enemy.GetDimension();
        }

        public override bool Hit(IHittable hittable) {
            return _enemy.Hit(hittable);
        }
    }
}
