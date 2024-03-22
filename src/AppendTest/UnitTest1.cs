using BytePacketSupport;
using System.Diagnostics;
namespace AppendTest
{
    public class UnitTest1
    {
        public class Test1Packet
        {
            public int Value;
            public string Value1;
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
    }
}