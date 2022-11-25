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
        Boss
    }

    public static class EnemyFactoryMaker
    {
        public static EnemyFactory MakeFactory(EnemyType type)
        {
            return type switch {
                EnemyType.Basic => new BasicEnemyFactory(),
                EnemyType.Fast => new MoreSpeedEnemyFactory(),
                EnemyType.FastAttack => new IncreasedAttackSpeedEnemyFactory(),
                EnemyType.Strong => new MoreHealthEnemyFactory(),
                EnemyType.Boss => new BossEnemyFactory(),
                _ => throw new ArgumentException($"Invalid type supplied to enemy factory {type}"),
            };
        }
    }
}
