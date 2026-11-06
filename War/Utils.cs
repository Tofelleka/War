using System;

namespace War
{
        internal static class Utils
        {
            public static Random random = new Random();

            public static int ReadNumber()
            {
                bool isWork = true;

                int numberForReturn = 0;

                while (isWork)
                {
                    if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
                    {
                        isWork = false;
                        numberForReturn = number;
                    }
                    else
                    {
                        Console.WriteLine("\n\nНеверный ввод, это должно быть положительное число.");
                    }
                }

                return numberForReturn;
            }

            public static int Random(int min, int max)
            {
                return random.Next(min, max);
            }
        }
    }