namespace Domain.Enemies.Factories
{
    public enum EnemyType
    {
        Basic,
        Fast,
        Strong,
        FastAttack,
    }

    public class EnemyFactoryMaker
    {
        public EnemyFactory MakeFactory(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.Basic:
                    return new BasicEnemyFactory();
                case EnemyType.Fast:
                    return new FastEnemyFactory();
                case EnemyType.FastAttack:
                    return new FastAttackEnemyFactory();
                case EnemyType.Strong:
                    return new StrongEnemyFactory();
                default:
                    throw new ArgumentException($"Invalid type supplied to enemy factory {type}");
            }
        }
    }
}
