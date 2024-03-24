using BytePacketSupport.Converter;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] Append(this byte b, string asciiByte) => b.Append (ByteConverter.GetByte(asciiByte));
        public static byte[] Append(this byte[] bs, string asciiByte) => bs.Append (ByteConverter.GetByte (asciiByte));
        public static byte[] Append(this byte[] bs, string asciiByte, int offset, int count) => bs.Append (ByteConverter.GetByte (asciiByte), offset, count);
    }
}
