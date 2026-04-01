class Program
{
    static void Main(string[] args)
    {
        //Kallar på Deluppgift1
        // Deluppgift1.Deluppgift1Func(5, 20);
        // Kallar på Deluppgift2
        Deluppgift2.Deluppgift2Func(20);
    }
}

//Klass för att lösa första deluppgiften
class Deluppgift1
{
    public static void Deluppgift1Func(int number, int numberOfIterations)
    {
        using var writer = new StreamWriter("deluppgift1.csv");
        var sw = new System.Diagnostics.Stopwatch();
        Random random = new Random(1);

        for (int i = 1; i < numberOfIterations; i++)
        {
            int[] input = new int[i * 100000];
            for (int j = 0; j < input.Length; j++)
            {
                input[j] = random.Next(1, 20);
            }

            sw.Start();
            int count = Deluppgift1Algoritm(input, number);
            sw.Stop();

            Console.WriteLine(count);
            Console.WriteLine(sw.Elapsed);
            writer.WriteLine($"{input.Length},{sw.Elapsed}");
            sw.Reset();
        }
    }

    static int Deluppgift1Algoritm(int[] input, int number)
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
class Deluppgift2
{
    public static void Deluppgift2Func(int numberOfIterations)
    {
        var sw = new System.Diagnostics.Stopwatch();
        using var writer = new StreamWriter("deluppgift2.csv");
        Random random = new Random(1);

        for (int i = 1; i < numberOfIterations; i++)
        {
            int[] input = new int[i * 1000];
            for (int j = 0; j < input.Length; j++)
            {
                input[j] = random.Next(1, 20);
            }
            Console.WriteLine(string.Join(",", input[..3].Concat(input[^3..])));

            //ReverseA Algoritmen
            var inputCloneA = (int[])input.Clone();
            sw.Start();
            var reversedArrA = ReverseA(inputCloneA, input.Length);
            sw.Stop();
            Console.WriteLine(string.Join(",", reversedArrA[..3].Concat(reversedArrA[^3..])));
            Console.WriteLine($"ReverseA: {sw.Elapsed}");
            writer.WriteLine($"ReverseA,{input.Length},{sw.Elapsed}");
            sw.Reset();

            //ReverseB Algoritmen
            var inputCloneB = (int[])input.Clone();
            sw.Start();
            var reversedArrB = ReverseB(inputCloneB, input.Length);
            sw.Stop();
            Console.WriteLine(string.Join(",", reversedArrB[..3].Concat(reversedArrB[^3..])));
            Console.WriteLine($"ReverseB: {sw.Elapsed}");
            writer.WriteLine($"ReverseB,{input.Length},{sw.Elapsed}");
            sw.Reset();

            //ReverseXor Algoritmen
            var inputCloneXor = (int[])input.Clone();
            sw.Start();
            var reversedArrXor = ReverseXor(inputCloneXor, input.Length);
            sw.Stop();
            Console.WriteLine(string.Join(",", reversedArrXor[..3].Concat(reversedArrXor[^3..])));
            Console.WriteLine($"ReverseXor: {sw.Elapsed}");
            writer.WriteLine($"ReverseXor,{input.Length},{sw.Elapsed}");
            sw.Reset();
        }
    }

    //Algoritmen som vi fick från Deluppgiften
    static int[] ReverseA(int[] arr, int n)
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
    static int[] ReverseB(int[] arr, int n)
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

    //Xor swap bara för att se skillnaden mot tmp variable
    static int[] ReverseXor(int[] arr, int n)
    {
        int i = 0; //O(1)
        while (i < n) //O(n)
        {
            if (i != n - 1) //O(1)
            {
                arr[i] = arr[n - 1] ^ arr[i]; //O(1)
                arr[n - 1] = arr[n - 1] ^ arr[i]; //O(1)
                arr[i] = arr[n - 1] ^ arr[i]; //O(1)
            }
            i++; //O(1)
            n--; //O(1)
        }
        return arr; //O(1)
    }
}
