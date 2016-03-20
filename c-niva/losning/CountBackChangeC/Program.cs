using System;

namespace CountBackChangeC
{
    class Program
    {
        static void Main(string[] args)
        {
            // Definiera och initiera variabler.
            uint[] denominations = { 500, 200, 100, 50, 20, 10, 5, 1 };
            uint[] notes = null;

            double subtotal = 0d;
            double roundingOffAmount = 0d;
            uint total = 0;
            uint cash = 0;
            uint change = 0;

            Console.Title = Strings.Title;

            do
            {
                Console.CursorVisible = true;

                // Hämtar summan att betala och erhållen summa av användaren, samt genomför
                // beräkningar som underlag till kvittot.
                subtotal = ReadPositiveDouble(Strings.Subtotal_Prompt);
                total = (uint)Math.Round(subtotal);

                cash = ReadUint(Strings.Cash_Prompt, total);

                roundingOffAmount = total - subtotal;
                change = cash - total;

                // Delar upp växeln i valörer.
                notes = SplitIntoDenominations(change, denominations);

                // Presenterar resultatet i form av ett kvitto.
                ViewReceipt(subtotal, roundingOffAmount, total, cash, change, notes, denominations);

                ViewMessage(Strings.Continue_Prompt);
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
                    ViewMessage(String.Format(Strings.ErrorMessage_InvalidAmount, input), true);
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

                    ViewMessage(String.Format(Strings.ErrorMessage_ToSmallAmount, input), true);
                }
                catch
                {
                    ViewMessage(String.Format(Strings.ErrorMessage_InvalidAmount, input), true);
                }
            } while (true);
        }

        private static uint[] SplitIntoDenominations(uint change, uint[] denominations)
        {
            uint[] values = new uint[denominations.Length];

            // Delar upp växeln i valörer.
            for (int i = 0; i < denominations.Length; i++)
            {
                values[i] = change / denominations[i];
                change %= denominations[i];
            }

            return values;
        }

        private static void ViewMessage(string message, bool isError = false)
        {
            Console.BackgroundColor = isError ? ConsoleColor.Red : ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void ViewReceipt(double subtotal, double roundingOffAmount, uint total,
            uint cash, uint change, uint[] notes, uint[] denominations)
        {
            Console.WriteLine(Strings.Receipt_Header);
            Console.WriteLine(Strings.Reciept_Subtotal, subtotal);
            Console.WriteLine(Strings.Reciept_RoundingOffAmount, roundingOffAmount);
            Console.WriteLine(Strings.Reciept_Total, total);
            Console.WriteLine(Strings.Reciept_Cash, cash);
            Console.WriteLine(Strings.Reciept_Change, change);
            Console.WriteLine(Strings.Reciept_Footer);

            for (int i = 0; i < notes.Length; i++)
            {
                if (notes[i] > 0)
                {
                    Console.WriteLine("{0,3}-{1}       : {2}",
                        denominations[i],
                        denominations[i] > 10 ? Strings.Denomination_Bill : Strings.Denomination_Coin,
                        notes[i]);
                }
            }
        }
    }
}

