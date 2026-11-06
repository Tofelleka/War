namespace War.Soldiers
{
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
