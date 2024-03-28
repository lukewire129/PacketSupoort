using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BytePacketSupport;
using System;

namespace PB_Benchmark
{
    [MemoryDiagnoser]
    public class Benchmarks
    {
        public void Scenario1()
        {
            var caseBinary = new PacketBuilder ()
                         .@byte (1)
                         .@short (1)
                         .@ushort (1)
                         .@int (1)
                         .@uint (1)
                         .@long (1)
                         .@ulong (1)
                         .@byte (1)
                         .@short (1)
                         .@ushort (1)
                         .@int (1)
                         .@uint (1)
                         .@long (1)
                         .@ulong (1);

        }

        [Benchmark]
        public void Scenario2()
        {
            var caseString = new PacketBuilder ()
                .@string (new string ('A', 65));
        }
    }
}
