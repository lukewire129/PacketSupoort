using BytePacketSupport.Converter;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] @string(this byte b, string asciiByte) => b.@bytes (ByteConverter.GetBytes (asciiByte));
        public static byte[] @string(this byte[] bs, string asciiByte) => bs.@bytes (ByteConverter.GetBytes (asciiByte));
        public static byte[] @string(this byte[] bs, string asciiByte, int offset, int count) => bs.@bytes (ByteConverter.GetBytes (asciiByte), offset, count);
    }
}
