namespace Domain.Enemies
{
    public class EnemyMovement
    {
        public static void Update(Enemy enemy, BoardDimensions boardDimensions) {
            Dimension dimension = enemy.GetDimension();

            if (
                (enemy.MovementDir > 0 && enemy.Pos.X >= boardDimensions.Width - dimension.Width) ||
                (enemy.MovementDir < 0 && enemy.Pos.X <= 0)
            ) {
                enemy.Pos += new Point(0, dimension.Height);
                enemy.MovementDir *= -1;
            }
            else {
                Point newMove = new Point(enemy.MovementDir, 0);
                if (
                    enemy.Pos.X + newMove.X < boardDimensions.Width - dimension.Width &&
                    enemy.Pos.X + newMove.X > 0
                    ) {
                    newMove *= enemy.Speed;
                }

                enemy.Pos += newMove;
            }
        }
    }
}


