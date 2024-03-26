using System;
using System.Text;

namespace BytePacketSupport.Converter
{
    public static class ByteConverter
    {
        public static byte[] GetBytes(string str) => Encoding.ASCII.GetBytes (str);
        public static byte[] GetBytes(int intByte, bool isLittleEndian = true)
        {
            byte[] bytes = BitConverter.GetBytes (intByte);

            if (BitConverter.IsLittleEndian != isLittleEndian)
                Array.Reverse(bytes);

            return bytes;
        }

        public static byte[] GetBytes(long longBytes, bool isLittleEndian = true)
        {
            byte[] bytes = BitConverter.GetBytes (longBytes);

            if (BitConverter.IsLittleEndian != isLittleEndian)
                Array.Reverse(bytes);

            return bytes;
        }
        public static byte[] GetBytes(short shortByte, bool isLittleEndian = true)
        {
            byte[] bytes = BitConverter.GetBytes (shortByte);

            if (BitConverter.IsLittleEndian != isLittleEndian)
                Array.Reverse(bytes);

            return bytes;
        }

        public static byte[] GetBytes(uint uintByte, bool isLittleEndian = true)
        {
            byte[] bytes = BitConverter.GetBytes (uintByte);

            if (BitConverter.IsLittleEndian != isLittleEndian)
                Array.Reverse(bytes);

            return bytes;
        }

        public static byte[] GetBytes(ulong ulongBytes, bool isLittleEndian = true)
        {
            byte[] bytes = BitConverter.GetBytes (ulongBytes);

            if (BitConverter.IsLittleEndian != isLittleEndian)
                Array.Reverse(bytes);

            return bytes;
        }
        public static byte[] GetBytes(ushort ushortByte, bool isLittleEndian = true)
        {
            byte[] bytes = BitConverter.GetBytes (ushortByte);

            if (BitConverter.IsLittleEndian != isLittleEndian)
                Array.Reverse(bytes);

            return bytes;
        }
    }
}
