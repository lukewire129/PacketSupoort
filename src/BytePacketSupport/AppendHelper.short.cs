using BytePacketSupport.Enums;
using System;
using System.Linq;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] Append(this byte b, short shortByte, Endian endian = Endian.BIG)
        {
            byte[] asciibyte = BitConverter.GetBytes (shortByte);
            return b.Append (endian == Endian.LITTLE ? asciibyte.Reverse ().ToArray() : asciibyte);
        }

        public static byte[] Append(this byte[] bs, short shortByte, Endian endian = Endian.BIG)
        {
            byte[] asciibyte = BitConverter.GetBytes (shortByte);
            return bs.Append (endian == Endian.LITTLE ? asciibyte.Reverse ().ToArray () : asciibyte);
        }
        public static byte[] Append(this byte[] bs, short shortByte, int offset, int count, Endian endian = Endian.BIG)
        {
            byte[] asciibyte = BitConverter.GetBytes (shortByte);
            return bs.Append (endian == Endian.LITTLE ? asciibyte.Reverse ().ToArray () : asciibyte);
        }
    }
}
