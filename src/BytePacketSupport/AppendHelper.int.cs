using BytePacketSupport.Converter;
using BytePacketSupport.Enums;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] Append(this byte b, int intByte, Endian endian = Endian.BIG) => b.Append (ByteConverter.GetByte (intByte, endian));
        public static byte[] Append(this byte[] bs, int intByte, Endian endian = Endian.BIG) => bs.Append (ByteConverter.GetByte (intByte, endian));
        public static byte[] Append(this byte[] bs, int intByte, int offset, int count, Endian endian = Endian.BIG)
        {
            byte[] bytes = ByteConverter.GetByte (intByte, endian);
            return bs.Append (bytes, offset, count);
        }
    }
} 
