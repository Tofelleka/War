using System;
using System.Collections.Generic;
using War.Soldiers;

namespace War.Platoons
{
    internal class PlatoonsFactory
    {
        private SoldierFactory _soldierFactory = new SoldierFactory();

        internal Platoon CreatePlatoon(PlatoonType type)
        {
            switch (type)
            {
                case PlatoonType.Assault:
                    return CreateAssault();

                case PlatoonType.Patrol:
                    return CreatePatrol();

                case PlatoonType.Partisan:
                    return CreatePartisan();

                case PlatoonType.Universal:
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
