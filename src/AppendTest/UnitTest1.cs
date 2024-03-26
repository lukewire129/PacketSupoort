using BytePacketSupport;
using BytePacketSupport.Attibutes;
using System.Diagnostics;
namespace AppendTest
{
    public class UnitTest1
    {
        public class Test1Packet
        {
            public int Value;
            [ByteSize (3)]
            public string Value1;
            [ByteSize (3)]
            public string Value2;
        }

        [Fact]
        public void Test1()
        {
            byte[] test = { 0x01, 0x02 };


            byte[] aaa = test.Append (new Test1Packet ()
            {
                Value = 1,
                Value1 = "abc",
                Value2 = "ABC"
            });

            Trace.WriteLine (aaa.Display ());
        }

        int count = 50000;
        byte[] Append(byte[] bs, byte AppenByte)
        {
            byte[] ToTalBytes = new byte[bs.Length + 1];

            Buffer.BlockCopy (bs, 0, ToTalBytes, 0, bs.Length);
            ToTalBytes[bs.Length] = AppenByte;

            return ToTalBytes;
        }
        [Fact]
        public void SpeedTest_byte1()
        {
            byte[] bytes = { 0x01 };
            for (int i = 0; i < count; i++)
            {
                bytes = Append (bytes, BitConverter.GetBytes (i)[0]).ToArray();
            }
        }

        [Fact]
        public void SpeedTest_byte2()
        {
            byte[] bytes = { 0x01 };
            for (int i = 0; i < count; i++)
            {
                bytes = bytes.Append<Byte> (BitConverter.GetBytes (i)[0]).ToArray ();
            }
        }
        [Fact]
        public void SpeedTest_byteAray1()
        {
            byte[] bytes = { 0x01 };
            byte[] dest = { 0x02 };
            for (int i = 0; i < count; i++)
            {
                bytes = bytes.Append<Byte> (BitConverter.GetBytes (i)[0]).ToArray ();
                dest = dest.Append<Byte> (BitConverter.GetBytes (i)[0]).ToArray ();
            }


            dest.Append (bytes);
        }

        [Fact]
        public void SpeedTest_byteAray2()
        {
            byte[] bytes = { 0x01 };
            byte[] dest = { 0x02 };
            for (int i = 0; i < count; i++)
            {
                bytes = bytes.Append<Byte> (BitConverter.GetBytes (i)[0]).ToArray ();
                dest = dest.Append<Byte> (BitConverter.GetBytes (i)[0]).ToArray ();
            }

            for (int j= 0; j< bytes.Count(); j++)
            {
                bytes = dest.Append<Byte> (bytes[j]).ToArray ();
            }
        }

        public class Test2Packet
        {
            public int Value;
            [ByteSize (3)]
            public string Value1;
            [ByteSize (3)]
            public string Value2;
            [ByteSize(4)]
            public byte[] abc;            
            public byte[] efg = new byte[5];
            public List<byte> qqq= new List<byte>(5);
            public List<byte> qqq1= new List<byte>();
        }

        [Fact]
        public void TestDeserializeObject()
        {
            var test = new byte[] { 0x01, 0x00, 0x00, 0x00, 0x61, 0x62,0x63,0x41,0x42,0x43, 0x01, 0x00, 0x00, 0x00, 0x61, 0x62, 0x63, 0x41, 0x42, 0x43, 0x01, 0x00, 0x00, 0x00, 0x61, 0x62, 0x63, 0x41, 0x42, 0x43 };
            var aaa = PacketParse.DeserializeObject<Test2Packet> (test);

            var abc  = PacketParse.Serialization (aaa);
        }

        [Fact]
        public void PacketBuilderConfig()
        {
            short test = 0x0102;
            short testAdd = 0x0304;

            var littlEndianType = new PacketBuilder (); 

            var bigEndianType = new PacketBuilder (new PacketBuilderConfiguration ()
            {
                DefaultEndian = BytePacketSupport.Enums.Endian.BIG
            });

            var display1 = littlEndianType.Append (test)
                                          .Append (testAdd)
                                          .Build ();

            var display2 = bigEndianType.Append (test)
                                        .Append (testAdd)
                                        .Build ();

            Console.WriteLine ("display1 {0}", display1.Display ());
            Console.WriteLine ("display2 {0}", display2.Display ());
        }

        [Fact]
        public void PacketBuilderConfig2()
        {
            int test = 1;
            int testAdd = 2;

            var littlEndianType = new PacketBuilder ();

            var bigEndianType = new PacketBuilder (new PacketBuilderConfiguration ()
            {
                DefaultEndian = BytePacketSupport.Enums.Endian.BIG
            });

            var display1 = littlEndianType.Append (test)
                                          .Append (testAdd)
                                          .Build ();

            var display2 = bigEndianType.Append (test)
                                        .Append (testAdd)
                                        .Build ();

            Console.WriteLine ("display1 {0}", display1.Display ());
            Console.WriteLine ("display2 {0}", display2.Display ());
        }

        [Fact]
        public void EndianTest()
        {
            short test = 0x0102;
            byte[] abclittle = new byte[] { 0x01, 0x02 };
            byte[] abcBig = new byte[] { 0x01, 0x02 };

            abclittle = abclittle.Append (test);
            abcBig = abcBig.Append (test, false);

            Console.WriteLine ("display1 {0}", abclittle.Display ());
            Console.WriteLine ("display2 {0}", abcBig.Display ());
        }
    }
}