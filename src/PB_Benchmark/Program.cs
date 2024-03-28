using BenchmarkDotNet.Running;

namespace PB_Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarks> ();
        }
    }
}