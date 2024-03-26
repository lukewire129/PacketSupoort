using BytePacketSupport.Converter;
using BytePacketSupport.Enums;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] Append(this byte b, short shortByte, bool isLittleEndian = false) => b.Append (ByteConverter.GetByte (shortByte, isLittleEndian));
        public static byte[] Append(this byte[] bs, short shortByte, bool isLittleEndian = false) => bs.Append (ByteConverter.GetByte (shortByte, isLittleEndian));
        public static byte[] Append(this byte[] bs, short shortByte, int offset, int count, bool isLittleEndian = false)
        {
            byte[] bytes = ByteConverter.GetByte (shortByte, isLittleEndian);
            return bs.Append (bytes, offset, count);
        }
    }
}
