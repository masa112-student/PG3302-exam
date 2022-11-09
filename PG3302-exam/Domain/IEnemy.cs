using System;
namespace Domain
{
    public interface IEnemy
    {
        Point Pos { get; set; }
        Sprite ActiveSprite { get; set; }
        
        int Speed();

        EnemyMovement Move();
    }
}

