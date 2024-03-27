using BytePacketSupport.Converter;
using System.Collections.Generic;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] Appendshort(this byte b, short shortByte, bool isLittleEndian = true) => b.@bytes (ByteConverter.GetBytes (shortByte, isLittleEndian));
        public static byte[] Appendshort(this IEnumerable<byte> bs, short shortByte, bool isLittleEndian = true) => bs.@bytes (ByteConverter.GetBytes (shortByte, isLittleEndian));
        public static byte[] Appendshort(this IEnumerable<byte> bs, short shortByte, int offset, int count, bool isLittleEndian = true)
        {
            byte[] bytes = ByteConverter.GetBytes (shortByte, isLittleEndian);
            return bs.@bytes (bytes, offset, count);
        }
        public static byte[] Appendint(this byte b, int intByte, bool isLittleEndian = true) => b.@bytes (ByteConverter.GetBytes (intByte, isLittleEndian));
        public static byte[] Appendint(this IEnumerable<byte> bs, int intByte, bool isLittleEndian = true) => bs.@bytes (ByteConverter.GetBytes (intByte, isLittleEndian));
        public static byte[] Appendint(this IEnumerable<byte> bs, int intByte, int offset, int count, bool isLittleEndian = true)
        {
            byte[] bytes = ByteConverter.GetBytes (intByte, isLittleEndian);
            return bs.@bytes (bytes, offset, count);
        }
        public static byte[] Appendlong(this byte b, long longByte, bool isLittleEndian = true) => b.@bytes (ByteConverter.GetBytes (longByte, isLittleEndian));
        public static byte[] Appendlong(this IEnumerable<byte> bs, long longByte, bool isLittleEndian = true) => bs.@bytes (ByteConverter.GetBytes (longByte, isLittleEndian));
        public static byte[] Appendlong(this IEnumerable<byte> bs, long longByte, int offset, int count, bool isLittleEndian = true)
        {
            byte[] bytes = ByteConverter.GetBytes (longByte, isLittleEndian);
            return bs.@bytes (bytes, offset, count);
        }

        public static byte[] Appendushort(this byte b, ushort ushortByte, bool isLittleEndian = true) => b.@bytes (ByteConverter.GetBytes (ushortByte, isLittleEndian));
        public static byte[] Appendushort(this IEnumerable<byte> bs, ushort ushortByte, bool isLittleEndian = true) => bs.@bytes (ByteConverter.GetBytes (ushortByte, isLittleEndian));
        public static byte[] Appendushort(this IEnumerable<byte> bs, ushort ushortByte, int offset, int count, bool isLittleEndian = true)
        {
            byte[] bytes = ByteConverter.GetBytes (ushortByte, isLittleEndian);
            return bs.@bytes (bytes, offset, count);
        }
        public static byte[] Appenduint(this byte b, uint uintByte, bool isLittleEndian = true) => b.@bytes (ByteConverter.GetBytes (uintByte, isLittleEndian));
        public static byte[] Appenduint(this IEnumerable<byte> bs, uint uintByte, bool isLittleEndian = true) => bs.@bytes (ByteConverter.GetBytes (uintByte, isLittleEndian));
        public static byte[] Appenduint(this IEnumerable<byte> bs, uint uintByte, int offset, int count, bool isLittleEndian = true)
        {
            byte[] bytes = ByteConverter.GetBytes (uintByte, isLittleEndian);
            return bs.@bytes (bytes, offset, count);
        }
        public static byte[] Appendulong(this byte b, ulong ulongByte, bool isLittleEndian = true) => b.@bytes (ByteConverter.GetBytes (ulongByte, isLittleEndian));
        public static byte[] Appendulong(this IEnumerable<byte> bs, ulong ulongByte, bool isLittleEndian = true) => bs.@bytes (ByteConverter.GetBytes (ulongByte, isLittleEndian));
        public static byte[] Appendulong(this IEnumerable<byte> bs, ulong ulongByte, int offset, int count, bool isLittleEndian = true)
        {
            byte[] bytes = ByteConverter.GetBytes (ulongByte, isLittleEndian);
            return bs.@bytes (bytes, offset, count);
        }
    }
}
