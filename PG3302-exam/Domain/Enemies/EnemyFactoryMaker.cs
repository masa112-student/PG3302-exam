namespace Domain.Enemies
{
    public enum EnemyType
    {
        Basic,
        Fast,
    }

    public class EnemyFactoryMaker
    {
        private readonly Dimension _boardDimensions;

        public EnemyFactoryMaker(Dimension boardDimensions) {
            _boardDimensions = boardDimensions;
        }


        public EnemyFactory MakeFactory(EnemyType type) {
            switch(type) {
                case EnemyType.Basic:
                    return new BasicEnemyFactory(_boardDimensions);
                case EnemyType.Fast:
                    return new FastEnemyFactory(_boardDimensions);
                default:
                    throw new ArgumentException($"Invalid type supplied to enemy factory {type}");
            }
        }
    }
}
