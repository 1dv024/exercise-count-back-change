# Växelpengar - nivå B

## Problem

Då du handlar i en affär och betalar kontant får du kanske växel tillbaka. I regel får affärsbiträdet hjälp av kassaapparaten med att beräkna summan kunden ska få tillbaka. Vilka sedlar och mynt som ska lämnas tillbaka får affärsbiträdet själv räkna ut i huvudet. Kan ett program göra båda sakerna istället?

Skriv ett program som i samband med ett köp efterfrågar totalsumma och erhållet belopp, bestämmer öresavrundningen till närmsta hela krontal och beräknar den växel som ska lämnas tillbaka.

Eventuella fel i samband med inmatning av totalsumma och erhållet belopp ska hanteras. Det ska inte vara möjligt att ange en totalsumma mindre än en krona eller ett erhållet belopp mindre än totalsumman. Gör användaren en felaktig inmatning ska denne erbjudas en ny möjlighet att mata in ett korrekt värde.

![ScreenShot B](../bilder/b-bilder/countBackChange_B.png)
Figur B.1.

Programmet ska, förutom att presentera beloppet som kunden ska betala avrundat till närmsta hela krontal, även bestämma vilka, och antalet, sedlar och mynt som kunden ska få tillbaka så att så få sedlar och mynt används som möjligt.

Växel ska kunna ges tillbaka med sedlar av valörerna 500, 200, 100, 50 och 20 samt mynten 10-, 5-, och 1-kronor. Du kan anta att det alltid finns tillräckligt antal av de sedlar och mynt som krävs. Skriv endast ut de sedlar och mynt som ska lämnas tillbaka!

Då en beräkning är gjord ska användaren kunna välja att avsluta programmet genom att trycka på _Escape_-tangenten. Trycks någon annan tangent ska användaren på nytt kunna mata in en ny totalsumma och nytt erhållet belopp.

## Öresavrundning

För att avrunda totalsumman till närmsta hela krontal kan du t.ex. använda den statiska metoden `Round` i klassen `Math`. Genom att bestämma differensen mellan den avrundade totalsumman och totalsumman erhålls öresavrundningen:

```c#
total = (uint)Math.Round(subtotal);
roundingOffAmount = total - subtotal;
```

Här är ```subtotal``` och ```roundingOffAmount``` variabler av typen ```double``` och ```total``` är en variabel av typen ```uint```.

##Uppdelning av programmet

Programmet ska delas upp i de fyra privata metoder som återfinns i klassdiagrammet i Figur B.2.

![Class diagram](../bilder/b-bilder/classDiagramB.png)
Figur B.2

_Main_

Denna metod ska anropa metoderna ```ReadPositiveDouble``` och ```ReadUint``` för att läsa in totalsumman respektive erhållet belopp. Efter att ha beräknat belopp att betala, öresavrundningen, växeln tillbaka och skrivit ut ett kvitto ska metoden ```SplitIntoDenominations``` anropas.
Satserna ska placeras i en ```do-while```-sats som avslutas då användaren trycker ner _Escape_-tangenten.

_ReadPositiveDouble_

Metoden ska returnera ett värde av typen ```double```. Innan värdet returneras ska metoden säkerställa att användaren matat in ett tal som, efter avrundning, är större eller lika med 1. Om det inmatade inte uppfyller detta villkor ska användaren få en chans att göra en ny inmatning.

Till metoden ska det vara möjligt att skicka en sträng med information som ska visas i samband med inmatningen. I Figur B.3 har argumentet ```"Ange totalsumma : "``` skickats med vid anropet av metoden.

![ScreenShot B](../bilder/b-bilder/errorMessage_B3.png)
Figur B.3

_ReadUint_

Metoden ska returnera ett värde av typen ```uint```. (Datatypen ```uint``` passar i detta fall då endast hela kronor motsvarande ett värde större än 0 ska hanteras.) 
Innan värdet returneras ska metoden säkerställa att användaren matat in ett värde som är större eller lika med angivet minsta värde. Om det inmatade inte uppfyller detta villkor ska användaren få en chans att göra en ny inmatning.

Till metoden ska det vara möjligt att skicka med två argument. Det första argumentet ska vara en sträng med information som ska visas i samband med inmatningen. Det andra argumentet är det minsta värdet som är giltigt. I Figur B.4 har argumenten "Ange erhållet belopp: " och 538 skickats med vid anropet av metoden.

![ScreenShot B](../bilder/b-bilder/errorMessage_B4.png)
Figur B.4

_SplitIntoDenominations_

Metoden ska dela upp växeln och presentera vilka valörer som ska lämnas tillbaka. Tillgängliga valörer måste lagras i en lokal array av typen ```uint```, och metoden får endast använda sig av en ```if```-sats, utan några ```else```.

Till metoden ska det vara möjligt att skicka med summan som ska lämnas tillbaka. I Figur B.5 har argumentet 462 skickats med vid anropet av metoden.

![ScreenShot B](../bilder/b-bilder/countBackChange_B5.png)
Figur B.5

## B-krav

1. Indata till programmet ska vara totalsumma respektive erhållet belopp.
	1. Totalsumman ska kunna anges i kronor och ören.
	2. Erhållet belopp ska enbart kunna anges i hela kronor.
2. Inläsning av totalsumma måste placeras i en separat statisk metod.
3. Inmatad totalsumma avrundas till närmsta hela krontal.
4. Inläsning av erhållet belopp måste placeras i en separat statisk metod.
5. Metoden ```Main``` ska skriva ut ett kvitto innehållande:
	1. Köpets totala summa.
	2. Öresavrundningen.
	3. Summa att betala efter öresavrundning.
	4. Erhållet belopp (kontant).
	5. Växel som kunden ska ha tillbaka.
6. Metoden ```SplitIntoDenominations``` ska dela upp, och skriva ut, växeln i lämpligt antal 500-, 200-, 100-, 50- och 20-lappar samt antal 10-, 5- och 1-kronor och bara presenteras om antalet sedlar och/eller mynt är större än 0.
7. Då antalet sedlar och mynt ska bestämmas måste följande uppfyllas:	
	1. Kod för beräkning och presentation måste placeras i en separat statisk metod.
	2. Division- och modulus-operatorerna måste användas.
	3. En array innehållande giltiga valörer måste användas.
	4. Endast en ```if```-sats får användas.
8. Eventuella fel i samband med inmatning av totalsumma och erhållet belopp ska tas om hand med hjälp av ```try-catch```-satser och användaren ska få en möjlighet att mata in ett nytt värde.

	Figur B.6 till Figur B.9 visar exempel på några felaktiga inmatningar som måste hanteras och ge användaren en ny möjlighet att mata in ett korrekt värde.

	![ScreenShot B](../bilder/b-bilder/errorMessage_B6.png)

	Figur B.6. Resultat av en inmatning av totalsumma mindre än 1 kr.
	
	![ScreenShot B](../bilder/b-bilder/errorMessage_B7.png)

	Figur B.7. Resultat av en inmatning som inte kan tolkas som en summa pengar.
	
	![ScreenShot B](../bilder/b-bilder/errorMessage_B8.png)

	Figur B.8. Resultat av en inmatning där det erhållna beloppet är mindre än beloppet att betala efter öresavrundning.
	
	![ScreenShot B](../bilder/b-bilder/errorMessage_B9.png)

	Figur B.9. Resultat av en inmatning där det erhållna beloppet inte kan tolkas som en summa pengar.

## Läsvärt

- variabler
	- Essential C# 6.0, 13-17.
	- http://msdn.microsoft.com/en-us/library/hh147285(VS.88).aspx#Variables
- Arrayer
	- Essential C# 6.0, 71-87. (inte flerdimensionella arrayer).
	- http://msdn.microsoft.com/en-us/library/system.array.aspx
	- http://msdn.microsoft.com/en-us/library/hh127989%28v=vs.88%29.aspx#Anchor_2 (under rubriken Arrays)
- %-operatorn
	- Essential C# 6.0, 91-92.
	- http://msdn.microsoft.com/en-us/library/0w4e0fzs.aspx
- ”if”-satsen
	- Essential C# 6.0, 111-118.
	- http://msdn.microsoft.com/en-us/library/5011f09h.aspx
- ”do-while”-satsen
	- Essential C# 6.0, 134-137.
	- http://msdn.microsoft.com/en-us/library/370s1zax.aspx
- "foreach"-satsen
	- Essential C# 6.0, 140-142.
	- http://msdn.microsoft.com/en-us/library/ttw7t8t6.aspx
- Metoder
	- Essential C# 6.0, 161-175.
	- http://msdn.microsoft.com/en-us/library/ms173114.aspx
- Undantag
	- Essential C# 6.0, 202-209.
	- Essential C# 6.0, 433-440.
	- http://msdn.microsoft.com/en-us/library/0yd65esw.aspx
	- http://msdn.microsoft.com/en-us/library/1ah5wsex.aspx
	- https://msdn.microsoft.com/en-us/library/ww58ded5.aspx
- Hantering av färger i ett konsolfönster
	- http://msdn.microsoft.com/en-us/library/yae1s0f9.aspx
	- http://msdn.microsoft.com/en-us/library/s66hf68a.aspx
	- http://msdn.microsoft.com/en-us/library/d3zkyxxe.aspx

[Lösning](losning/)
