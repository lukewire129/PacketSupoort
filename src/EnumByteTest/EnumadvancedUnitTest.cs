using BytePacketSupport.Extentions;

namespace EnumByteTest
{
    public class EnumadvancedUnitTest
    {
        [Flags]
        public enum MACHINE : byte
        {
            NONE = 0,
            POWER = 1 << 0,
            RIGHT = 1 << 1,
            TOP = 1 << 2,
            LIGHT = 1 << 3,
            TEMP = 1 << 4,
            RUN = 1 << 5,
            SOUND = 1 << 6,
            ETC = 1 << 7,
        }

        [Fact]
        public void EnumToByteTest1()
        {
            var rest = MACHINE.POWER | MACHINE.TOP;

            var aa = rest.ToByte ();
            // Result : 0x05;
        }

        [Fact]
        public void EnumToByteTest2()
        {
            byte data = 0x05;

            var aa = data.ToEnum<MACHINE> ();
            // Expected result: MACHINE.POWER | MACHINE.TOP
            Assert.True (aa.HasFlag (MACHINE.POWER));
            Assert.True (aa.HasFlag (MACHINE.TOP));
            Assert.False (aa.HasFlag (MACHINE.RIGHT));
        }
    }
}
