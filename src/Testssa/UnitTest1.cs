using PacketSupport.Generator.Attributes;
namespace Testssa
{
    public class UnitTest1
    {
        [Packet]
        public partial class abc
        {
            public string ab1c;
        }
        [Fact]
        public void Test1()
        {
            abc aaa = new ();
            aaa.Serialize (new byte { 0x00 });
        }
    }
}