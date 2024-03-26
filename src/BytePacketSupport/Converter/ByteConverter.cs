using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace BytePacketSupport.Converter
{
    public static class ByteConverter
    {
        public static byte[] GetBytes(string asciiByte)=> Encoding.ASCII.GetBytes (asciiByte);

        public static byte[] GetBytes(int intByte, bool isMustReverseUnit = false)
        {
            byte[] bytes = BitConverter.GetBytes (intByte);

            if (isMustReverseUnit == true)
                Array.Reverse(bytes);

            return bytes;
        }

        public static byte[] GetBytes(long longBytes, bool isMustReverseUnit = false)
        {
            byte[] bytes = BitConverter.GetBytes (longBytes);

            if (isMustReverseUnit == true)
                Array.Reverse(bytes);

            return bytes;
        }
        public static byte[] GetBytes(short shortByte, bool isMustReverseUnit = false)
        {
            byte[] bytes = BitConverter.GetBytes (shortByte);

            if (isMustReverseUnit == true)
                Array.Reverse(bytes);

            return bytes;
        }

        public static byte[] GetBytes(uint uintByte, bool isMustReverseUnit = false)
        {
            byte[] bytes = BitConverter.GetBytes (uintByte);

            if (isMustReverseUnit == true)
                Array.Reverse(bytes);

            return bytes;
        }

        public static byte[] GetBytes(ulong ulongBytes, bool isMustReverseUnit = false)
        {
            byte[] bytes = BitConverter.GetBytes (ulongBytes);

            if (isMustReverseUnit == true)
                Array.Reverse(bytes);

            return bytes;
        }
        public static byte[] GetBytes(ushort ushortByte, bool isMustReverseUnit = false)
        {
            byte[] bytes = BitConverter.GetBytes (ushortByte);

            if (isMustReverseUnit == true)
                Array.Reverse(bytes);

            return bytes;
        }
    }
}
