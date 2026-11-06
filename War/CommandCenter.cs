using System;

namespace War
{
    internal class CommandCenter
    {
        internal void ManageBattle()
        {
            bool isWork = true;

            while (isWork)
            {
                Illustrator.Instance.WelcomeMessage();

                Console.ReadKey();

                Illustrator.Instance.ShowSelectPlatoon();
                PlatoonType firstPlatoon = GetPlatoonType();

                Illustrator.Instance.ShowSelectEnemyPlatoon();
                PlatoonType secondPlatoon = GetPlatoonType();

                Battlefield battlefield = new Battlefield(firstPlatoon, secondPlatoon);

                if (battlefield.SimulateBattle())
                {
                    Illustrator.Instance.ShowWinMessage();
                }
                else
                {
                    Illustrator.Instance.ShowLoseMessage();
                }

                Console.WriteLine("\nНажмите Escape для выхода или любую клавишу для продолжения.");

                if (Console.ReadKey(true).Key == ConsoleKey.Escape) isWork = false;
            }
        }

        private PlatoonType GetPlatoonType()
        {
            bool isWork = true;

            while (isWork) {

                Illustrator.Instance.ShowPlatoonSelectionMenu();

                switch (Utils.ReadNumber())
                {
                    case Illustrator.CommandAssault:
                        return PlatoonType.assault;

                    case Illustrator.CommandPatrol:
                        return PlatoonType.patrol;

                    case Illustrator.CommandPartisan:
                        return PlatoonType.partisan;

                    case Illustrator.CommandUniversal:
                        return PlatoonType.universal;

                    default:
                        Console.WriteLine("\n\nНеверный тип отряда!");
                        break;
                }

                Console.Clear();
            }

            return PlatoonType.assault;
        }
    }
}
