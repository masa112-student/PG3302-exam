using Domain.Enemies;


namespace Domain.EnemyDecorators
{
    public class MoreSpeedEnemyDecorator : BaseEnemyDecorator
    {
        public MoreSpeedEnemyDecorator(Enemy moreSpeedEnemy) : base(moreSpeedEnemy) { }

        public override Sprite ActiveSprite { 
            get => base.ActiveSprite;
            set { 
                base.ActiveSprite = value;
                Array.Fill(base.ActiveSprite.ColorData, Sprite.Color.Yellow);
            } 
        }

        public override int Speed() => _enemy.Speed() + 1;

        public override void Move(Point direction) {
            Pos += direction * Speed();
        }
    }
}

