namespace Domain.Enemies
{
    public class EnemyMovement
    {
        public static void Update(IMovable enemy, Dimension boardDimensions) {
            Dimension size = enemy.Size;

            if (
                (enemy.MoveDir.X > 0 && enemy.Pos.X >= boardDimensions.Width - size.Width) ||
                (enemy.MoveDir.X < 0 && enemy.Pos.X <= 0)
            ) {
                enemy.Pos += new Point(0, size.Height);
                enemy.MoveDir.X *= -1;
            }
            else {
                Point newMove = new Point(enemy.MoveDir.X, 0);
                if (
                    enemy.Pos.X + newMove.X < boardDimensions.Width - size.Width &&
                    enemy.Pos.X + newMove.X > 0
                    ) {
                    newMove *= enemy.Speed;
                }

                enemy.Pos += newMove;
            }
        }
    }
}


