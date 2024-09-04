using BytePacketSupport;
using BytePacketSupport.Enums;
using Xunit.Abstractions;

namespace AppendTest
{
    public class EndianUnitTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public EndianUnitTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void EndianTest()
        {
            short test = 0x0102;
            byte[] abclittle = new byte[] { 0x01, 0x02 };
            byte[] abcBig = new byte[] { 0x01, 0x02 };

            abclittle = abclittle
                            .@short (test);
            abcBig = abcBig
                            .@short (test, Endian.BIG);

            _testOutputHelper.WriteLine ("display1 {0}", abclittle.ToHexString ());
            _testOutputHelper.WriteLine ("display2 {0}", abcBig.ToHexString ());

            Assert.True (abclittle.ToHexString () == "01020201");
            Assert.True (abcBig.ToHexString () == "01020102");
        }

        [Fact]
        public void TestShort()
        {
            var test1 = new PacketBuilder (new PacketBuilderConfiguration ()
            {
                DefaultEndian = BytePacketSupport.Enums.Endian.BIG
            }).@short (0x1234)
                          .Build ();
            var test2 = new PacketBuilder (new PacketBuilderConfiguration ()
            {
                DefaultEndian = BytePacketSupport.Enums.Endian.LITTLE
            }).@short (0x1234)
                          .Build ();
            var test3 = new PacketBuilder (new PacketBuilderConfiguration ()
            {
                DefaultEndian = BytePacketSupport.Enums.Endian.BIGBYTESWAP
            }).@short (0x1234)
                          .Build ();
            var test4 = new PacketBuilder (new PacketBuilderConfiguration ()
            {
                DefaultEndian = BytePacketSupport.Enums.Endian.LITTLEBYTESWAP
            }).@short (0x1234)
                          .Build ();

            _testOutputHelper.WriteLine (test1.ToHexString ());
            _testOutputHelper.WriteLine (test2.ToHexString ());
            _testOutputHelper.WriteLine (test3.ToHexString ());
            _testOutputHelper.WriteLine (test4.ToHexString ());


            Assert.True (test1.ToHexString () == "1234");
            Assert.True (test2.ToHexString () == "3412");
            Assert.True (test3.ToHexString () == "3412");
            Assert.True (test4.ToHexString () == "1234");
        }

        [Fact]
        public void Testint()
        {
            var test1 = new PacketBuilder (new PacketBuilderConfiguration ()
            {
                DefaultEndian = BytePacketSupport.Enums.Endian.BIG
            }).@int (0x12345678)
                          .Build ();
            var test2 = new PacketBuilder (new PacketBuilderConfiguration ()
            {
                DefaultEndian = BytePacketSupport.Enums.Endian.LITTLE
            }).@int (0x12345678)
                          .Build ();
            var test3 = new PacketBuilder (new PacketBuilderConfiguration ()
            {
                DefaultEndian = BytePacketSupport.Enums.Endian.BIGBYTESWAP
            }).@int (0x12345678)
                          .Build ();
            var test4 = new PacketBuilder (new PacketBuilderConfiguration ()
            {
                DefaultEndian = BytePacketSupport.Enums.Endian.LITTLEBYTESWAP
            }).@int (0x12345678)
                          .Build ();

            _testOutputHelper.WriteLine (test1.ToHexString ());
            _testOutputHelper.WriteLine (test2.ToHexString ());
            _testOutputHelper.WriteLine (test3.ToHexString ());
            _testOutputHelper.WriteLine (test4.ToHexString ());

            Assert.True (test1.ToHexString () == "12345678");
            Assert.True (test2.ToHexString () == "78563412");
            Assert.True (test3.ToHexString () == "34127856");
            Assert.True (test4.ToHexString () == "56781234");
        }

        [Fact]
        public void Testlong()
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

            _testOutputHelper.WriteLine (test1.ToHexString ());
            _testOutputHelper.WriteLine (test2.ToHexString ());
            _testOutputHelper.WriteLine (test3.ToHexString ());
            _testOutputHelper.WriteLine (test4.ToHexString ());

            Assert.True (test1.ToHexString () == "123456789ABCDEF0");
            Assert.True (test2.ToHexString () == "F0DEBC9A78563412");
            Assert.True (test3.ToHexString () == "34127856BC9AF0DE");
            Assert.True (test4.ToHexString () == "DEF09ABC56781234");
        }

        [Fact]
        public void ShortDataTest()
        {
            Random random = new Random ();
            ushort test = (ushort)random.Next (0, 65535);
            Console.WriteLine (test);
            byte[] b = BitConverter.GetBytes (test);

            var test2 = new PacketBuilder (new PacketBuilderConfiguration ()
            {
                DefaultEndian = BytePacketSupport.Enums.Endian.LITTLE
            }).@ushort (test);

            var array = b.ToHexString ();
            var builderArray = test2.Build ().ToHexString ();
            Console.ReadKey ();
        }
    }
}
