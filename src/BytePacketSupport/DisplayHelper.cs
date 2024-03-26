using System;
using System.Text;

namespace BytePacketSupport
{
    public static class DisplayHelper
    {
        public static string ToHexString(this byte b) => b.ToString ("X2");
        public static string ToHexString(this byte[] bytes) => string.Concat (Array.ConvertAll (bytes, byt => byt.ToString ("X2")));
        public static string GetString(this byte[] bytes) => GetString (bytes, Encoding.ASCII);
        public static string GetString(this byte[] bytes, Encoding encoding) => encoding.GetString (bytes);
    }
}
