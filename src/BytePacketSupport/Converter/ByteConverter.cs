using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BytePacketSupport.Converter
{
    public static class ByteConverter
    {
        public static byte[] GetByte(string asciiByte)=> Encoding.ASCII.GetBytes (asciiByte);

        public static byte[] GetByte(int intByte, bool isLittleEndian = true)
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

        public static byte[] GetByte(uint uintByte, bool isLittleEndian = true)
        {
            byte[] bytes = BitConverter.GetBytes (uintByte);

            if (BitConverter.IsLittleEndian == isLittleEndian)
                return bytes;

            return bytes.Reverse ().ToArray ();
        }

        public static byte[] GetByte(ulong ulongBytes, bool isLittleEndian = true)
        {
            byte[] bytes = BitConverter.GetBytes (ulongBytes);

            if (BitConverter.IsLittleEndian == isLittleEndian)
                return bytes;

            return bytes.Reverse ().ToArray ();
        }
        public static byte[] GetByte(ushort ushortByte, bool isLittleEndian = true)
        {
            byte[] bytes = BitConverter.GetBytes (ushortByte);

            if (BitConverter.IsLittleEndian == isLittleEndian)
                return bytes;

            return bytes.Reverse ().ToArray ();
        }
    }
}
