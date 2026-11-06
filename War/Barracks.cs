using System;
using System.Collections.Generic;

namespace War
{
    internal enum SoldierType
    {
        Shooter,
        Sniper,
        Flame,
        Machine
    }

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
                    return new MachineGanner();

                default:
                    throw new ArgumentException("Неизвестный тип солдата.");
            }
        }
    }

    internal enum PlatoonType
    {
        assault,
        patrol,
        partisan,
        universal
    }

    internal static class PlatoonConfig
    {
        internal const string AssaultName = "Штурмовой";
        internal const int AssaultFlamethrowerOperators = 2;
        internal const int AssaultMachineGunners = 2;
        internal const int AssaultShooters = 6;

        internal const string PatrolName = "Патрульный";
        internal const int PatrolSnipers = 1;
        internal const int PatrolMachineGunners = 1;
        internal const int PatrolShooters = 8;

        internal const string PartisanName = "Партизанский";
        internal const int PartisanSnipers = 5;
        internal const int PartisanShooters = 5;

        internal const string UniversalName = "Универсальный";
        internal const int UniversalSnipers = 1;
        internal const int UniversalFlamethrowerOperators = 1;
        internal const int UniversalMachineGunners = 2;
        internal const int UniversalShooters = 6;
    }

    internal class PlatoonsFactory
    {
        private SoldierFactory _soldierFactory = new SoldierFactory();

        internal Platoon CreatePlatoon(PlatoonType type)
        {
            switch (type)
            {
                case PlatoonType.assault:
                    return CreateAssault();

                case PlatoonType.patrol:
                    return CreatePatrol();

                case PlatoonType.partisan:
                    return CreatePartisan();

                case PlatoonType.universal:
                    return CreateUniversal();

                default:
                    throw new ArgumentException("Неизвестный тип взвода.");
            }
        }

        private void AddSoldier(SoldierType type, int quantity, List<Soldier> soldiers)
        {
            for (int i = 0; i < quantity; i++)
            {
                soldiers.Add(_soldierFactory.Create(type));
            }
        }

        private Platoon CreateAssault()
        {
            List<Soldier> soldiers = new List<Soldier>();

            AddSoldier(SoldierType.Flame, PlatoonConfig.AssaultFlamethrowerOperators, soldiers);
            AddSoldier(SoldierType.Machine, PlatoonConfig.AssaultMachineGunners, soldiers);
            AddSoldier(SoldierType.Shooter, PlatoonConfig.AssaultShooters, soldiers);

            return new Platoon(soldiers, PlatoonConfig.AssaultName);
        }

        private Platoon CreatePatrol()
        {
            List<Soldier> soldiers = new List<Soldier>();

            AddSoldier(SoldierType.Sniper, PlatoonConfig.PatrolSnipers, soldiers);
            AddSoldier(SoldierType.Machine, PlatoonConfig.PatrolMachineGunners, soldiers);
            AddSoldier(SoldierType.Shooter, PlatoonConfig.PatrolShooters, soldiers);

            return new Platoon(soldiers, PlatoonConfig.PatrolName);
        }

        private Platoon CreatePartisan()
        {
            List<Soldier> soldiers = new List<Soldier>();

            AddSoldier(SoldierType.Sniper, PlatoonConfig.PartisanSnipers, soldiers);
            AddSoldier(SoldierType.Shooter, PlatoonConfig.PartisanShooters, soldiers);

            return new Platoon(soldiers, PlatoonConfig.PartisanName);
        }

        private Platoon CreateUniversal()
        {
            List<Soldier> soldiers = new List<Soldier>();

            AddSoldier(SoldierType.Sniper, PlatoonConfig.UniversalSnipers, soldiers);
            AddSoldier(SoldierType.Flame, PlatoonConfig.UniversalFlamethrowerOperators, soldiers);
            AddSoldier(SoldierType.Machine, PlatoonConfig.UniversalMachineGunners, soldiers);
            AddSoldier(SoldierType.Shooter, PlatoonConfig.UniversalShooters, soldiers);

            return new Platoon(soldiers, PlatoonConfig.UniversalName);
        }
    }
}