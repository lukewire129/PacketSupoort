using BytePacketSupport.Converter;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] @long(this byte b, long longByte, bool isLittleEndian = true) => b.@bytes (ByteConverter.GetBytes (longByte, isLittleEndian));
        public static byte[] @long(this byte[] bs, long longByte, bool isLittleEndian = true) => bs.@bytes (ByteConverter.GetBytes (longByte, isLittleEndian));
        public static byte[] @long(this byte[] bs, long longByte, int offset, int count, bool isLittleEndian = true)
        {
            byte[] bytes = ByteConverter.GetBytes (longByte, isLittleEndian);
            return bs.@bytes (bytes, offset, count);
        }
    }
}
