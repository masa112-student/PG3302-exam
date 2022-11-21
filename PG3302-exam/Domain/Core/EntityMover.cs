using Domain.Data;

namespace Domain.Core
{
    /// <summary>
    /// A Util class for moing all IMovable instances
    /// 
    /// Moves the entity along its MoveDir axis and adds the speed to it.
    /// If clamp is set to true the it will not allow the entity to move out of bounds
    /// 
    /// </summary>
    public class EntityMover
    {
        private Dimension _boardDimensions;
        public EntityMover(Dimension boardDimensions)
        {
            _boardDimensions = boardDimensions;
        }

        public void Move(IMovable? entity, bool clamp = false)
        {
            if (entity == null) return;

            Point newMove = entity.MoveDir * entity.Speed;

            bool moveIsInBoundry = 
                entity.Pos.X + newMove.X < _boardDimensions.Width - entity.Size.Width &&
                entity.Pos.X + newMove.X > 0;

            if (!moveIsInBoundry)
            {
                newMove /= entity.Speed;
            }

            entity.Pos += newMove;

            if (clamp)
            {
                bool movingLeft = newMove.X < 0;
                bool movingUp = newMove.Y < 0;

                if (movingLeft && entity.Pos.X < 0)
                {
                    entity.Pos = entity.Pos with { X = 0 };
                }
                else if (!movingLeft && entity.Pos.X + entity.Size.Width > _boardDimensions.Width)
                {
                    entity.Pos = entity.Pos with { X = _boardDimensions.Width - entity.Size.Width };
                }

                if (movingUp && entity.Pos.Y < 0)
                {
                    entity.Pos = entity.Pos with { Y = 0 };
                }
                else if (!movingUp && entity.Pos.Y + entity.Size.Height > _boardDimensions.Height)
                {
                    entity.Pos = entity.Pos with { Y = _boardDimensions.Height - entity.Size.Height };
                }
            }
        }
    }
}


