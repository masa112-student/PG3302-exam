using System;
using View;


namespace Domain
{
    public class MoreSpeedEnemyDecorator : BaseEnemyDecorator
    {
        public MoreSpeedEnemyDecorator(IEnemy moreSpeedEnemy) : base(moreSpeedEnemy) {
        }

        public int Speed() => _enemy.Speed() - 50;
    }
}

