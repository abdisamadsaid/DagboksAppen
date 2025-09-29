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

        static void SaveToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("diary.txt"))
                {
                    foreach (var entry in diaryEntries)
                    {
                        writer.WriteLine($"{entry.Date:yyyy-MM-dd}|{entry.Text}");
                    }
                }
                Console.WriteLine("Anteckningar sparade till diary.txt");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid sparande: {ex.Message}");
            }
        }

        static void LoadFromFile()
        {
            try
            {
                if (!File.Exists("diary.txt"))
                {
                    Console.WriteLine("Filen finns inte");
                    return;
                }

                diaryEntries.Clear();

                using (StreamReader reader = new StreamReader ("diary.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length != 2)
                            continue;

                        if (!DateTime.TryParse(parts[0], out DateTime date))
                            continue;

                        diaryEntries.Add(new DiaryEntry
                        {
                            Date = date,
                            Text = parts[1]
                        });
                    }
                }
                Console.WriteLine("Anteckningar lästa från diary.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid läsning: {ex.Message}");
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
                        SaveToFile();
                        break;
                        case "5":
                        LoadFromFile();
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
