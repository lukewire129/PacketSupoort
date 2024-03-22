using System.Text;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] Append(this byte b, string asciiByte) => b.Append (Encoding.ASCII.GetBytes (asciiByte));
        public static byte[] Append(this byte[] bs, string asciiByte) => bs.Append (Encoding.ASCII.GetBytes (asciiByte));
        public static byte[] Append(this byte[] bs, string asciiByte, int offset, int count) => bs.Append (Encoding.ASCII.GetBytes (asciiByte), offset, count);
    }
}
