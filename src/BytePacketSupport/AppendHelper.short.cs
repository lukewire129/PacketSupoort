using BytePacketSupport.Converter;
using BytePacketSupport.Enums;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] Append(this byte b, short shortByte, bool isLittleEndian = true) => b.Append (ByteConverter.GetBytes (shortByte, isLittleEndian));
        public static byte[] Append(this byte[] bs, short shortByte, bool isLittleEndian = true) => bs.Append (ByteConverter.GetBytes (shortByte, isLittleEndian));
        public static byte[] Append(this byte[] bs, short shortByte, int offset, int count, bool isLittleEndian = true)
        {
            byte[] bytes = ByteConverter.GetBytes (shortByte, isLittleEndian);
            return bs.Append (bytes, offset, count);
        }
    }
}
