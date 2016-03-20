# Lösning

Lösningen på B-nivån är mer generaliserad och renodlad än på A-nivån samt också något bättre designad för att följa principen "DRY" (_Don't Repeat Yourself_). Programkoden har här refaktoriserats i flera statiska metoder för distinkta syften: 

- _IO-logiken_ för inläsning och validering av indata har avgränsats till de två "Read"-metoderna ```ReadPositiveDouble``` och ```ReadUint```. 
- Den renodlade _affärslogiken_, dvs. beräkningskoden för växelns uppdelning i valörer, har placerats i en separat statisk metod,  ```SplitIntoDenominations```. Denna logik är relativt generellt och effektivt hanterad med hjälp av en array och en ```foreach```-loop.

Tack vare strukturering av koden i flera metoder får lösningen högre läsbarhet och blir lättare att överblicka. Programmet bryter dock fortfarande mot _DRY_ genom upprepning av en mängd utskrifter. Så långt möjligt bör utskriftskod avgränsas till specifika delar av programmet, bl.a. för att minska beroenden till ett visst gränssnitt. I nuläget görs utskrifter till konsollen i alla metoder, även i ```SplitIntoDenominations``` som egentligen bara borde hantera beräkningslogik. Detta, liksom den hårda språkkopplingen gör förstås applikationen svårare att _återanvända_ i annan språkmiljö eller plattform, (exempelvis webb- eller fönsterbaserad) utan att stora delar av programmet måste skrivas om.

Det finns alltså fortfarande mer att göra avseende hur vi organiserar koden, för att bättre stödja objektorienterade grundprinciper likt _"separation of concerns"_. **Lös gärna uppgiften på C-nivån för att förbättra detta!**

```c#
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
                Console.WriteLine($"Totalt           : {subtotal,12:c}");
                Console.WriteLine($"Öresavrundning   : {roundingOffAmount,12:c}");
                Console.WriteLine($"Att betala       : {total,12:c0}");
                Console.WriteLine($"Kontant          : {cash,12:c0}");
                Console.WriteLine($"Tillbaka         : {change,12:c0}");
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
                    Console.WriteLine($"\nFEL! '{input}' kan inte tolkas som en giltig summa pengar.\n");
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
                    Console.WriteLine($"\nFEL! {value:c0} är ett för litet belopp.\n");
                    Console.ResetColor();
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\nFEL! '{input}' kan inte tolkas som en summa pengar.\n");
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
```