using BytePacketSupport.Extentions;
namespace EnumByteTest
{
    public class UnitTest1
    {
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

        [Fact]
        public void EnumToByteTest1()
        {
            var rest = EnumHelper.Byte (MACHINE.POWER, MACHINE.TOP);

            // Result : 0x05;
        }
        [Fact]
        public void EnumToByteTest2()
        {
            var rest = EnumHelper.Byte (MACHINE.POWER, MACHINE.RIGHT);

            // Result : 0x03;
        }

        [Fact]
        public void EnumString1()
        {
            byte data = 0x05;
            var enums = data.ToEnumDatasString<MACHINE> ();

            // Result :  [POWER, TOP]
        }
        [Fact]
        public void EnumString2()
        {
            byte data = 0x0A;
            var enums = data.ToEnumDatasString<MACHINE> ();

            // Result :  [RIGHT, LIGHT]
        }

        [Fact]
        public void EnumNull()
        {
            byte data = 0x00;
            var enums = data.ToEnumDatasString<MACHINE> ();

            // Result null
        }

        [Fact]
        public void ToEnumTest1()
        {
            byte data = 0x10;
            var enums = data.ToEnumDatas<MACHINE> ();

            // Result : Temp
        }

        [Fact]
        public void ToEnumTest2()
        {
            byte data = 0x05;
            var enums = data.ToEnumDatas<MACHINE> ();

            // Result : POWER, TOP
        }

        [Fact]
        public void ToEnumTest3()
        {
            byte data = 0x00;
            var enums = data.ToEnumDatas<MACHINE> ();

            // Result : NULL
        }
    }
}