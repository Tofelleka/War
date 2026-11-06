using System.Collections.Generic;

namespace War
{
    internal abstract class Soldier
    {
        internal Soldier(string militaryPosition, int health, int armor, int damage)
        {
            MilitaryPosition = militaryPosition;
            Health = health;
            Armor = armor;
            Damage = damage;
        }

        public string MilitaryPosition { get; private set; }
        public int Health { get; private set; }
        public int Armor { get; private set; }
        public int Damage { get; private set; }

        internal abstract AttackReport Attack(Platoon enemyPlatoon);

        internal int TakeDamage(int damage)
        {
            int actualDamage = damage - Armor;

            Health -= actualDamage;

            return actualDamage;
        }
    }

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

    internal class FlamethrowerOperator : Soldier
    {
        private const int QuantityTargets = 2;

        internal FlamethrowerOperator() : base("Огнемётчик", 100, 5, 15) { }

        internal override AttackReport Attack(Platoon enemyPlatoon)
        {
            enemyPlatoon.FindDeceaced();

            List<Soldier> enemySoldiers = GetAllTargets(enemyPlatoon);

            if(enemySoldiers == null) return null;

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
                    AddUniqueSoldier(targetSoldiers,enemyPlatoon);
                }
            }
            else if(enemyPlatoon.AliveInPlatoon == 0)
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

        private void AddUniqueSoldier(List<Soldier> targetSoldiers, Platoon enemyPlatoon )
        {
            Soldier targetSoldier = enemyPlatoon.GetRandomSoldier();

            if (targetSoldiers.Contains(targetSoldier) == false)
            {
                targetSoldiers.Add(targetSoldier);
            }
        }
    }

    internal class MachineGanner : Soldier
    {
        private const int QuantityTargets = 3;

        internal MachineGanner() : base("Пулемётчик", 150, 10, 15) { }

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

    internal class AttackReport
    {
        internal AttackReport(string attackersName, List<Target> targets)
        {
            AttackersName = attackersName;
            Targets = targets;
        }

        internal AttackReport(string attackersName, Target target)
        {
            AttackersName = attackersName;
            Targets = new List<Target> { target };
        }

        public IReadOnlyCollection<Target> Targets { get; private set; }

        public string AttackersName { get; private set; }
    }

    internal readonly struct Target
    {
        internal Target(string defendersName, int damage)
        {
            DefendersName = defendersName;
            Damage = damage;
        }

        public string DefendersName { get; }
        public int Damage { get; }
    }
}