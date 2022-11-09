using System;
using Domain.Enemies;
using View;


namespace Domain.EnemyDecorators
{
    public class MoreSpeedEnemyDecorator : BaseEnemyDecorator
    {
        public MoreSpeedEnemyDecorator(IEnemy moreSpeedEnemy) : base(moreSpeedEnemy)
        {
        }

        public int Speed() => _enemy.Speed() - 50;
    }
}

