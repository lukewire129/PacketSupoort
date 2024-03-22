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


            byte[] aaa = test.Append(new Test1Packet ()
            {
                Value = 1,
                Value1 = "abc",
                Value2 = "ABC"
            });

            Debug.WriteLine(aaa.Display ());
        }
    }
}