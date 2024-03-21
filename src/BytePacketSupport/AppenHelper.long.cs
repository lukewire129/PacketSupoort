using BytePacketSupport.Enums;
using System;
using System.Linq;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] Append(this byte b, long longByte, Endian endian = Endian.BIG)
        {
            byte[] asciibyte = BitConverter.GetBytes (longByte);
            return b.Append (endian == Endian.LITTLE ? asciibyte.Reverse ().ToArray() : asciibyte);
        }

        public static byte[] Append(this byte[] bs, long longByte, Endian endian = Endian.BIG)
        {
            byte[] asciibyte = BitConverter.GetBytes (longByte);
            return bs.Append (endian == Endian.LITTLE ? asciibyte.Reverse ().ToArray () : asciibyte);
        }
        public static byte[] Append(this byte[] bs, long longByte, int offset, int count, Endian endian = Endian.BIG)
        {
            byte[] asciibyte = BitConverter.GetBytes (longByte);
            return bs.Append (endian == Endian.LITTLE ? asciibyte.Reverse ().ToArray () : asciibyte);
        }
    }
}
