using War.Platoons;

namespace War.Soldiers
{
    internal class Sniper : Soldier
    {
        private const int DamageMultiplier = 2;

        internal Sniper() : base("Снайпер", 80, 0, 30) { }

        internal override AttackReport Attack(Platoon enemyPlatoon)
        {
            enemyPlatoon.FindDeceaced();

            Soldier enemySoldier = enemyPlatoon.GetRandomSoldier();

            if (enemySoldier == null) return null;

            int actualDamage = enemySoldier.TakeDamage(Damage * DamageMultiplier);

            return new AttackReport(MilitaryPosition, new Target(enemySoldier.MilitaryPosition, actualDamage));
        }
    }
}
