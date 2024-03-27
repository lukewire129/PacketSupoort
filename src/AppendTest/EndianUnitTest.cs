using BytePacketSupport;
using BytePacketSupport.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
    }
}
