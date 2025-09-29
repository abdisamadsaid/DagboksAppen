using System.Security.Cryptography.X509Certificates;

namespace DagboksAppen
{
    class Program
    {
        static List<DiaryEntry> diaryEntries = new List<DiaryEntry>();

        static void AddEntry()
        {
            Console.Write("Ange datum (yyy-mm-dd");
            string dateInput = Console.ReadLine();

            if (!DateTime.TryParse(dateInput, out DateTime date))
            {
                Console.WriteLine("Ogiltigt datumformat. Försök igen.");
                return;
            }

            Console.Write("Skriv din anteckning: ");
            string text = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Anteckningen får inte vara tom.");
                return;
            }

            DiaryEntry entry = new DiaryEntry
            {
                Date = date,
                Text = text
            };

            diaryEntries.Add(entry);
            Console.WriteLine("Anteckning tillagd!");
        }

        static void ListEntries()
        {
            if (diaryEntries.Count == 0)
            {
                Console.WriteLine("Inga anteckningar att visa");
                return;
            }

            foreach (var entry in diaryEntries)
            {
                Console.WriteLine($"\nDatum: {entry.Date:yyy-MM-dd}");
                Console.WriteLine($"Text: {entry.Text}");
            }
        }

        static void SearchEntry()
        {
            Console.Write("Ange ett datum att söka efter (yyyy-mm-dd: ");
            string dateInput = Console.ReadLine();

            if (!DateTime.TryParse(dateInput,out DateTime date))
            {
                Console.WriteLine("Ogiltigt datumformat. Försök igen.");
                return;
            }

            var foundEntries = diaryEntries.FindAll(e => e.Date.Date == date.Date);

            if (foundEntries.Count  == 0)
            {
                Console.WriteLine("Ingen anteckning hittades på det datumet");
                return;
            }

            foreach (var entry in foundEntries)
            {
                Console.WriteLine($"\nDatum: {entry.Date:yyyy-MM-dd}");
                Console.WriteLine($"Text: {entry.Text}");
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- Dagboksappen ---");
                Console.WriteLine("1. Skriv ny anteckning");
                Console.WriteLine("2. Lista alla anteckningar");
                Console.WriteLine("3. Sök anteckning på datum");
                Console.WriteLine("4. Spara till fil");
                Console.WriteLine("5. Läs från fil");
                Console.WriteLine("6. Avsluta");
                Console.WriteLine("Välj ett alternativ: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEntry();
                            break;
                        case "2":
                        ListEntries();
                        break;
                        case "3":
                        SearchEntry();
                        break;
                        case "4":
                        //TODO: Spara till fil
                        break;
                        case "5":
                        //TODO: Läs från fil
                        break;
                        case "6":
                        return; //avslutar programmet
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;

                }
            }
        }
    }
}
