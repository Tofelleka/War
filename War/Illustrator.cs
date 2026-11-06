using System;
using War.Platoons;
using War.Soldiers;

namespace War
{
    internal class Illustrator
    {
        internal const int CommandAssault = 1;
        internal const int CommandPatrol = 2;
        internal const int CommandPartisan = 3;
        internal const int CommandUniversal = 4;

        private static Illustrator _instance;

        private Illustrator() { }

        public static Illustrator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Illustrator();
                }

                return _instance;
            }
        }

        internal void ShowAttackReport(AttackReport attackReport)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"[{attackReport.AttackersName}] ");
            Console.ResetColor();

            foreach (Target target in attackReport.Targets)
            {
                Console.Write($"атаковал ");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"[{target.DefendersName}]");
                Console.ResetColor();

                Console.Write($" и нанёс ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{target.Damage}");
                Console.ResetColor();

                Console.WriteLine(" урона.");
            }
        }

        internal void WelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=================================================");
            Console.WriteLine("          КОМАНДНЫЙ ЦЕНТР");
            Console.WriteLine("=================================================");
            Console.ResetColor();
            Console.WriteLine("\nПриветствую вас, Командир.");
            Console.WriteLine("Враг уже наступает. Выберите отряд для боя и укажите, на кого напасть.");
            Console.WriteLine("Помните: от вашего выбора зависит исход битвы!");
            Console.WriteLine();
        }

        internal void ShowSelectPlatoon()
        {
            Console.Write("\nВыберите свой отряд: ");
        }

        internal void ShowSelectEnemyPlatoon()
        {
            Console.Write("\nВыберите отряд противника: ");
        }

        internal void ShowPlatoonSelectionMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=================================================");
            Console.WriteLine("          ДОСТУПНЫЕ ОТРЯДЫ");
            Console.WriteLine("=================================================");
            Console.ResetColor();

            Console.WriteLine($"{CommandAssault} - {PlatoonConfig.AssaultName} " +
                $"({PlatoonConfig.AssaultShooters} стрелков, " +
                $"{PlatoonConfig.AssaultFlamethrowerOperators} огнемётчика, " +
                $"{PlatoonConfig.AssaultMachineGunners} пулемётчика)");

            Console.WriteLine($"{CommandPatrol} - {PlatoonConfig.PatrolName} " +
                $"({PlatoonConfig.PatrolShooters} стрелков, " +
                $"{PlatoonConfig.PatrolMachineGunners} пулемётчик, " +
                $"{PlatoonConfig.PatrolSnipers} снайпер)");

            Console.WriteLine($"{CommandPartisan} - {PlatoonConfig.PartisanName} " +
                $"({PlatoonConfig.PartisanShooters} стрелков, " +
                $"{PlatoonConfig.PartisanSnipers} снайперов)");

            Console.WriteLine($"{CommandUniversal} - {PlatoonConfig.UniversalName} " +
                $"({PlatoonConfig.UniversalShooters} стрелков, " +
                $"{PlatoonConfig.UniversalMachineGunners} пулемётчика, " +
                $"{PlatoonConfig.UniversalFlamethrowerOperators} огнемётчик, " +
                $"{PlatoonConfig.UniversalSnipers} снайпер)");

            Console.Write("\nВведите номер отряда: ");
        }

        internal void ShowBattleHeader(string firstPlatoon, string secondPlatoon)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("=================================================");
            Console.WriteLine($"   {firstPlatoon} отряд  VS  {secondPlatoon} отряд");
            Console.WriteLine("=================================================");

            Console.ResetColor();
            Console.WriteLine();
        }

        internal void ShowBattleStatus(string firstPlatoon, int firstAlive, string secondPlatoon, int secondAlive)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("-------------------------------------------------");
            Console.Write($" {firstPlatoon}: ");
            Console.ForegroundColor = firstAlive > 0 ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write($"{firstAlive} живых");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" | ");

            Console.Write($" {secondPlatoon}: ");
            Console.ForegroundColor = secondAlive > 0 ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write($"{secondAlive} живых");

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------");
        }

        internal void ShowWinMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=================================================");
            Console.WriteLine("          ПОБЕДА!");
            Console.WriteLine("=================================================");
            Console.ResetColor();
            Console.WriteLine("Отличная работа, Командир! Наши ребята победили!");
        }

        internal void ShowLoseMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n=================================================");
            Console.WriteLine("          ПОРАЖЕНИЕ...");
            Console.WriteLine("=================================================");
            Console.ResetColor();
            Console.WriteLine("На этот раз вы нас подвели, Командир... Будем надеяться, что в следующий раз наши люди погибнут не зря...");
        }
    }
}