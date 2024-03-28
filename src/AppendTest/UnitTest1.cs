using BytePacketSupport;
using BytePacketSupport.Attibutes;
using BytePacketSupport.Enums;
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


            byte[] aaa = test.
                            @Class(new Test1Packet ()
                                    {
                                        Value = 1,
                                        Value1 = "abc",
                                        Value2 = "ABC"
                                    });
            Trace.WriteLine (aaa.ToHexString ());
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


            dest.@bytes (bytes);
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

            var display1 = littlEndianType
                                .@short (test)
                                .@short (testAdd)
                                .Build ();

            var display2 = bigEndianType
                                .@short (test)
                                .@short (testAdd)
                                .Build ();

            Console.WriteLine ("display1 {0}", display1.ToHexString ());
            Console.WriteLine ("display2 {0}", display2.ToHexString ());
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

            var display1 = littlEndianType
                                .@int (test)
                                .@int (testAdd)
                                .Build ();

            var display2 = bigEndianType
                                .@int (test)
                                .@int (testAdd)
                                .Build ();

            Console.WriteLine ("display1 {0}", display1.ToHexString ());
            Console.WriteLine ("display2 {0}", display2.ToHexString ());
        }

        [Fact]
        public void bytearraybytelisttest()
        {
            short test = 0x0102;
            byte[] abclittle = new byte[] { 0x01, 0x02 };
            byte[] abcBig1 = new byte[] { 0x01, 0x02 };
            List<byte> abcBig2 = new List<byte>() { 0x01, 0x02 };

            abclittle = abclittle
                            .@bytes (abcBig1)
                            .@bytes (abcBig2);

            Console.WriteLine ("display1 {0}", abclittle.ToHexString ());
        }

        [Fact]
        public void aafas()
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

            Console.WriteLine (builder1.ToHexString ());
        }
    }
}