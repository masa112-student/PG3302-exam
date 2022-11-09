using System;
namespace Domain
{
    public interface IEnemy
    {
        int XPos { get; }
        int YPos { get; }

        int Speed();

        EnemyMovement Move();

        void Draw();
    }
}

