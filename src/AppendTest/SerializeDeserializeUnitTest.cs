using BytePacketSupport;
using BytePacketSupport.Attibutes;
using BytePacketSupport.Enums;

namespace AppendTest
{
    public class SerializeDeserializeUnitTest
    {
        public class Test3Packet
        {
            [Endian (Endian.BIG)]
            public int Value;
            [Endian (Endian.LITTLE)]
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
    }
}
