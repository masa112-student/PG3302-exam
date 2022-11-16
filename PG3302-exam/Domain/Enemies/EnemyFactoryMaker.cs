namespace Domain.Enemies
{
    public enum EnemyType
    {
        Basic,
        Fast,
        FastAttack,
    }

    public class EnemyFactoryMaker
    {
        public EnemyFactory MakeFactory(EnemyType type) {
            switch(type) {
                case EnemyType.Basic:
                    return new BasicEnemyFactory();
                case EnemyType.Fast:
                    return new FastEnemyFactory();
                case EnemyType.FastAttack:
                    return new FastAttackEnemyFactory();
                default:
                    throw new ArgumentException($"Invalid type supplied to enemy factory {type}");
            }
        }
    }
}
