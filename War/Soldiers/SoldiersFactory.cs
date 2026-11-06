using System;

namespace War.Soldiers
{
    internal class SoldierFactory
    {
        internal Soldier Create(SoldierType type)
        {
            switch (type)
            {
                case SoldierType.Shooter:
                    return new Shooter();

                case SoldierType.Sniper:
                    return new Sniper();

                case SoldierType.Flame:
                    return new FlamethrowerOperator();

                case SoldierType.Machine:
                    return new MachineGunner();

                default:
                    throw new ArgumentException("Неизвестный тип солдата.");
            }
        }
    }
}
