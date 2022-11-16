using Domain.Data;
using Domain.Enemies;
using Domain.Core;

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
        public override bool IsDead { get => _enemy.IsDead;  }
        public override int Speed { get => _enemy.Speed; set => _enemy.Speed = value; }
        public override Point MoveDir { get => _enemy.MoveDir; set => _enemy.MoveDir = value; }

        public override Dimension Size => _enemy.Size;

        public override bool CanAttack => _enemy.CanAttack;

        public override bool ShouldAttack => _enemy.ShouldAttack;

        public override IHittable.HitMask Mask { get => _enemy.Mask; set => _enemy.Mask = value; }

        public override Bullet Attack() {
            return _enemy.Attack();
        }

        public override bool Hit(IHittable other) {
            return _enemy.Hit(other);
        }

        public override void Damage() {
            _enemy.Damage();
        }
    }
}
