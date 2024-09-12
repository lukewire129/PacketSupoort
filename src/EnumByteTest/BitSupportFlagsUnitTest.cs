using BytePacketSupportCore.Attributes;
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
        public void EnumFlagsMode()
        {
            MACHINEFlags aaa = MACHINE.POWER.ToFlags () | MACHINE.RIGHT.ToFlags ();

            Console.WriteLine ($"aaa => POWER|RIGHT");
            // aaa = POWER|RIGHT
        }

        [Fact]
        public void EnumToByte()
        {
            MACHINEFlags aaa = MACHINE.POWER.ToFlags () | MACHINE.RIGHT.ToFlags ();

            byte abc = aaa.ToByte ();
        }

        [Fact]
        public void EnumToByteTest2()
        {
            byte data = 0x05;

            var aa = data.ToEnum<MACHINEFlags> ();

            var bbb = aa.HasFlags (MACHINEFlags.TOP | MACHINEFlags.NONE);
            var ccc = aa.HasNotFlag (MACHINEFlags.LIGHT | MACHINEFlags.NONE);
            var ddd = aa.HasNotFlag (MACHINEFlags.TOP | MACHINEFlags.NONE);

            var aaaa = aa.HasAnyFlag (MACHINE.POWER);
            var bbbb = aa.HasAnyFlag (MACHINE.TOP);
            var cccc = aa.HasAnyFlag (MACHINE.LIGHT);
            var dddd = aa.HasAnyFlag (MACHINE.ETC);

            // Expected result: MACHINE.POWER | MACHINE.TOP
            //Assert.True ();
            //Assert.True (aa.HasFlag (MACHINE.TOP));
            //Assert.False (aa.HasFlag (MACHINE.RIGHT));
        }

        private bool test(EnumByteTest.MACHINEFlags value, EnumByteTest.MACHINEFlags flags) => (value.ToByte() & flags.ToByte ()) != flags.ToByte ();
    }
}
