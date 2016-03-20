# Lösning

Med programklassens relativt välavgränsade, statiska metoder för olika logiska uppgifter, så är denna lösning konceptuellt bra organiserad för att stödja den viktiga objektorienterade principen om *"Separation of concerns"*. Att följa denna hjälper oss att skapa _förståbar_, _skalbar_ och _återanvändbar_ programkod. En del i detta arbete är förstås att också vara noggrann och konsekvent med vår namngivning av kodens identifierare. Om vi gjort ett bra arbete(?) så bör det räcka med en studie av Programklassens medlemsmetoder för att få en överskådlig bild av programmets funktion:

- ```static void Main(string[] args)```
- ```private static double ReadPositiveDouble(string prompt)```
- ```private static uint ReadUint(string prompt, uint minValue)```
- ```private static uint[] SplitIntoDenominations(uint change, uint[] denominations)```
- ```private static void ViewMessage(string message, bool isError = false)```
- ```private static void ViewReceipt(double subtotal, double roundingOffAmount, uint total, uint cash, uint change, uint[] notes, uint[] denominations)```

Som du ser har vi varit noga med att använda åtkomstmodifieraren ```private```, för att stödja en annan viktig OOP-princip kallad *inkapsling*.  Utgå från att medlemmarna i din klass ska ha privat åtkomst och fundera alltid en extra gång över vilka motiven är när du väljer att ge publik åtkomst till någon klassmedlem. 

Den "affärslogiska" delen av programmet sköts i metoden ```SplitIntoDenominations``` utan inblandning av andra uppgifter (likt utskrifter till presentationsgränssnittet/konsollen). Med hjälp av de båda ```View```-metoderna  avlastas programmet från en mängd återkommande meddelande-utskrifter till användaren, vilket bidrar till en renare programkod som är enklare att både förstå och vidareutveckla.  

Den största vinsten är troligen användningen av en separat resurs-fil (```Strings.resx```)  för alla strängkonstanter i programmet. Detta ger en flexibilitet angående språkval som gör det möjligt att med hjälp av flera resursfiler erbjuda enkelt byte av språk enligt användarens behov.

Även om denna lösning uppfyller "OOP-principer" på ett bättre sätt än lösningarna på A- och B-nivån, så finns säkert detaljer att "skjuta på" för den som ställer höga krav på programkvalitet ... En sådan svag punkt är bristerna i programmets dokumentation. Framförallt är den ofullständig avseende de xml-kommentarer ("summary") som alltid ska finnas till varje klassdefinition och dess medlemmar. I detta avseende ber vi dig att inte "göra som vi gör"... utan "göra som vi säger" - dvs. vara noggrann med kommentarer i alla dina examinationsuppgifter! ;) 

Läs mer om hur **xml-kommentarer** kan underlätta livet i Visual Studio-editorn med löpande kod-tips medan du arbetar! Eller hur du automatgenererar din välskrivna XML-dokumentation till en separat xml-fil:  

+ Essential C# 6.0, 414-418.
+ https://msdn.microsoft.com/en-us/library/b2s063f7%28v=vs.110%29.aspx

```c#
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


```