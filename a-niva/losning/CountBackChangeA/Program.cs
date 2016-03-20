using System;

namespace CountBackChangeA
{
    class Program
    {
        static void Main(string[] args)
        {
            // Definiera variabler.
            double change;
            double cash;
            int count;
            string input = null;
            int remainder;
            double roundingOffAmount;
            double subtotal;
            double total;

            Console.Title = "Växelpengar - nivå A";

            // Hämta totalsumma och erhållet belopp av användaren.
            do
            {
                try
                {
                    Console.Write("Ange totalsumma     : ");
                    input = Console.ReadLine();
                    subtotal = double.Parse(input);
                    if (subtotal >= 1)
                    {
                        break;
                    }

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\nFEL! {subtotal:c} är ett för litet belopp. Köpet kunde inte genomföras.\n");
                    Console.ResetColor();
                    return;
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\nFEL! '{input}' kan inte tolkas som en giltig summa pengar.\n");
                    Console.ResetColor();
                }
            } while (true);


            do
            {
                try
                {
                    Console.Write("Ange erhållet belopp: ");
                    input = Console.ReadLine();
                    cash = double.Parse(input);
                    if (cash >= subtotal)
                    {
                        break;
                    }

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\nFEL! {cash:c} är ett för litet belopp. Köpet kunde inte genomföras.\n");
                    Console.ResetColor();
                    return;
                }
                catch
                {
                    Console.WriteLine($"\nFEL! '{input}' kan inte tolkas som en giltig summa pengar.\n");
                }
            } while (true);

            // Beräknar och presenterar resultatet.
            roundingOffAmount = Math.Round(subtotal) - subtotal;
            total = subtotal + roundingOffAmount;
            change = cash - total;

            Console.WriteLine("\nKVITTO");
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Totalt           : {subtotal,12:c}");
            Console.WriteLine($"Öresavrundning   : {roundingOffAmount,12:c}");
            Console.WriteLine($"Att betala       : {total,12:c0}");
            Console.WriteLine($"Kontant          : {cash,12:c0}");
            Console.WriteLine($"Tillbaka         : {change,12:c0}");
            Console.WriteLine("-------------------------------\n");

            remainder = (int)(change); // Trunkerar decimaler (0:orna...).

            count = remainder / 500;
            if (count > 0)
            {
                Console.WriteLine($" 500-lappar       : {count}");
                remainder %= 500;
            }

            count = remainder / 200;
            if (count > 0)
            {
                Console.WriteLine($" 200-lappar       : {count}");
                remainder %= 200;
            }

            count = remainder / 100;
            if (count > 0)
            {
                Console.WriteLine($" 100-lappar       : {count}");
                remainder %= 100;
            }

            count = remainder / 50;
            if (count > 0)
            {
                Console.WriteLine($"  50-lappar       : {count}");
                remainder %= 50;
            }

            count = remainder / 20;
            if (count > 0)
            {
                Console.WriteLine($"  20-lappar       : {count}");
                remainder %= 20;
            }

            count = remainder / 10;
            if (count > 0)
            {
                Console.WriteLine($"  10-kronor       : {count}");
                remainder %= 10;
            }

            count = remainder / 5;
            if (count > 0)
            {
                Console.WriteLine($"   5-kronor       : {count}");
                remainder %= 5;
            }

            if (remainder > 0)
            {
                Console.WriteLine($"   1-kronor       : {remainder}");
            }
        }
    }
}
