using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Jobs;

BenchmarkRunner.Run<Deluppgift1Benchmarks>();
BenchmarkRunner.Run<Deluppgift2Benchmarks>();

[MemoryDiagnoser]
public class Deluppgift1Benchmarks
{
    [Params(100_000, 500_000, 1_000_000, 1_500_000, 1_900_000)]
    public int ArraySize;

    private int[] _input = null!;
    private const int Number = 5;

    [GlobalSetup]
    public void Setup()
    {
        var rng = new Random(1);
        _input = new int[ArraySize];
        for (int i = 0; i < _input.Length; i++)
            _input[i] = rng.Next(1, 20);
    }

    [Benchmark]
    public int Deluppgift1Algorithm()
    {
        int seen = 0;
        foreach (var num in _input)
        {
            if (num == Number) seen++;
        }
        return seen;
    }
}

[MemoryDiagnoser]
public class Deluppgift2Benchmarks
{
    [Params(10_000, 40_000, 90_000, 160_000, 250_000, 360_000, 490_000, 640_000, 810_000)]
    public int ArraySize;

    private int[] _original = null!;
    private int[] _working = null!;

    [GlobalSetup]
    public void Setup()
    {
        var rng = new Random(1);
        _original = new int[ArraySize];
        for (int i = 0; i < _original.Length; i++)
            _original[i] = rng.Next(1, 20);

        _working = new int[ArraySize];
    }

    // gives a fresh unsorted copy
    [IterationSetup]
    public void IterationSetup()
    {
        Array.Copy(_original, _working, _original.Length);
    }

    [Benchmark(Baseline = true)]
    public int[] ReverseA()
    {
        int i = 1;
        int n = _working.Length;
        while (i < n)
        {
            var nextValue = _working[i];
            int j = i;
            while (j > 0)
            {
                _working[j] = _working[j - 1];
                j--;
            }
            _working[0] = nextValue;
            i++;
        }
        return _working;
    }

    [Benchmark]
    public int[] ReverseB()
    {
        int lo = 0;
        int hi = _working.Length - 1;
        while (lo < hi)
        {
            int temp = _working[hi];
            _working[hi] = _working[lo];
            _working[lo] = temp;
            lo++;
            hi--;
        }
        return _working;
    }

    [Benchmark]
    public void BuiltInReverse()
    {
        Array.Reverse(_working);
    }
}
