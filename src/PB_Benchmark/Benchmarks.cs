using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BytePacketSupport;
using System;

namespace PB_Benchmark
{
    public class Benchmarks
    {
        [Benchmark (Baseline = true)]
        public void Scenario1()
        {
            var builder1 = new PacketBuilder ()
               .AppendInt16 (1)
               .AppendInt32 (2)
               .AppendInt64 (3)
               .AppendUInt16 (4)
               .AppendUInt32 (5)
               .AppendUInt64 (6)
               .Build ();
        }

        [Benchmark]
        public void Scenario2()
        {
            // Implement your benchmark here
        }
    }
}
