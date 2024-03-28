using BenchmarkDotNet.Attributes;
using BytePacketSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketBuilder_Benchmark_preview
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
