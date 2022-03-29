using BenchmarkDotNet.Attributes;
// ReSharper disable UnusedVariable

namespace BenchmarkTests;

[MemoryDiagnoser]
[RankColumn]
public class PrimeBenchmark
{
    private const int End = 1000000;

    [Benchmark(Description = "Simple")]
    public void BruteForceJobPrimeParallelSumTest()
    {
        var result = SimpleJob.Prime.Sum(End);
    }

    [Benchmark(Description = "PSimple")]
    public void BruteForceJobPrimeSumTest()
    {
        var result = SimpleJob.Prime.ParallelSum(End);
    }

    //[Benchmark(Description = "LINQ")]
    //public void LinqJobPrimeSumTest()
    //{
    //    var result = LinqJob.Prime.Sum(End);
    //}

    [Benchmark(Description = "PLINQ")]
    public void LinqJobPrimePSumTest()
    {
        var result = LinqJob.Prime.PSum(End);
    }
}