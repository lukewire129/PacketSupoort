using BytePacketSupport.Converter;
using BytePacketSupport.Enums;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] Append(this byte b, long longByte, Endian endian = Endian.BIG) => b.Append (ByteConverter.GetByte (longByte, endian));

        public static byte[] Append(this byte[] bs, long longByte, Endian endian = Endian.BIG) => bs.Append (ByteConverter.GetByte (longByte, endian));
        public static byte[] Append(this byte[] bs, long longByte, int offset, int count, Endian endian = Endian.BIG)
        {
            byte[] bytes = ByteConverter.GetByte (longByte, endian);
            return bs.Append (bytes, offset, count);
        }
    }
}
