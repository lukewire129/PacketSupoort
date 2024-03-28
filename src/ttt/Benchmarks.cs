using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BytePacketSupport;
using System;

namespace ttt
{
    public class Benchmarks
    {
        [Benchmark (Baseline = true)]
        public void Scenario1()
        {
            var builder1 = new PacketBuilder ()
                        .AppendInt32 (1)
                        .AppendUInt32 (2)
                        .AppendInt16 (3)
                        .AppendUInt16 (4)
                        .AppendInt64 (5)
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
