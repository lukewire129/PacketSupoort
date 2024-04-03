using BytePacketSupport;
using BytePacketSupport.Attibutes;
using BytePacketSupport.Enums;

namespace AppendTest_preview
{
    public class SerializeDeserializeUnitTest
    {
        [Endian (Endian.BIG)]
        public class Test3Packet
        {
            public int Value;
            public int Value1;
            [ByteSize (3)]
            public string Value3;
        }


        [Fact]
        public void DeserializeEndianAttribute()
        {
            var test = new byte[] { 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x61, 0x62, 0x63 };
            var aaa = PacketParse.Deserialize<Test3Packet> (test);
        }
        [Fact]
        public void SerializeEndianAttribute()
        {
            var aaa = new Test3Packet ()
            {
                Value = 1,
                Value1 = 1,
                Value3 = "abc",
            };

            var abc = PacketParse.Serialize (aaa);
        }

        [Endian (Endian.LITTLE)]
        public class Test2Packet
        {
            public int Value;
            [ByteSize (3)]
            public string Value1;
            [ByteSize (3)]
            public string Value2;
            [ByteSize (4)]
            public byte[] abc;
            public byte[] efg = new byte[5];
            public List<byte> qqq = new List<byte> (5);
            public List<byte> qqq1 = new List<byte> ();
        }

        [Fact]
        public void TestDeserializeObject()
        {
            var test = new byte[] { 0x01, 0x00, 0x00, 0x00, 0x61, 0x62, 0x63, 0x41, 0x42, 0x43, 0x01, 0x00, 0x00, 0x00, 0x61, 0x62, 0x63, 0x41, 0x42, 0x43, 0x01, 0x00, 0x00, 0x00, 0x61, 0x62, 0x63, 0x41, 0x42, 0x43 };
            var aaa = PacketParse.Deserialize<Test2Packet> (test);

            var abc = PacketParse.Serialize (aaa);
        }
    }
}
