class Program
{
    static void Main(string[] args)
    {
        // Kallar på Deluppgift1
        // Deluppgift1.Deluppgift1Func(5, 20);
        // Kallar på Deluppgift2
        Deluppgift2.Deluppgift2Func(10);
    }
}

//Klass för att lösa första deluppgiften
public class Deluppgift1
{
    public static void Deluppgift1Func(int number, int numberOfIterations)
    {
        numberOfIterations = Math.Abs(numberOfIterations);

        using var writer = new StreamWriter("deluppgift1.csv");
        List<string> resultStrings = new List<string>();
        var sw = new System.Diagnostics.Stopwatch();
        Random random = new Random(1);

        for (int i = 1; i < numberOfIterations; i++)
        {
            int[] input = new int[i * 100000];
            for (int j = 0; j < input.Length; j++)
            {
                input[j] = random.Next(1, 20);
            }
            //TODO: Borde vi lägga till chache clear?

            //Kör varje arraysize 10 gånger för att minska "noise"
            for (int r = 0; r < 10; r++)
            {
                sw.Start();
                int count = Deluppgift1Algoritm(input, number);
                sw.Stop();

                Console.WriteLine(count);
                Console.WriteLine(sw.Elapsed);
                resultStrings.Add($"{input.Length},{sw.Elapsed}");
                sw.Reset();
            }
        }
        writer.WriteLine(string.Join("\n", resultStrings));
        writer.Close();
    }

    public static int Deluppgift1Algoritm(int[] input, int number)
    {
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
    public static void Deluppgift2Func(int numberOfIterations)
    {
        numberOfIterations = Math.Abs(numberOfIterations);

        using var writer = new StreamWriter("deluppgift2.csv");
        List<string> resultStrings = new List<string>();
        Random random = new Random(1);

        for (int i = 1; i < numberOfIterations; i++)
        {
            Console.WriteLine($"Iteration: {i}");
            int[] input = new int[i * i * 1000];
            for (int j = 0; j < input.Length; j++)
            {
                input[j] = random.Next(1, 20);
            }
            Console.WriteLine(string.Join(",", input[..3].Concat(input[^3..])));

            //TODO: Borde vi lägga till chache clear?

            //Kör varje arraysize 10 gånger för att minska "noise"
            for (int r = 0; r < 10; r++)
            {
                resultStrings.Add(BenchmarkAlgorithm(input, ReverseA));
                resultStrings.Add(BenchmarkAlgorithm(input, ReverseB));
            }
        }
        writer.WriteLine(string.Join("\n", resultStrings));
        writer.Close();
    }

    static string BenchmarkAlgorithm(int[] input, Func<int[], int, int[]> algorithm)
    {
        var sw = new System.Diagnostics.Stopwatch();
        var clone = (int[])input.Clone();
        sw.Start();
        var result = algorithm(clone, input.Length);
        sw.Stop();

        Console.WriteLine(string.Join(",", result[..3].Concat(result[^3..])));
        Console.WriteLine($"{algorithm.Method.Name}: {sw.Elapsed}");

        return ($"{algorithm.Method.Name},{input.Length},{sw.Elapsed}");
    }

    //Algoritmen som vi fick från Deluppgiften
    public static int[] ReverseA(int[] arr, int n)
    {
        int i = 1; //O(1)

        while (i < n) //O(n)
        {
            var nextValue = arr[i]; //O(1)
            int j = i; //O(1)

            while (j > 0) //O(n)
            {
                arr[j] = arr[j - 1]; //O(1)
                j--; //O(1)
            }

            arr[0] = nextValue; //O(1)
            i++; //O(1)
        }
        return arr; //O(1)
    }

    //Algoritmen som vi implementerade
    public static int[] ReverseB(int[] arr, int n)
    {
        int i = 0; //O(1)
        while (i < n) //O(n)
        {
            var nextValue = arr[i]; //O(1)
            arr[i] = arr[n - 1]; //O(1)
            arr[n - 1] = nextValue; //O(1)
            i++; //O(1)
            n--; //O(1)
        }
        return arr; //O(1)
    }
}
