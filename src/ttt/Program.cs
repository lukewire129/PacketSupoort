using BenchmarkDotNet.Running;

namespace ttt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarks> ();
        }
    }
}