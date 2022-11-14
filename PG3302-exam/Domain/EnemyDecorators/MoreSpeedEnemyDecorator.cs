using Domain.Core;
using Domain.Enemies;


namespace Domain.EnemyDecorators
{
    public class MoreSpeedEnemyDecorator : BaseEnemyDecorator {
        public MoreSpeedEnemyDecorator(Enemy moreSpeedEnemy) : base(moreSpeedEnemy) { }

        public override int Speed {get => base.Speed + 1;}
        public override Sprite ActiveSprite { 
            get => base.ActiveSprite;
            set { 
                base.ActiveSprite = value;
                Array.Fill(base.ActiveSprite.ColorData, ConsoleColor.Yellow);
            } 
        }
    }
}

