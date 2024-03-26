using BytePacketSupport.Converter;
using BytePacketSupport.Enums;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] Append(this byte b, long longByte, bool isLittleEndian = true) => b.Append (ByteConverter.GetBytes (longByte, isLittleEndian));
        public static byte[] Append(this byte[] bs, long longByte, bool isLittleEndian = true) => bs.Append (ByteConverter.GetBytes (longByte, isLittleEndian));
        public static byte[] Append(this byte[] bs, long longByte, int offset, int count, bool isLittleEndian = true)
        {
            byte[] bytes = ByteConverter.GetBytes (longByte, isLittleEndian);
            return bs.Append (bytes, offset, count);
        }
    }
}
