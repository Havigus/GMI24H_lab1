class Program
{
    static void Main(string[] args)
    {
        Random random = new Random(1);
        for (int i = 1; i < 20; i++)
        {
            int[] input = new int[i * 100000];
            for (int j = 0; j < input.Length; j++)
            {
                input[j] = random.Next(1, 20);
            }
            //Calls Task1
            Deluppgift1.Deluppgift1Func(input, 5, 20);
        }
    }
}

//Klass för att lösa första deluppgiften
public class Deluppgift1
{
    public static void Deluppgift1Func(int[] input, int number, int numberOfItterations)
    {
        using var writer = new StreamWriter("deluppgift1.csv", true);
        for (int i = 0; i < numberOfItterations; i++)
        {
            var sw = new System.Diagnostics.Stopwatch();
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
