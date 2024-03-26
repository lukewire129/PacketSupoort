using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace BytePacketSupport.Converter
{
    public static class ByteConverter
    {
        public static byte[] GetBytes(int intByte, bool IsLittleEndian = true)
        {
            byte[] bytes = BitConverter.GetBytes (intByte);

            if (BitConverter.IsLittleEndian != IsLittleEndian)
                Array.Reverse(bytes);

            return bytes;
        }

        public static byte[] GetBytes(long longBytes, bool IsLittleEndian = true)
        {
            byte[] bytes = BitConverter.GetBytes (longBytes);

            if (BitConverter.IsLittleEndian != IsLittleEndian)
                Array.Reverse(bytes);

            return bytes;
        }
        public static byte[] GetBytes(short shortByte, bool IsLittleEndian = true)
        {
            byte[] bytes = BitConverter.GetBytes (shortByte);

            if (BitConverter.IsLittleEndian != IsLittleEndian)
                Array.Reverse(bytes);

            return bytes;
        }

        public static byte[] GetBytes(uint uintByte, bool IsLittleEndian = true)
        {
            byte[] bytes = BitConverter.GetBytes (uintByte);

            if (BitConverter.IsLittleEndian != IsLittleEndian)
                Array.Reverse(bytes);

            return bytes;
        }

        public static byte[] GetBytes(ulong ulongBytes, bool IsLittleEndian = true)
        {
            byte[] bytes = BitConverter.GetBytes (ulongBytes);

            if (BitConverter.IsLittleEndian != IsLittleEndian)
                Array.Reverse(bytes);

            return bytes;
        }
        public static byte[] GetBytes(ushort ushortByte, bool IsLittleEndian = true)
        {
            byte[] bytes = BitConverter.GetBytes (ushortByte);

            if (BitConverter.IsLittleEndian != IsLittleEndian)
                Array.Reverse(bytes);

            return bytes;
        }
    }
}
