using System;
using System.Security.Cryptography.X509Certificates;

namespace AbilityScoreTester
{
    class Program
    {
        static void Main(string[] args)
        {
            AbilityScoreCalculator calculator = new AbilityScoreCalculator();

            while (true)
            {
                calculator.RollResult = ReadInt(calculator.RollResult, "Starting 4d6 roll");
                calculator.DivideBy = ReadDouble(calculator.DivideBy, "Divide by");
                calculator.AddAmount = ReadInt(calculator.AddAmount, "Add amount");
                calculator.Minimum = ReadInt(calculator.Minimum, "Minimum");
                calculator.CalculateAbilityScore();
                Console.WriteLine("Calculated ability score: " + calculator.Score);
                Console.WriteLine("Press Q to quit, any other key to continue");
                char keyChar = Console.ReadKey(true).KeyChar;
                if ((keyChar == 'Q') || (keyChar == 'q')) return;
            }

            static int ReadInt(int oldValue, string prompt)
            {
                Console.WriteLine(prompt + " [" + oldValue + "]: ");

                if (int.TryParse(Console.ReadLine(), out int valueResult))
                {
                    Console.WriteLine("Using value: " + valueResult);
                    return valueResult;
                }
                else
                {
                    Console.WriteLine("Value invalid, reusing old value: [" + oldValue + "]");
                    return oldValue;
                }
            }

            static double ReadDouble(double oldValue, string prompt)
            {
                Console.WriteLine(prompt + ": [" + oldValue + "]");

                if (double.TryParse(Console.ReadLine(), out double valueResult))
                {
                    Console.WriteLine("Using value: " + valueResult);
                    return valueResult;
                }
                else
                {
                    Console.WriteLine("Value invalid, reusing old value: [" + oldValue + "]");
                    return oldValue;
                }
            }
        }
    }
}
