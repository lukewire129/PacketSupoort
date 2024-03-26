using BytePacketSupport.Converter;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] @short(this byte b, short shortByte, bool isLittleEndian = true) => b.@bytes (ByteConverter.GetBytes (shortByte, isLittleEndian));
        public static byte[] @short(this byte[] bs, short shortByte, bool isLittleEndian = true) => bs.@bytes (ByteConverter.GetBytes (shortByte, isLittleEndian));
        public static byte[] @short(this byte[] bs, short shortByte, int offset, int count, bool isLittleEndian = true)
        {
            byte[] bytes = ByteConverter.GetBytes (shortByte, isLittleEndian);
            return bs.@bytes (bytes, offset, count);
        }
    }
}
