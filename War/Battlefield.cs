using System;
using System.Threading;

namespace War
{
    internal class Battlefield
    {
        private PlatoonsFactory _platoonsFactory = new PlatoonsFactory();

        private Platoon _firstPlatoon;
        private Platoon _secondPlatoon;

        internal Battlefield(PlatoonType firstType, PlatoonType secondType)
        {
            _firstPlatoon = _platoonsFactory.CreatePlatoon(firstType);
            _secondPlatoon = _platoonsFactory.CreatePlatoon(secondType);
        }

        internal bool SimulateBattle()
        {
            bool isWork = true;
            bool result = false;

            while (isWork)
            {
                Thread.Sleep(1000);

                Illustrator.Instance.ShowBattleHeader(_firstPlatoon.PlatoonName, _secondPlatoon.PlatoonName);
                
                _firstPlatoon.AttackEnemyPlatoon(_secondPlatoon);

                Illustrator.Instance.ShowBattleStatus(
        _firstPlatoon.PlatoonName, _firstPlatoon.AliveInPlatoon,
        _secondPlatoon.PlatoonName, _secondPlatoon.AliveInPlatoon);

                if (_secondPlatoon.AliveInPlatoon == 0) result = true;

                Thread.Sleep(5000);

                Illustrator.Instance.ShowBattleHeader(_firstPlatoon.PlatoonName, _secondPlatoon.PlatoonName);

                _secondPlatoon.AttackEnemyPlatoon(_firstPlatoon);

                Illustrator.Instance.ShowBattleStatus(
        _firstPlatoon.PlatoonName, _firstPlatoon.AliveInPlatoon,
        _secondPlatoon.PlatoonName, _secondPlatoon.AliveInPlatoon);

                Thread.Sleep(4000);

                if (_secondPlatoon.AliveInPlatoon == 0 || _firstPlatoon.AliveInPlatoon == 0) isWork = false;
            }

            return result;
        }
    }
}