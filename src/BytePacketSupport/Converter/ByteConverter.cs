using BytePacketSupport.Enums;
using System;
using System.Buffers;
using System.Linq;
using System.Text;

namespace BytePacketSupport.Converter
{
    public static class ByteConverter
    {
        public static byte[] GetBytes(string str) => Encoding.ASCII.GetBytes (str);

        /// <summary>
        /// TODO: 무조건 2Byte만 들어옴......무조건.....이거 어떻게 제약걸지 음음음음 
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="endian"></param>
        /// <returns></returns>
        private static byte[] EndianChange(byte[] byteArray, Endian endian)
        {
            if (endian == Endian.BIG || endian == Endian.LITTLE)
            {
                bool isLittleEndian = endian == Endian.LITTLE;
                if (BitConverter.IsLittleEndian != isLittleEndian)
                    Array.Reverse (byteArray);
            }
            else
            {
                Array.Reverse (byteArray);
            }

            return byteArray;
        }

        private static byte[] GetBytes(byte[] byteArray, Endian endian)
        {
            bool isByteArray = endian == Endian.LITTLE || endian == Endian.LITTLEBYTESWAP;
            if (BitConverter.IsLittleEndian != isByteArray)
                Array.Reverse (byteArray);

            if (endian == Endian.LITTLEBYTESWAP || endian == Endian.BIGBYTESWAP)
            {
                byte[] temp = new byte[0];
                for (int i = 0; i < byteArray.Length; i += 2)
                {
                    temp = temp.AppendBytes (EndianChange (byteArray.Skip (0 + i).Take (2).ToArray (), endian));
                }

                byteArray = temp;
            }

            return byteArray;
        }

        public static byte[] GetBytes(short shortByte, Endian endian = Endian.LITTLE)
        {
            byte[] bytes = BitConverter.GetBytes (shortByte);

            return GetBytes (bytes, endian);
        }

        public static byte[] GetBytes(int intByte, Endian endian = Endian.LITTLE)
        {
            byte[] bytes = BitConverter.GetBytes (intByte);
            return GetBytes (bytes, endian);
        }

        public static byte[] GetBytes(long longBytes, Endian endian = Endian.LITTLE)
        {
            byte[] bytes = BitConverter.GetBytes (longBytes);
            return GetBytes (bytes, endian);
        }
        public static byte[] GetBytes(ushort ushortByte, Endian endian = Endian.LITTLE)
        {
            byte[] bytes = BitConverter.GetBytes (ushortByte);
            return EndianChange (bytes, endian);
        }

        public static byte[] GetBytes(uint uintByte, Endian endian = Endian.LITTLE)
        {
            byte[] bytes = BitConverter.GetBytes (uintByte);
            return GetBytes (bytes, endian);
        }

        public static byte[] GetBytes(ulong ulongBytes, Endian endian = Endian.LITTLE)
        {
            byte[] bytes = BitConverter.GetBytes (ulongBytes);
            return GetBytes (bytes, endian);
        }
    }
}
