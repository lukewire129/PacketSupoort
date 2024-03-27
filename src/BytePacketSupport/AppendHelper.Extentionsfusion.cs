using BytePacketSupport.Converter;
using System.Collections.Generic;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] @string(this byte b, string asciiByte) => b.@bytes (ByteConverter.GetBytes (asciiByte));
        public static byte[] @string(this IEnumerable<byte> bs, string asciiByte) => bs.@bytes (ByteConverter.GetBytes (asciiByte));
        public static byte[] @string(this IEnumerable<byte> bs, string asciiByte, int offset, int count) => bs.@bytes (ByteConverter.GetBytes (asciiByte), offset, count);
        public static byte[] @short(this byte b, short shortByte, bool isLittleEndian = true) => b.@bytes (ByteConverter.GetBytes (shortByte, isLittleEndian));
        public static byte[] @short(this IEnumerable<byte> bs, short shortByte, bool isLittleEndian = true) => bs.@bytes (ByteConverter.GetBytes (shortByte, isLittleEndian));
        public static byte[] @short(this IEnumerable<byte> bs, short shortByte, int offset, int count, bool isLittleEndian = true)
        {
            byte[] bytes = ByteConverter.GetBytes (shortByte, isLittleEndian);
            return bs.@bytes (bytes, offset, count);
        }
        public static byte[] @int(this byte b, int intByte, bool isLittleEndian = true) => b.@bytes (ByteConverter.GetBytes (intByte, isLittleEndian));
        public static byte[] @int(this IEnumerable<byte> bs, int intByte, bool isLittleEndian = true) => bs.@bytes (ByteConverter.GetBytes (intByte, isLittleEndian));
        public static byte[] @int(this IEnumerable<byte> bs, int intByte, int offset, int count, bool isLittleEndian = true)
        {
            byte[] bytes = ByteConverter.GetBytes (intByte, isLittleEndian);
            return bs.@bytes (bytes, offset, count);
        }
        public static byte[] @long(this byte b, long longByte, bool isLittleEndian = true) => b.@bytes (ByteConverter.GetBytes (longByte, isLittleEndian));
        public static byte[] @long(this IEnumerable<byte> bs, long longByte, bool isLittleEndian = true) => bs.@bytes (ByteConverter.GetBytes (longByte, isLittleEndian));
        public static byte[] @long(this IEnumerable<byte> bs, long longByte, int offset, int count, bool isLittleEndian = true)
        {
            byte[] bytes = ByteConverter.GetBytes (longByte, isLittleEndian);
            return bs.@bytes (bytes, offset, count);
        }

        public static byte[] @ushort(this byte b, ushort ushortByte, bool isLittleEndian = true) => b.@bytes (ByteConverter.GetBytes (ushortByte, isLittleEndian));
        public static byte[] @ushort(this IEnumerable<byte> bs, ushort ushortByte, bool isLittleEndian = true) => bs.@bytes (ByteConverter.GetBytes (ushortByte, isLittleEndian));
        public static byte[] @ushort(this IEnumerable<byte> bs, ushort ushortByte, int offset, int count, bool isLittleEndian = true)
        {
            byte[] bytes = ByteConverter.GetBytes (ushortByte, isLittleEndian);
            return bs.@bytes (bytes, offset, count);
        }
        public static byte[] @uint(this byte b, uint uintByte, bool isLittleEndian = true) => b.@bytes (ByteConverter.GetBytes (uintByte, isLittleEndian));
        public static byte[] @uint(this IEnumerable<byte> bs, uint uintByte, bool isLittleEndian = true) => bs.@bytes (ByteConverter.GetBytes (uintByte, isLittleEndian));
        public static byte[] @uint(this IEnumerable<byte> bs, uint uintByte, int offset, int count, bool isLittleEndian = true)
        {
            byte[] bytes = ByteConverter.GetBytes (uintByte, isLittleEndian);
            return bs.@bytes (bytes, offset, count);
        }
        public static byte[] @ulong(this byte b, ulong ulongByte, bool isLittleEndian = true) => b.@bytes (ByteConverter.GetBytes (ulongByte, isLittleEndian));
        public static byte[] @ulong(this IEnumerable<byte> bs, ulong ulongByte, bool isLittleEndian = true) => bs.@bytes (ByteConverter.GetBytes (ulongByte, isLittleEndian));
        public static byte[] @ulong(this IEnumerable<byte> bs, ulong ulongByte, int offset, int count, bool isLittleEndian = true)
        {
            byte[] bytes = ByteConverter.GetBytes (ulongByte, isLittleEndian);
            return bs.@bytes (bytes, offset, count);
        }
        public static byte[] @class<TSource>(this byte b, TSource AppenClass) where TSource : class
        {
            byte[] result = new byte[] { b };
            return result.@bytes (PacketParse.Serialize (AppenClass));
        }

        public static byte[] @Class<TSource>(this IEnumerable<byte> b, TSource AppenClass) where TSource : class
        {
            var result = b;
            return result.@bytes (PacketParse.Serialize (AppenClass));
        }
    }
}
