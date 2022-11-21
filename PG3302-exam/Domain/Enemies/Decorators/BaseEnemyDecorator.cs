using Domain.Data;
using Domain.Core;

namespace Domain.Enemies.Decorators
{
    /// <summary>
    /// This class just servers as a base for decorators to inherit from. All that it does is accepting an enemy to wrap and forwad it's methods/values
    /// </summary>
    public class BaseEnemyDecorator : Enemy
    {

        protected readonly Enemy _enemy;

        public BaseEnemyDecorator(Enemy enemy)
        {
            _enemy = enemy;
        }

        public override Point Pos { get => _enemy.Pos; set => _enemy.Pos = value; }
        public override Sprite ActiveSprite { get => _enemy.ActiveSprite; set => _enemy.ActiveSprite = value; }
        public override bool IsDestroyed { get => _enemy.IsDestroyed; }
        public override int Speed { get => _enemy.Speed; set => _enemy.Speed = value; }
        public override int Value { get => _enemy.Value; }
        public override Point MoveDir { get => _enemy.MoveDir; set => _enemy.MoveDir = value; }
        public override int Health { get => _enemy.Health; set => _enemy.Health = value; }

        public override Dimension Size => _enemy.Size;

        public override bool CanAttack => _enemy.CanAttack;

        public override bool ShouldAttack => _enemy.ShouldAttack;

        public override IHittable.HitMask Mask { get => _enemy.Mask; set => _enemy.Mask = value; }


        public override Bullet Attack()
        {
            return _enemy.Attack();
        }

        public override bool Hit(IHittable other)
        {
            return _enemy.Hit(other);
        }

        public override void Destroy()
        {
            _enemy.Destroy();
        }
    }
}
