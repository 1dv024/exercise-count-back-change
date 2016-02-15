# Statisk addition

## Problem

Komplettera det ofullständiga projektet ”_StaticAdding_” med den statiska klassen `MyMath` så att metoden `Main` kan kompileras och exekveras utan problem.

Klassen `MyMath` ska ha två statiska metoder, som båda ska heta `Add` men ha olika parameterlistor och därmed olika signaturer. Den ena metoden ska returnera summan av två heltal av typen `int`, och den andra metoden ska returnera summan av två flyttal av typen `double`.

Metoden `Main` i klassen `Program` får du inte ändra på något sätt. Koden ska oförändrad kunna använda de statiska metoderna i klassen `MyMath` som du ska implementera (skriva).

<figure>
<img src="bilder/klassdiagram.png" alt="Klassdiagram" />
<figcaption>
Figur 1. Klassdiagram över den statiska klassen `MyMath` med de två statiska metoderna.
</figcaption>
</figure>

```c#
using System;

namespace StaticAdding
{
    class Program
    {
        static void Main(string[] args)
        {
            // Vilken statisk metod anropas?
            int sum = MyMath.Add(123, 456);
            Console.WriteLine($"Summan är: {sum}\n");

            // Vilken statisk metod anropas?
            double anotherSum = MyMath.Add(9.87, 6.54);
            Console.WriteLine($"Summan är: {anotherSum}\n");

            // Vilken statisk metod anropas?
            Console.WriteLine("Summan är: {0}\n", MyMath.Add(123, 6.54));
        }
    }
}
```

Fundera lite över vilken av de två statiska metoderna som kommer att anropas av de olika satserna. Vad är det som bestämmer det? Jo, typen som argumenten är av. Nog med ledtrådar…

## Mål

Efter att ha gjort uppgiften ska du:

- Kunna skriva en statisk metod.
- Förstå vad signaturer och överlagring (”_overloading_”) innebär i samband med metoder.
- Kunna skriva en metod som har en parameterlista.
- Kunna skriva en metod som returnerar ett värde.

## Tips

Läs om:

- Allmänt om metoder i kurslitteraturen, kapitel 4, främst under rubrikerna ”_Calling a Method_” och ”_Declaring a Method_”.
- Överlagring av metoder i kurslitteraturen, kapitel 4, under rubriken ”_Method Overloading_”.
- Statiska metoder behandlas i kurslitteraturen, kapitel 5, under underrubriken ”_Static Methods_”. Online-hjälpen ”_Static Classes and Static Class Members (C# Programming Guide)_”, http://msdn.microsoft.com/en-us/library/79b3xss3.aspx får komplettera.

[Lösning](losning/README.md)