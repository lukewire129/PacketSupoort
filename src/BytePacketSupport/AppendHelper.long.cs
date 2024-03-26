using BytePacketSupport.Converter;
using BytePacketSupport.Enums;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] Append(this byte b, long longByte, bool isLittleEndian = false) => b.Append (ByteConverter.GetByte (longByte, isLittleEndian));
        public static byte[] Append(this byte[] bs, long longByte, bool isLittleEndian = false) => bs.Append (ByteConverter.GetByte (longByte, isLittleEndian));
        public static byte[] Append(this byte[] bs, long longByte, int offset, int count, bool isLittleEndian = false)
        {
            byte[] bytes = ByteConverter.GetByte (longByte, isLittleEndian);
            return bs.Append (bytes, offset, count);
        }
    }
}
