using BytePacketSupport;
using Xunit.Abstractions;

namespace AppendTest
{
    public class BasicUnitTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public BasicUnitTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        [Fact]
        public void Test()
        {
            var builder1 = new PacketBuilder (new PacketBuilderConfiguration()
            {
                DefaultEndian = BytePacketSupport.Enums.Endian.LITTLE
            })
               .AppendInt16 (1)
               .AppendInt32 (2)
               .AppendInt64 (3)
               .AppendUInt16 (4)
               .AppendUInt32 (5)
               .AppendUInt64 (6)
               .Build ();

            _testOutputHelper.WriteLine (builder1.ToHexString ());
        }

        [Fact]
        public void Test1()
        {
            var builder1 = new PacketBuilder (new PacketBuilderConfiguration ()
            {
                DefaultEndian = BytePacketSupport.Enums.Endian.BIG
            })
               .AppendInt16 (1)
               .AppendInt32 (2)
               .AppendInt64 (3)
               .AppendUInt16 (4)
               .AppendUInt32 (5)
               .AppendUInt64 (6)
               .Build ();

            _testOutputHelper.WriteLine (builder1.ToHexString ());
        }

        [Fact]
        public void Test2()
        {
            var builder1 = new PacketBuilder ()
                .BeginSection ("packet")
               .AppendInt16 (1)
               .AppendInt32 (2)
               .AppendInt64 (3)
               .AppendUInt16 (4)
               .AppendUInt32 (5)
               .AppendUInt64 (6)
               .EndSection ("packet")
               .Compute ("packet", Mythosia.Integrity.CRC.CRC16Type.Classic)
               .Build ();

            _testOutputHelper.WriteLine (builder1.ToHexString ());
        }

        [Fact]
        public void Test3()
        {
            var builder1 = new PacketBuilder (new PacketBuilderConfiguration ()
            {
                DefaultEndian = BytePacketSupport.Enums.Endian.BIG
            })
               .BeginSection ("packet")
               .AppendInt16 (1)
               .AppendInt32 (2)
               .AppendInt64 (3)
               .AppendUInt16 (4)
               .AppendUInt32 (5)
               .AppendUInt64 (6)
               .EndSection ("packet")
               .Compute ("packet", Mythosia.Integrity.CRC.CRC16Type.Classic)
                .Build ();

            _testOutputHelper.WriteLine (builder1.ToHexString ());
        }
    }
}