using PacketSupport.Core.Enums;
using System;
using System.Text;

namespace PacketSupport.Core.Converter
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

        public static byte[] GetBytes(byte[] byteArray, Endian endian)
        {
            bool isByteArray = endian == Endian.LITTLE || endian == Endian.LITTLEBYTESWAP;
            if (BitConverter.IsLittleEndian != isByteArray)
                Array.Reverse (byteArray);

            if (endian == Endian.LITTLEBYTESWAP || endian == Endian.BIGBYTESWAP)
            {
                // 결과를 저장할 배열 생성 (원본 배열과 동일한 크기)
                byte[] temp = new byte[byteArray.Length];

                for (int i = 0; i < byteArray.Length; i += 2)
                {
                    // 2바이트씩 추출하여 EndianChange 수행
                    byte[] chunk = { byteArray[i], i + 1 < byteArray.Length ? byteArray[i + 1] : (byte)0 };
                    byte[] changedChunk = EndianChange (chunk, endian);

                    // 결과 배열에 직접 복사
                    temp[i] = changedChunk[0];
                    if (i + 1 < byteArray.Length)
                        temp[i + 1] = changedChunk[1];
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
            return GetBytes (bytes, endian);
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
