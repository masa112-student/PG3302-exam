namespace Domain.Enemies.Factories
{
    /// <summary>
    /// The abstract factory creator, uses a enum to select the factory type
    /// </summary>
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
                    return new MoreSpeedEnemyFactory();
                case EnemyType.FastAttack:
                    return new IncreasedAttackSpeedEnemyFactory();
                case EnemyType.Strong:
                    return new MoreHealthEnemyFactory();
                default:
                    throw new ArgumentException($"Invalid type supplied to enemy factory {type}");
            }
        }
    }
}
