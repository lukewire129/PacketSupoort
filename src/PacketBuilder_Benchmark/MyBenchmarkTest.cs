using BenchmarkDotNet.Attributes;
using BytePacketSupport;

namespace PacketBuilder_Benchmark
{
    public class MyBenchmarkTest
    {
        [Benchmark]
        public string ConcatStringsUsingStringBuilder()
        {
            var builder1 = new PacketBuilder ()
                           .AppendInt32 (1)
                           .AppendUInt32 (2)
                           .AppendInt16 (3)
                           .AppendUInt16 (4)
                           .AppendInt64 (5)
                           .AppendUInt64 (6)
                           .Build ();

            return builder1.ToHexString ();
        }
    }
}
