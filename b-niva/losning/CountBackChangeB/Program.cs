using System;

namespace CountBackChangeB
{
    class Program
    {
        private static void Main(string[] args)
        {
            // Definierar och initierar variabler.
            double subtotal = 0d;
            double roundingOffAmount = 0d;
            uint total = 0;
            uint cash = 0;
            uint change = 0;

            Console.Title = "Växelpengar - nivå B";

            do
            {
                Console.CursorVisible = true;

                // Hämtar summan att betala av användaren, samt bestämmer
                // belopp att betala.
                subtotal = ReadPositiveDouble("Ange totalsumma     : ");
                total = (uint)Math.Round(subtotal);

                // Hämtar erhållen summa av användaren.
                cash = ReadUint("Ange erhållet belopp: ", total);

                // Beräknar och presenterar resultatet i form av ett kvitto.
                roundingOffAmount = total - subtotal;
                change = cash - total;

                Console.WriteLine("\nKVITTO");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Totalt           : {0,12:c}", subtotal);
                Console.WriteLine("Öresavrundning   : {0,12:c}", roundingOffAmount);
                Console.WriteLine("Att betala       : {0,12:c0}", total);
                Console.WriteLine("Kontant          : {0,12:c0}", cash);
                Console.WriteLine("Tillbaka         : {0,12:c0}", change);
                Console.WriteLine("-------------------------------\n");

                SplitIntoDenominations(change);

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nTryck tangent för ny beräkning - Esc avslutar.\n\n");
                Console.ResetColor();
                Console.CursorVisible = false;
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static double ReadPositiveDouble(string prompt)
        {
            string input = null;
            double value = 0d;

            do
            {
                try
                {
                    if (!String.IsNullOrWhiteSpace(prompt))
                    {
                        Console.Write(prompt);
                    }

                    input = Console.ReadLine();

                    value = double.Parse(input);
                    if (Math.Round(value) < 1)
                    {
                        throw new ApplicationException();
                    }

                    return value;
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nFEL! '{0}' kan inte tolkas som en giltig summa pengar.\n", input);
                    Console.ResetColor();
                }
            } while (true);
        }

        private static uint ReadUint(string prompt, uint minValue)
        {
            string input = null;
            uint value = 0;

            do
            {
                try
                {
                    if (!String.IsNullOrWhiteSpace(prompt))
                    {
                        Console.Write(prompt);
                    }

                    input = Console.ReadLine();

                    value = uint.Parse(input);
                    if (value >= minValue)
                    {
                        return value;
                    }

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nFEL! {0:c0} är ett för litet belopp.\n", value);
                    Console.ResetColor();
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nFEL! '{0}' kan inte tolkas som en summa pengar.\n", input);
                    Console.ResetColor();
                }
            } while (true);
        }

        private static void SplitIntoDenominations(uint change)
        {
            uint[] denominations = { 500, 100, 50, 20, 10, 5, 1 };
            uint count = 0;

            // Delar upp växeln i valörer.
            foreach (uint value in denominations)
            {
                count = change / value;
                if (count > 0)
                {
                    Console.WriteLine("{0,3}-{1}       : {2}", value, value > 10 ? "lappar" : "kronor", count);
                    change %= value;
                }
            }
        }

    }
}
