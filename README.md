# Dagboksappen

## Beskrivning
Dagboksappen är en konsolapplikation som låter användaren skriva, 
lista och söka dagboksanteckningar. Anteckningarna kan sparas till fil och läsas tillbaka. 
Programmet innehåller felhantering och validering för datum, text och fil I/O.

## Hur man kör appen
1. Öppna projektet i Visual Studio eller annan C# IDE.
2. Kör programmet:
   - I Visual Studio: tryck `Ctrl + F5
3. Följ menyn för att:
   - Skriva ny anteckning
   - Lista alla anteckningar
   - Sök anteckning på datum
   - Spara anteckningar till fil
   - Läsa anteckningar från fil
   - Avsluta programmet

## Exempel på I/O

--- Dagboksappen ---
1. Skriv ny anteckning
2. Lista alla anteckningar
3. Sök anteckning på datum
4. Spara till fil
5. Läs från fil
6. Avsluta
Välj ett alternativ: 1
Ange datum (yyyy-mm-dd): 2025-09-29
Skriv din anteckning: Lärde mig switch och List i C#
Anteckning tillagd!

--- Dagboksappen ---
Välj ett alternativ: 1
Ange datum (yyyy-mm-dd): 2025-09-30
Skriv din anteckning: Övade filhantering i C#
Anteckning tillagd!

--- Dagboksappen ---
Välj ett alternativ: 2
Datum: 2025-09-29
Text: Lärde mig switch och List i C#

Datum: 2025-09-30
Text: Övade filhantering i C#

--- Dagboksappen ---
Välj ett alternativ: 3
Ange datum att söka efter (yyyy-mm-dd): 2025-09-29
Datum: 2025-09-29
Text: Lärde mig switch och List i C#

--- Dagboksappen ---
Välj ett alternativ: 4
Anteckningar sparade till diary.txt

--- Dagboksappen ---
Välj ett alternativ: 5
Anteckningar lästa från diary.txt

--- Dagboksappen ---
Välj ett alternativ: 6
Programmet avslutas. Hej då!

## Reflektion
- **Datastruktur**: Jag använde `List<DiaryEntry>` för enkel lagring av anteckningar. En `Dictionary<DateTime, DiaryEntry>` hade kunnat användas för snabbare uppslag på datum, men List räcker för små mängder data.  
- **I/O-format**: Jag valde `|` som avgränsare i textfilen, vilket gör det enkelt att spara och läsa in datum och text.  
- **Felhantering**: Programmet använder `try/catch` för fil I/O och `TryParse`/`IsNullOrWhiteSpace` för input-validering. Detta gör appen robust mot ogiltig input och saknade filer.  
- **Polish**: Konsolmenyn är tydlig, menyval ignorerar extra mellanslag och anteckningar listas i datumordning för bättre användarupplevelse.

