using System.Collections.Generic;
using War.Platoons;

namespace War.Soldiers
{
    internal class FlamethrowerOperator : Soldier
    {
        private const int QuantityTargets = 2;

        internal FlamethrowerOperator() : base("Огнемётчик", 100, 5, 15) { }

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
            List<Soldier> targetSoldiers = new List<Soldier>();

            if (enemyPlatoon.AliveInPlatoon > QuantityTargets)
            {
                while (targetSoldiers.Count < QuantityTargets)
                {
                    AddUniqueSoldier(targetSoldiers, enemyPlatoon);
                }
            }
            else if (enemyPlatoon.AliveInPlatoon == 0)
            {
                return null;
            }
            else
            {
                while (enemyPlatoon.AliveInPlatoon > targetSoldiers.Count)
                {
                    AddUniqueSoldier(targetSoldiers, enemyPlatoon);
                }
            }

            return targetSoldiers;
        }

        private void AddUniqueSoldier(List<Soldier> targetSoldiers, Platoon enemyPlatoon)
        {
            Soldier targetSoldier = enemyPlatoon.GetRandomSoldier();

            if (targetSoldiers.Contains(targetSoldier) == false)
            {
                targetSoldiers.Add(targetSoldier);
            }
        }
    }
}
