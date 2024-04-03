using BytePacketSupport;
using Xunit.Abstractions;

namespace AppendTest_preview
{
    public class AppendUnitTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public AppendUnitTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void BuilderAppenTest()
        {
            var Header = new PacketBuilder ()
                        .@byte (0x02);
            var Body = new PacketBuilder ()
                        .@byte (0x03)
                        .@byte (0x04)
                        .@byte (0x04)
                        .@byte (0x04);
            var ret = Header.AppendPacketBuilder (Body)
                            .Build ();

            _testOutputHelper.WriteLine (ret.ToHexString ());
             Assert.True (ret.ToHexString () == "0203040404");
        }
    }
}
