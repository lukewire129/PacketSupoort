using System;
using System.Collections.Generic;
using System.Text;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] Append(this byte b, string asciiByte)
        {
            byte[] asciibyte = Encoding.ASCII.GetBytes (asciiByte);
            return b.Append (asciibyte);
        }

        public static byte[] Append(this byte[] bs, string asciiByte)
        {
            byte[] asciibyte = Encoding.ASCII.GetBytes (asciiByte);
            return bs.Append (asciibyte);
        }
        public static byte[] Append(this byte[] bs, string asciiByte, int offset, int count)
        {
            byte[] asciibyte = Encoding.ASCII.GetBytes (asciiByte);
            return bs.Append (asciibyte, offset, count);
        }
    }
}
