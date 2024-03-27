using BytePacketSupport.Converter;
using BytePacketSupport.Enums;
using System.Collections.Generic;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] Appendshort(this byte b, short shortByte, Endian endian = Endian.LITTLE) => b.@bytes (ByteConverter.GetBytes (shortByte, endian));
        public static byte[] Appendshort(this IEnumerable<byte> bs, short shortByte, Endian endian = Endian.LITTLE) => bs.@bytes (ByteConverter.GetBytes (shortByte, endian));
        public static byte[] Appendshort(this IEnumerable<byte> bs, short shortByte, int offset, int count, Endian endian = Endian.LITTLE)
        {
            byte[] bytes = ByteConverter.GetBytes (shortByte, endian);
            return bs.@bytes (bytes, offset, count);
        }
        public static byte[] Appendint(this byte b, int intByte, Endian endian = Endian.LITTLE) => b.@bytes (ByteConverter.GetBytes (intByte, endian));
        public static byte[] Appendint(this IEnumerable<byte> bs, int intByte, Endian endian = Endian.LITTLE) => bs.@bytes (ByteConverter.GetBytes (intByte, endian));
        public static byte[] Appendint(this IEnumerable<byte> bs, int intByte, int offset, int count, Endian endian = Endian.LITTLE)
        {
            byte[] bytes = ByteConverter.GetBytes (intByte, endian);
            return bs.@bytes (bytes, offset, count);
        }
        public static byte[] Appendlong(this byte b, long longByte, Endian endian = Endian.LITTLE) => b.@bytes (ByteConverter.GetBytes (longByte, endian));
        public static byte[] Appendlong(this IEnumerable<byte> bs, long longByte, Endian endian = Endian.LITTLE) => bs.@bytes (ByteConverter.GetBytes (longByte, endian));
        public static byte[] Appendlong(this IEnumerable<byte> bs, long longByte, int offset, int count, Endian endian = Endian.LITTLE)
        {
            byte[] bytes = ByteConverter.GetBytes (longByte, endian);
            return bs.@bytes (bytes, offset, count);
        }

        public static byte[] Appendushort(this byte b, ushort ushortByte, Endian endian = Endian.LITTLE) => b.@bytes (ByteConverter.GetBytes (ushortByte, endian));
        public static byte[] Appendushort(this IEnumerable<byte> bs, ushort ushortByte, Endian endian = Endian.LITTLE) => bs.@bytes (ByteConverter.GetBytes (ushortByte, endian));
        public static byte[] Appendushort(this IEnumerable<byte> bs, ushort ushortByte, int offset, int count, Endian endian = Endian.LITTLE)
        {
            byte[] bytes = ByteConverter.GetBytes (ushortByte, endian);
            return bs.@bytes (bytes, offset, count);
        }
        public static byte[] Appenduint(this byte b, uint uintByte, Endian endian = Endian.LITTLE) => b.@bytes (ByteConverter.GetBytes (uintByte, endian));
        public static byte[] Appenduint(this IEnumerable<byte> bs, uint uintByte, Endian endian = Endian.LITTLE) => bs.@bytes (ByteConverter.GetBytes (uintByte, endian));
        public static byte[] Appenduint(this IEnumerable<byte> bs, uint uintByte, int offset, int count, Endian endian = Endian.LITTLE)
        {
            byte[] bytes = ByteConverter.GetBytes (uintByte, endian);
            return bs.@bytes (bytes, offset, count);
        }
        public static byte[] Appendulong(this byte b, ulong ulongByte, Endian endian = Endian.LITTLE) => b.@bytes (ByteConverter.GetBytes (ulongByte, endian));
        public static byte[] Appendulong(this IEnumerable<byte> bs, ulong ulongByte, Endian endian = Endian.LITTLE) => bs.@bytes (ByteConverter.GetBytes (ulongByte, endian));
        public static byte[] Appendulong(this IEnumerable<byte> bs, ulong ulongByte, int offset, int count, Endian endian = Endian.LITTLE)
        {
            byte[] bytes = ByteConverter.GetBytes (ulongByte, endian);
            return bs.@bytes (bytes, offset, count);
        }
    }
}
