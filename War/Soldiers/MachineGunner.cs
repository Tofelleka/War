using System.Collections.Generic;
using War.Platoons;

namespace War.Soldiers
{
    internal class MachineGunner : Soldier
    {
        private const int QuantityTargets = 3;

        internal MachineGunner() : base("Пулемётчик", 150, 10, 15) { }

        internal override AttackReport Attack(Platoon enemyPlatoon)
        {
            enemyPlatoon.FindDeceaced();

            List<Soldier> enemySoldiers = GetAllTargets(enemyPlatoon);

            if (enemySoldiers == null) return null;

            List<Target> targets = new List<Target>();

            int actualDamage = 0;

            foreach (Soldier soldier in enemySoldiers)
            {
                actualDamage = soldier.TakeDamage(Damage);

                targets.Add(new Target(soldier.MilitaryPosition, actualDamage));
            }

            return new AttackReport(MilitaryPosition, targets);
        }

        private List<Soldier> GetAllTargets(Platoon enemyPlatoon)
        {
            Soldier targetSoldier = null;

            List<Soldier> targetSoldiers = new List<Soldier>();

            if (enemyPlatoon.AliveInPlatoon == 0) return null;

            while (targetSoldiers.Count < QuantityTargets)
            {
                targetSoldier = enemyPlatoon.GetRandomSoldier();

                targetSoldiers.Add(targetSoldier);
            }

            return targetSoldiers;
        }
    }
}
