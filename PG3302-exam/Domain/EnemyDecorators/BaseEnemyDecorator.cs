using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enemies;

namespace Domain.EnemyDecorators
{
    public class BaseEnemyDecorator : IEnemy
    {
        protected readonly IEnemy _enemy;

        public BaseEnemyDecorator(IEnemy moreSpeedEnemy)
        {
            _enemy = moreSpeedEnemy;
        }

        public Point Pos { get => _enemy.Pos; set => _enemy.Pos = value; }
        public Sprite ActiveSprite { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Speed() => _enemy.Speed() - 50;

        public EnemyMovement Move() => _enemy.Move();
    }
}
