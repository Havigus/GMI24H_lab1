class Program
{
    static void Main(string[] args)
    {
        // Kallar på Deluppgift1
        Deluppgift1.RunAndSave(5, 20);
        // Kallar på Deluppgift2
        Deluppgift2.RunAndSave(10);
    }
}

//Klass för att lösa första deluppgiften
public class Deluppgift1
{
    /// <summary>
    /// Kör algoritmen för att räkna förekomster av ett tal i en array, och sparar resultatet i en CSV fil
    /// </summary>
    /// <param name="number">Tal som ska räknas</param>
    /// <param name="numberOfIterations">Antal iterationer</param>
    public static void RunAndSave(int number, int numberOfIterations)
    {
        // Sätt antal iterationer till ett positivt tal, så vi inte tar in negativa tal
        numberOfIterations = Math.Abs(numberOfIterations);

        // Skapa en StreamWriter för att skriva resultatet till CSV filen
        using var writer = new StreamWriter("deluppgift1.csv");

        List<string> resultStrings = new List<string>();
        var sw = new System.Diagnostics.Stopwatch();
        // Sätter seed till 1 för att få samma random numbers varje gång
        Random random = new Random(1);

        // Kör algoritmen numberOfIterations - 1 gånger
        for (int i = 1; i < numberOfIterations; i++)
        {
            // Skapa en array av storleken i * 100000
            int[] input = new int[i * 100000];

            // Fyll arrayen med random numbers mellan 1 och 19 (20 - 1)
            for (int j = 0; j < input.Length; j++)
            {
                input[j] = random.Next(1, 20);
            }

            //Kör varje arraysize 10 gånger
            for (int r = 0; r < 10; r++)
            {
                // Starta stopwatchen, kör algoritmen, stoppa stopwatchen
                sw.Start();
                int count = GetOccurences(input, number);
                sw.Stop();

                Console.WriteLine(count);
                Console.WriteLine(sw.Elapsed);

                // Spara resultet i resultStrings listan i formatet "array size, elapsed time"
                resultStrings.Add($"{input.Length},{sw.Elapsed}");
                sw.Reset();
            }
        }

        // Spara alla resultat i CSV filen
        writer.WriteLine(string.Join("\n", resultStrings));
        writer.Close();
    }

    /// <summary>
    /// Algoritm för att räkna förekomster av ett tal i en array
    /// </summary>
    /// <param name="input">Array som ska genomsökas</param>
    /// <param name="number">Tal att leta efter</param>
    /// <returns></returns>
    public static int GetOccurences(int[] input, int number)
    {
        // Räkna förekomster av number i input arrayen
        // Detta görs genom att iterera över arrayen och öka en räknare varje gång number hittas.
        int seen = 0; //O(1)

        foreach (var num in input) //O(n)
        {
            if (num == number) //O(1)
            {
                seen++; //O(1)
            }
        }

        return seen; //O(1)
    }
}

//Klass för att lösa Deluppgift2 alternativ 2
public class Deluppgift2
{
    /// <summary>
    /// Kör algoritmerna för att vända en array, och sparar resultatet i en CSV fil
    /// </summary>
    /// <param name="numberOfIterations">Antal iterationer som ska köras</param>
    public static void RunAndSave(int numberOfIterations)
    {
        // Sätt antal iterationer till ett positivt tal, så vi inte tar in negativa tal
        numberOfIterations = Math.Abs(numberOfIterations);

        // Skapa en StreamWriter för att skriva resultatet till CSV filen
        using var writer = new StreamWriter("deluppgift2.csv");
        List<string> resultStrings = new List<string>();
        // Sätter seed till 1 för att få samma random numbers varje gång
        Random random = new Random(1);

        // Loopa antal iterationer - 1 gånger
        for (int i = 1; i < numberOfIterations; i++)
        {
            Console.WriteLine($"Iteration: {i}");

            // Skapa en array av storleken i * i * 10000, vilket gör att arrayen växer med n^2 * 1000
            int[] input = new int[i * i * 10000];

            // Loopa igenom arrayen och fyll den med random numbers mellan 1 och 19 (20 - 1)
            for (int j = 0; j < input.Length; j++)
            {
                input[j] = random.Next(1, 20);
            }
            Console.WriteLine(string.Join(",", input[..3].Concat(input[^3..])));

            //Kör varje arraysize 10 gånger för
            for (int r = 0; r < 10; r++)
            {
                // Kör algoritmerna och spara resultatet i resultStrings listan
                resultStrings.Add(BenchmarkAlgorithm(input, ReverseA));
                resultStrings.Add(BenchmarkAlgorithm(input, ReverseB));
            }
        }

        // Spara alla resultat i CSV filen
        writer.WriteLine(string.Join("\n", resultStrings));
        writer.Close();
    }

    /// <summary>
    /// Kör en algoritm och mäter tidskomplexiteten, och returnerar resultatet i formatet "algorithm name, array size, elapsed time"
    /// </summary>
    /// <param name="input">Array som ska vändas</param>
    /// <param name="algorithm">Funktions algoritm att köra</param>
    /// <returns></returns>
    static string BenchmarkAlgorithm(int[] input, Func<int[], int, int[]> algorithm)
    {
        var sw = new System.Diagnostics.Stopwatch();

        // Klona input arrayen så originalet inte ändras
        var clone = (int[])input.Clone();

        // Starta stopwatchen, kör algoritmen, stoppa stopwatchen
        sw.Start();
        var result = algorithm(clone, input.Length);
        sw.Stop();

        Console.WriteLine(string.Join(",", result[..3].Concat(result[^3..])));
        Console.WriteLine($"{algorithm.Method.Name}: {sw.Elapsed}");

        return ($"{algorithm.Method.Name},{input.Length},{sw.Elapsed}");
    }

    /// <summary>
    /// Algoritmen ReverseA som vi fick i uppgiften, som vänder en array genom att flytta varje element till början av arrayen
    /// </summary>
    /// <param name="arr">Array som ska vändas</param>
    /// <param name="n">Antal element i arrayen</param>
    /// <returns>Omvänd array</returns>
    public static int[] ReverseA(int[] arr, int n)
    {
        int i = 1; //O(1)

        // Loopa igenom arrayen
        while (i < n) //O(n)
        {
            // Hämta nästa värde
            var nextValue = arr[i]; //O(1)
            // Spara indexet vi är på
            int j = i; //O(1)

            // Loopa så länge j är större än 0
            while (j > 0) //O(n)
            {
                // Flytta elementet på index j - 1 till index j
                arr[j] = arr[j - 1]; //O(1)
                // Minska j
                j--; //O(1)
            }

            // Sätt första elementet i arrayen till nästa värde
            arr[0] = nextValue; //O(1)
            i++; //O(1)
        }

        // Returnera den omvända arrayen
        return arr; //O(1)
    }

    /// <summary>
    /// Algoritmen ReverseB som vi implementerade, som vänder en array genom att byta plats på element i början och slutet
    /// </summary>
    /// <param name="arr">Array som ska vändas</param>
    /// <param name="n">Antal element i arrayen</param>
    /// <returns>Omvänd array</returns>
    public static int[] ReverseB(int[] arr, int n)
    {
        // Börja på index 0
        int i = 0; //O(1)

        // Loopa igenom arrayen tills i är mindre än n
        while (i < n) //O(n)
        {
            // Hämta nästa värde
            var nextValue = arr[i]; //O(1)
            // Sätt elementet på index i till elementet på index n - 1
            arr[i] = arr[n - 1]; //O(1)
            // Sätt elementet på index n - 1 till nästa värde
            arr[n - 1] = nextValue; //O(1)
            i++; //O(1)
            n--; //O(1)
        }

        // Returnera den omvända arrayen
        return arr; //O(1)
    }
}
