using System;
using System.Collections.Generic;
using System.Linq;

namespace PacketSupport.Core.Helper
{
    public static partial class AppendHelper
    {
        public static byte[] AppendByte(this byte b, byte appenbyte) => new byte[] { b, appenbyte };
        public static byte[] AppendByte(this IEnumerable<byte> bs, byte appenbyte) => bs.Append<byte> (appenbyte).ToArray ();
        public static byte[] AppendBytes(this byte b, IEnumerable<byte> appenbytes)
        {
            byte[] appendArray = appenbytes as byte[] ?? appenbytes.ToArray ();

            // 최종 배열 크기 계산 및 생성
            byte[] totalBytes = new byte[1 + appendArray.Length];
            totalBytes[0] = b;
            Buffer.BlockCopy (appendArray, 0, totalBytes, 1, appendArray.Length);

            return totalBytes;
        }

        // List<byte> 보단 byte[]가 더 효율적임
        public static byte[] AppendBytes(this IEnumerable<byte> bs, IEnumerable<byte> appendBytes)
        {
            // 이미 배열인지 확인하여 캐스팅
            byte[] sourceArray = bs as byte[] ?? bs.ToArray ();
            byte[] appendArray = appendBytes as byte[] ?? appendBytes.ToArray ();

            // 최종 배열 크기 계산 및 생성
            byte[] totalBytes = new byte[sourceArray.Length + appendArray.Length];

            // 배열 복사
            Buffer.BlockCopy (sourceArray, 0, totalBytes, 0, sourceArray.Length);
            Buffer.BlockCopy (appendArray, 0, totalBytes, sourceArray.Length, appendArray.Length);

            return totalBytes;
        }

        public static byte[] AppendBytes(this IEnumerable<byte> bs, IEnumerable<byte> appendBytes, int offset, int count)
        {
            // 이미 배열인지 확인하여 캐스팅
            byte[] sourceArray = bs as byte[] ?? bs.ToArray ();
            byte[] appendArray = appendBytes as byte[] ?? appendBytes.ToArray ();

            // 최종 배열 크기 계산 및 생성
            byte[] totalBytes = new byte[sourceArray.Length + appendArray.Length];

            Buffer.BlockCopy (bs.ToArray (), 0, totalBytes, 0, bs.Count ());
            Buffer.BlockCopy (appendArray.ToArray (), offset, totalBytes, bs.Count (), count);

            return totalBytes;
        }
        public static byte[] @byte(this byte b, byte appenbyte) => AppendByte (b, appenbyte);
        public static byte[] @byte(this IEnumerable<byte> bs, byte appenbyte) => AppendByte (bs, appenbyte);
        public static byte[] @bytes(this byte b, IEnumerable<byte> appenbytes) => AppendBytes (b, appenbytes);

        public static byte[] @bytes(this IEnumerable<byte> bs, IEnumerable<byte> appenbytes) => AppendBytes (bs, appenbytes);

        public static byte[] @bytes(this IEnumerable<byte> bs, IEnumerable<byte> appenbytes, int offset, int count) => AppendBytes (bs, appenbytes, offset, count);
    }
}
