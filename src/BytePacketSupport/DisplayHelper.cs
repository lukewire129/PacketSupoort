using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BytePacketSupport
{
    public static class DisplayHelper
    {
        public static string ToHexString(this byte b) => b.ToString ("X2");
        public static string ToHexString(this IEnumerable<byte> bytes) => string.Concat (Array.ConvertAll (bytes.ToArray(), byt => byt.ToString ("X2")));
        public static string GetString(this IEnumerable<byte> bytes) => GetString (bytes, Encoding.ASCII);
        public static string GetString(this IEnumerable<byte> bytes, Encoding encoding) => encoding.GetString (bytes.ToArray());
    }
}
