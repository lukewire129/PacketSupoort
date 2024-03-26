using BytePacketSupport.Enums;
using System.Linq;
using System;
using System.Text;

namespace BytePacketSupport.Converter
{
    public static class ByteConverter
    {
        public static byte[] GetByte(string asciiByte)=> Encoding.ASCII.GetBytes (asciiByte);

        public static byte[] GetBytes(int intByte, bool isLittleEndian = true)
        {
            byte[] bytes = BitConverter.GetBytes (intByte);

            if (BitConverter.IsLittleEndian == isLittleEndian)
                return bytes;

            return bytes.Reverse ().ToArray ();
        }

        public static byte[] GetByte(long longBytes, bool isLittleEndian = true)
        {
            byte[] bytes = BitConverter.GetBytes (longBytes);

            if (BitConverter.IsLittleEndian == isLittleEndian)
                return bytes;

            return bytes.Reverse ().ToArray ();
        }
        public static byte[] GetByte(short shortByte, bool isLittleEndian = true)
        {
            byte[] bytes = BitConverter.GetBytes (shortByte);

            if (BitConverter.IsLittleEndian == isLittleEndian)
                return bytes;

            return bytes.Reverse ().ToArray ();
        }
    }
}
