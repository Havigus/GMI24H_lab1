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

public class Deluppgift1
{
    public static void Deluppgift1Func(int[] input, int number, int numberOfItterations)
    {
        using var writer = new StreamWriter("deluppgift1.csv", true);
        for (int i = 0; i < numberOfItterations; i++)
        {
            DateTime start = DateTime.Now;
            int count = Deluppgift1Alg(input, number);
            DateTime end = DateTime.Now;
            Console.WriteLine(count);
            Console.WriteLine(end - start);
            writer.WriteLine($"{input.Length};{end - start}");

        }
    }

    static int Deluppgift1Alg(int[] input, int number)
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



