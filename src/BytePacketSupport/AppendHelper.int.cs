using BytePacketSupport.Enums;
using System;
using System.Linq;
using System.Text;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] Append(this byte b, int intByte, Endian endian = Endian.BIG)
        {
            byte[] asciibyte = BitConverter.GetBytes (intByte);
            return b.Append (endian == Endian.LITTLE ? asciibyte.Reverse ().ToArray() : asciibyte);
        }

        public static byte[] Append(this byte[] bs, int intByte, Endian endian = Endian.BIG)
        {
            byte[] asciibyte = BitConverter.GetBytes (intByte);
            return bs.Append (endian == Endian.LITTLE ? asciibyte.Reverse ().ToArray () : asciibyte);
        }
        public static byte[] Append(this byte[] bs, int intByte, int offset, int count, Endian endian = Endian.BIG)
        {
            byte[] asciibyte = BitConverter.GetBytes (intByte);
            return bs.Append (endian == Endian.LITTLE ? asciibyte.Reverse ().ToArray () : asciibyte);
        }
    }
}
