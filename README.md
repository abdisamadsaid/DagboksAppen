# Dagboksappen

## Beskrivning
Dagboksappen �r en konsolapplikation som l�ter anv�ndaren skriva, 
lista och s�ka dagboksanteckningar. Anteckningarna kan sparas till fil och l�sas tillbaka. 
Programmet inneh�ller felhantering och validering f�r datum, text och fil I/O.

## Hur man k�r appen
1. �ppna projektet i Visual Studio eller annan C# IDE.
2. K�r programmet:
   - I Visual Studio: tryck `Ctrl + F5
3. F�lj menyn f�r att:
   - Skriva ny anteckning
   - Lista alla anteckningar
   - S�k anteckning p� datum
   - Spara anteckningar till fil
   - L�sa anteckningar fr�n fil
   - Avsluta programmet

## Exempel p� I/O

--- Dagboksappen ---
1. Skriv ny anteckning
2. Lista alla anteckningar
3. S�k anteckning p� datum
4. Spara till fil
5. L�s fr�n fil
6. Avsluta
V�lj ett alternativ: 1
Ange datum (yyyy-mm-dd): 2025-09-29
Skriv din anteckning: L�rde mig switch och List i C#
Anteckning tillagd!

--- Dagboksappen ---
V�lj ett alternativ: 1
Ange datum (yyyy-mm-dd): 2025-09-30
Skriv din anteckning: �vade filhantering i C#
Anteckning tillagd!

--- Dagboksappen ---
V�lj ett alternativ: 2
Datum: 2025-09-29
Text: L�rde mig switch och List i C#

Datum: 2025-09-30
Text: �vade filhantering i C#

--- Dagboksappen ---
V�lj ett alternativ: 3
Ange datum att s�ka efter (yyyy-mm-dd): 2025-09-29
Datum: 2025-09-29
Text: L�rde mig switch och List i C#

--- Dagboksappen ---
V�lj ett alternativ: 4
Anteckningar sparade till diary.txt

--- Dagboksappen ---
V�lj ett alternativ: 5
Anteckningar l�sta fr�n diary.txt

--- Dagboksappen ---
V�lj ett alternativ: 6
Programmet avslutas. Hej d�!

## Reflektion
- **Datastruktur**: Jag anv�nde `List<DiaryEntry>` f�r enkel lagring av anteckningar. En `Dictionary<DateTime, DiaryEntry>` hade kunnat anv�ndas f�r snabbare uppslag p� datum, men List r�cker f�r sm� m�ngder data.  
- **I/O-format**: Jag valde `|` som avgr�nsare i textfilen, vilket g�r det enkelt att spara och l�sa in datum och text.  
- **Felhantering**: Programmet anv�nder `try/catch` f�r fil I/O och `TryParse`/`IsNullOrWhiteSpace` f�r input-validering. Detta g�r appen robust mot ogiltig input och saknade filer.  
- **Polish**: Konsolmenyn �r tydlig, menyval ignorerar extra mellanslag och anteckningar listas i datumordning f�r b�ttre anv�ndarupplevelse.

