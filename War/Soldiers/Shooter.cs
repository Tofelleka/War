using War.Platoons;

namespace War.Soldiers
{
    internal class Shooter : Soldier
    {
        internal Shooter() : base("Стрелок", 100, 5, 20) { }

        internal override AttackReport Attack(Platoon enemyPlatoon)
        {
            enemyPlatoon.FindDeceaced();

            Soldier enemySoldier = enemyPlatoon.GetRandomSoldier();

            if (enemySoldier == null) return null;

            int actualDamage = enemySoldier.TakeDamage(Damage);

            return new AttackReport(MilitaryPosition, new Target(enemySoldier.MilitaryPosition, actualDamage));
        }
    }
}
