using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;


namespace View
{
    public class BaseEnemy : IEnemy
    {
        EnemyMovement? _enemyMovement;

        public int XPos { get => _enemyMovement.XPos; }
        public int YPos { get => _enemyMovement.YPos; }

        public int Speed() => 200;

        public BaseEnemy()
        {
            Move();
        }

        public void Draw()
        {
            Console.SetCursorPosition(XPos, YPos);
            Console.Write("X");
        }

        public EnemyMovement Move()
        {
            _enemyMovement = new EnemyMovement(Speed());
            return _enemyMovement;
        }
    }
}

