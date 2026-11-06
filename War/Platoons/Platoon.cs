using System.Collections.Generic;
using War.Soldiers;

namespace War.Platoons
{
    internal class Platoon
    {
        private List<Soldier> _soldiers;

        internal Platoon(List<Soldier> soldier, string name)
        {
            _soldiers = soldier;
            PlatoonName = name;
        }

        public string PlatoonName { get; private set; }
        public int AliveInPlatoon
        {
            get
            {
                int count = 0;

                foreach (Soldier soldier in _soldiers)
                {
                    if (soldier.Health > 0) count++;
                }

                return count;
            }
        }

        internal void AttackEnemyPlatoon(Platoon enemyPlatoon)
        {
            foreach (Soldier soldier in _soldiers)
            {
                if (soldier.Health <= 0)
                {
                    continue;
                }

                AttackReport report = soldier.Attack(enemyPlatoon);

                if (report != null)
                {
                    Illustrator.Instance.ShowAttackReport(report);
                }
                else
                {
                    break;
                }
            }
        }

        internal Soldier GetRandomSoldier()
        {
            if (_soldiers.Count == 0) return null;

            return _soldiers[Utils.Random(0, _soldiers.Count)];
        }

        internal void FindDeceaced()
        {
            for (int i = _soldiers.Count - 1; i >= 0; i--)
            {
                if (_soldiers[i].Health <= 0)
                {
                    _soldiers.RemoveAt(i);
                }
            }
        }
    }
}