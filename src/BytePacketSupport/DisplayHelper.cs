using System;
using System.Text;

namespace BytePacketSupport
{
    public static class DisplayHelper
    {
        public static string DisplayAscii(this byte[] b)
        {
            return Encoding.ASCII.GetString (b);
        }
        public static string Display(this byte b)
        {
            return b.ToString ("X2");
        }

        public static string Display(this byte[] b)
        {
            return string.Concat (Array.ConvertAll (b, byt => byt.ToString ("X2")));
        }
    }
}
