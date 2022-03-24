using BenchmarkDotNet.Running;
using BenchmarkTests;

BenchmarkRunner.Run<PrimeBenchmark>();

Console.ReadKey();
