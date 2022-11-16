using Domain.Data;
using Domain.Core;

namespace Domain.Enemies
{
    public class EnemyMovement
    {
        public static void UpdateMoveDir(IMovable enemy, Dimension boardDimensions) {
            bool hasHitXBoundry = 
                (enemy.MoveDir.X > 0 && enemy.Pos.X >= boardDimensions.Width - enemy.Size.Width) ||
                (enemy.MoveDir.X < 0 && enemy.Pos.X <= 0);

            if (hasHitXBoundry) {
                enemy.MoveDir = new Point(
                    x: enemy.MoveDir.X * -1,
                    y: enemy.Size.Height
                    );
            }
            else {
                enemy.MoveDir = enemy.MoveDir with { Y = 0 };
            }
        }
    }
}


