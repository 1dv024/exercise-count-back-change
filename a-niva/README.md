# Växelpengar - nivå A

## Problem

Då du handlar i en affär och betalar kontant får du kanske växel tillbaka. I regel får affärsbiträdet hjälp av kassaapparaten med att beräkna summan kunden ska få tillbaka. Vilka sedlar och mynt som ska lämnas tillbaka får affärsbiträdet själv räkna ut i huvudet. Kan ett program göra båda sakerna istället?

Skriv ett program som i samband med ett köp efterfrågar totalsumma och erhållet belopp, bestämmer öresavrundningen till närmsta hela krontal och beräknar den växel som ska lämnas tillbaka.

Eventuella fel i samband med inmatning av totalsumma och erhållet belopp ska hanteras. Det ska inte vara möjligt att ange en totalsumma mindre än en krona eller ett erhållet belopp mindre än totalsumman.

```
Ange totalsumma     : 271,38
Ange erhållet belopp: 1000

KVITTO
-------------------------------
Totalt           :    271,38 kr
Öresavrundning   :     -0,38 kr
Att betala       :       271 kr
Kontant          :     1.000 kr
Tillbaka         :       729 kr
-------------------------------

 500-lappar       : 1
 200-lappar       : 1
  20-lappar       : 1
   5-kronor       : 1
   1-kronor       : 4
```

Programmet ska, förutom att presentera beloppet kunden ska betala avrundat till närmsta hela krontal, även bestämma vilka, och antalet, sedlar och mynt som kunden ska få tillbaka så att så få sedlar och mynt används som möjligt.
Växel ska kunna ges tillbaka med sedlar av valörerna 500, 100, 50 och 20 samt mynten 10-, 5-, och 1-kronor. Du kan anta att det alltid finns tillräckligt antal av de sedlar och mynt som krävs. Skriv endast ut de sedlar och mynt som ska lämnas tillbaka.

## Öresavrundning

För att avrunda totalsumman till närmsta hela krontal kan du t.ex. använda den statiska metoden `Round` i klassen `Math`. Genom att bestämma differensen mellan den avrundade totalsumman och totalsumman erhålls öresavrundningen:

```c#
total = (uint)Math.Round(subtotal);
roundingOffAmount = total - subtotal;
```

Där ```subtotal``` och ```roundingOffAmount``` är variabler av typen ```double``` och ```total``` är en variabel av typen ```uint```.

## Krav

1. Indata till programmet ska vara totalsumma respektive erhållet belopp.
	1. Totalsumman ska kunna anges i kronor och ören.
	2. Erhållet belopp ska enbart kunna anges i hela kronor.
2. Inmatad totalsumma avrundas till närmsta hela krontal.
3. Utdata från programmet ska vara ett kvitto innehållande:
	1. Köpets totala summa.
	2. Öresavrundningen.
	3. Summa att betala efter öresavrundning.
	4. Erhållet belopp (kontant).
	5. Växel kunden ska ha tillbaka.
	6. Växeln kunden ska ha tillbaka ska även delas upp i lämpligt antal 500-, 200-, 100-, 50- och 20-lappar samt antal 10-, 5- och 1-kronor och bara presenteras om antalet sedlar och/eller mynt är större än 0.
4. Antalet sedlar och mynt ska bestämmas med hjälp av division- och modulusoperatorerna.
5. Samlingar som t.ex. arrayer får inte användas på något sätt.
6. Eventuella fel i samband med inmatningen ska tas om hand med hjälp av ”try-catch”-satser och användaren ska få en ny möjlighet att mata in.
 
```shell
Ange totalsumma     : 371,38
Ange erhållet belopp: inget som kan tolkas som ett heltal!

FEL! 'inget som kan tolkas som ett heltal!' kan inte tolkas som en giltig summa
pengar.

Ange erhållet belopp:
```

7. Om den inmatade totalsumman efter avrundning motsvarar ett belopp mindre än en krona är det att betrakta som ett fel varför programmet ska avslutas efter att ett felmeddelande presenterats.
 
```shell
Ange totalsumma     : 0,48

FEL! 0,48 kr är ett för litet belopp. Köpet kunde inte genomföras.
```

8. Om beloppet att betala efter öresavrundning är större än det erhållna beloppet är det att betrakta som ett fel varför programmet ska avslutas efter att ett felmeddelande presenterats.
 
```shell
Ange totalsumma     : 371,38
Ange erhållet belopp: 300

FEL! 300,00 kr är ett för litet belopp. Köpet kunde inte genomföras.
```

## Läsvärt

- variabler
	- Essential C# 6.0, 13-17.
	- http://msdn.microsoft.com/en-us/library/hh147285(VS.88).aspx#Variables
- %-operatorn
	- Essential C# 6.0, 91-92.
	- http://msdn.microsoft.com/en-us/library/0w4e0fzs.aspx
- ”if”-satsen
	- Essential C# 6.0, 111-118.
	- http://msdn.microsoft.com/en-us/library/5011f09h.aspx
- ”do-while”-satsen
	- Essential C# 6.0, 134-137.
	- http://msdn.microsoft.com/en-us/library/370s1zax.aspx
- “try-catch”-satsen
	- Essential C# 6.0, 202-209.
	- http://msdn.microsoft.com/en-us/library/0yd65esw.aspx
- Hantering av färger i ett konsolfönster
	- http://msdn.microsoft.com/en-us/library/yae1s0f9.aspx
	- http://msdn.microsoft.com/en-us/library/s66hf68a.aspx
	- http://msdn.microsoft.com/en-us/library/d3zkyxxe.aspx

[Lösning](losning/)
