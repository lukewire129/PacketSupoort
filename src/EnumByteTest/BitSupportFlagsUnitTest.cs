using BytePacketSupport.Extentions;

namespace EnumByteTest
{
    [BitSupportFlags]
    public enum MACHINE
    {
        POWER,
        RIGHT,
        TOP,
        LIGHT,
        TEMP,
        RUN,
        SOUND,
        ETC
    }

    public class BitSupportFlagsUnitTest
    {
        [Fact]
        public void EnumToByteTest1()
        {
            var rest = MACHINEFlags.POWER | MACHINEFlags.RIGHT;

            // rest: POWER | RIGHT
        }
    }
}
