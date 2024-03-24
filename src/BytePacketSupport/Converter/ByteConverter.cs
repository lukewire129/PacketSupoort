using BytePacketSupport.Enums;
using System.Linq;
using System;
using System.Text;

namespace BytePacketSupport.Converter
{
    public static class ByteConverter
    {
        public static byte[] GetByte(string asciiByte)=> Encoding.ASCII.GetBytes (asciiByte);
        public static byte[] GetByte(int intByte, Endian endian = Endian.BIG)
        {
            byte[] _intByte = BitConverter.GetBytes (intByte);
            return endian == Endian.LITTLE ? _intByte.Reverse ().ToArray () : _intByte;
        }
        public static byte[] GetByte(long intByte, Endian endian = Endian.BIG)
        {
            byte[] _intByte = BitConverter.GetBytes (intByte);
            return endian == Endian.LITTLE ? _intByte.Reverse ().ToArray () : _intByte;
        }
        public static byte[] GetByte(short intByte, Endian endian = Endian.BIG)
        {
            byte[] _intByte = BitConverter.GetBytes (intByte);
            return endian == Endian.LITTLE ? _intByte.Reverse ().ToArray () : _intByte;
        }
    }
}
