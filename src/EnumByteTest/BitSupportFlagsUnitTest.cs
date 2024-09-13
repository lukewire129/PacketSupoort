using BitPacketSupoort.SourceGenerators.Attributes;
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
        public void FlagsTypeChange()
        {
            MACHINEFlags aaa = MACHINE.POWER.ToFlags () | MACHINE.RIGHT.ToFlags ();

            Console.WriteLine ($"aaa => POWER|RIGHT");
            // aaa = POWER|RIGHT
        }

        [Fact]
        public void FlagsTypeChangeToByte()
        {
            MACHINEFlags aaa = MACHINE.POWER.ToFlags () | MACHINE.RIGHT.ToFlags ();

            byte abc = aaa.ToByte ();
        }

        [Fact]
        public void ByteToEnum_TEST1()
        {
            byte data = 0x05;

            var enumData = data.ToEnum<MACHINEFlags> ();

            if (enumData.HasFlags (MACHINEFlags.POWER | MACHINEFlags.TOP))
            {
                Console.WriteLine ("POWER ON, TOP ON");
            }
            if (enumData.HasFlags (MACHINEFlags.POWER | MACHINEFlags.LIGHT))
            {
                Console.WriteLine ("POWER ON, TOP ON");
            }

            if (enumData.HasAnyFlag (MACHINEFlags.POWER))
            {
                Console.WriteLine ("POWER ON");
            }
            if (enumData.HasAnyFlag (MACHINEFlags.TOP))
            {
                Console.WriteLine ("TOP True");
            }
            if (enumData.HasAnyFlag (MACHINEFlags.LIGHT))
            {
                Console.WriteLine ("LIGHT True");
            }
            if (enumData.HasNotFlag (MACHINEFlags.LIGHT))
            {
                Console.WriteLine ("LIGHT False");
            }
        }

        [Fact]
        public void ByteToEnum_TEST2()
        {
            byte data = 0x05;

            var enumData = data.ToEnum<MACHINE> ();

            if (enumData.HasFlags (MACHINEFlags.POWER | MACHINEFlags.TOP))
            {
                Console.WriteLine ("POWER ON, TOP ON");
            }
            if (enumData.HasFlags (MACHINEFlags.POWER | MACHINEFlags.LIGHT))
            {
                Console.WriteLine ("POWER ON, TOP ON");
            }

            if (enumData.HasAnyFlag (MACHINEFlags.POWER))
            {
                Console.WriteLine ("POWER ON");
            }
            if (enumData.HasAnyFlag (MACHINEFlags.TOP))
            {
                Console.WriteLine ("TOP True");
            }
            if (enumData.HasAnyFlag (MACHINEFlags.LIGHT))
            {
                Console.WriteLine ("LIGHT True");
            }
            if (enumData.HasNotFlag (MACHINEFlags.LIGHT))
            {
                Console.WriteLine ("LIGHT False");
            }
        }

        [Fact]
        public void ByteToEnum_TEST3()
        {
            byte data = 0x05;

            var enumData = data.ToEnum<MACHINE> ();

            if (enumData.HasAnyFlag (MACHINE.POWER))
            {
                Console.WriteLine ("POWER ON");
            }
            if (enumData.HasAnyFlag (MACHINE.TOP))
            {
                Console.WriteLine ("TOP True");
            }
            if (enumData.HasAnyFlag (MACHINE.LIGHT))
            {
                Console.WriteLine ("LIGHT True");
            }
            if (enumData.HasNotFlag (MACHINE.LIGHT))
            {
                Console.WriteLine ("LIGHT False");
            }
        }
    }
}
