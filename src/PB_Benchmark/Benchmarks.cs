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

        [Benchmark]
        public void Scenario3()
        {
            var test1 = new PacketBuilder (new PacketBuilderConfiguration ()
            {
                DefaultEndian = BytePacketSupport.Enums.Endian.BIG
            }).@long (0x123456789ABCDEF0)
                            .Build ();
            var test2 = new PacketBuilder (new PacketBuilderConfiguration ()
            {
                DefaultEndian = BytePacketSupport.Enums.Endian.LITTLE
            }).@long (0x123456789ABCDEF0)
                          .Build ();
            var test3 = new PacketBuilder (new PacketBuilderConfiguration ()
            {
                DefaultEndian = BytePacketSupport.Enums.Endian.BIGBYTESWAP
            }).@long (0x123456789ABCDEF0)
                          .Build ();
            var test4 = new PacketBuilder (new PacketBuilderConfiguration ()
            {
                DefaultEndian = BytePacketSupport.Enums.Endian.LITTLEBYTESWAP
            }).@long (0x123456789ABCDEF0)
                          .Build ();
        }
    }
}
