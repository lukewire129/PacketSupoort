using BytePacketSupport.Converter;
using BytePacketSupport.Enums;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] Append(this byte b, short shortByte, Endian endian = Endian.BIG) => b.Append (ByteConverter.GetByte (shortByte, endian));

        public static byte[] Append(this byte[] bs, short shortByte, Endian endian = Endian.BIG) => bs.Append (ByteConverter.GetByte (shortByte, endian));

        public static byte[] Append(this byte[] bs, short shortByte, int offset, int count, Endian endian = Endian.BIG)
        {
            byte[] bytes = ByteConverter.GetByte (shortByte, endian);
            return bs.Append (bytes, offset, count);
        }
    }
}
