using BytePacketSupport;
using Xunit.Abstractions;

namespace AppendTest
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        [Fact]
        public void Test()
        {
            var builder1 = new PacketBuilder (new PacketBuilderConfiguration()
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
    }
}