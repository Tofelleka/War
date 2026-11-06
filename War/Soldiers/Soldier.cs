using War.Platoons;

namespace War.Soldiers
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
}