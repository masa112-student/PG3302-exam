using Domain.Data;
using Domain.Core;

namespace Domain.Enemies
{
    public class EnemyMovement
    {
        private readonly Dimension _boardDimensnsion;

        public EnemyMovement(Dimension boardDimensnsion) {
            _boardDimensnsion = boardDimensnsion;
        }
        public void UpdateMoveDir(IMovable enemy) {
            bool hasHitXBoundry = 
                (enemy.MoveDir.X > 0 && enemy.Pos.X >= _boardDimensnsion.Width - enemy.Size.Width) ||
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


