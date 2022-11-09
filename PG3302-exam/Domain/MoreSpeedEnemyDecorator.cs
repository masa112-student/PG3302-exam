using System;
using View;


namespace Domain
{
    public class MoreSpeedEnemyDecorator : IEnemy
    {
        readonly EnemyMovement? _enemyMovement;
        private readonly IEnemy _moreSpeedEnemy;

        public MoreSpeedEnemyDecorator(IEnemy moreSpeedEnemy)
        {
            _moreSpeedEnemy = moreSpeedEnemy;
        }


        public int XPos { get => _moreSpeedEnemy.XPos; }

        public int YPos { get => _moreSpeedEnemy.YPos; }

        public int Speed() => _moreSpeedEnemy.Speed() - 50;

        public void Draw() => _moreSpeedEnemy.Draw();

        public EnemyMovement Move() => _moreSpeedEnemy.Move();
    }
}

