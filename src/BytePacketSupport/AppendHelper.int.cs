using BytePacketSupport.Converter;
using BytePacketSupport.Enums;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] @int(this byte b, int intByte, bool isLittleEndian = true) => b.@bytes (ByteConverter.GetBytes (intByte, isLittleEndian));
        public static byte[] @int(this byte[] bs, int intByte, bool isLittleEndian = true) => bs.@bytes (ByteConverter.GetBytes (intByte, isLittleEndian));
        public static byte[] @int(this byte[] bs, int intByte, int offset, int count, bool isLittleEndian = true)
        {
            byte[] bytes = ByteConverter.GetBytes (intByte, isLittleEndian);
            return bs.@bytes (bytes, offset, count);
        }
    }
} 
