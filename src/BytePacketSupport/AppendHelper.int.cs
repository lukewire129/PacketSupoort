using BytePacketSupport.Converter;
using BytePacketSupport.Enums;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] Append(this byte b, int intByte, bool isLittleEndian = false) => b.Append (ByteConverter.GetByte (intByte, isLittleEndian));
        public static byte[] Append(this byte[] bs, int intByte, bool isLittleEndian = false) => bs.Append (ByteConverter.GetByte (intByte, isLittleEndian));
        public static byte[] Append(this byte[] bs, int intByte, int offset, int count, bool isLittleEndian = false)
        {
            byte[] bytes = ByteConverter.GetByte (intByte, isLittleEndian);
            return bs.Append (bytes, offset, count);
        }
    }
} 
