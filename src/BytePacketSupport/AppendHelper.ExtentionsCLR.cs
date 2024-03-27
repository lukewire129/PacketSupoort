﻿using BytePacketSupport.Converter;
using BytePacketSupport.Enums;
using System.Collections.Generic;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] AppendString(this byte b, string asciiByte) => b.@bytes (ByteConverter.GetBytes (asciiByte));
        public static byte[] AppendString(this IEnumerable<byte> bs, string asciiByte) => bs.@bytes (ByteConverter.GetBytes (asciiByte));
        public static byte[] AppendString(this IEnumerable<byte> bs, string asciiByte, int offset, int count) => bs.@bytes (ByteConverter.GetBytes (asciiByte), offset, count);
        public static byte[] AppendInt16(this byte b, short shortByte, Endian endian = Endian.LITTLE) => b.@bytes (ByteConverter.GetBytes (shortByte, endian));
        public static byte[] AppendInt16(this IEnumerable<byte> bs, short shortByte, Endian endian = Endian.LITTLE) => bs.@bytes (ByteConverter.GetBytes (shortByte, endian));
        public static byte[] AppendInt16(this IEnumerable<byte> bs, short shortByte, int offset, int count, Endian endian = Endian.LITTLE)
        {
            byte[] bytes = ByteConverter.GetBytes (shortByte, endian);
            return bs.@bytes (bytes, offset, count);
        }
        public static byte[] AppendInt32(this byte b, int intByte, Endian endian = Endian.LITTLE) => b.@bytes (ByteConverter.GetBytes (intByte, endian));
        public static byte[] AppendInt32(this IEnumerable<byte> bs, int intByte, Endian endian = Endian.LITTLE) => bs.@bytes (ByteConverter.GetBytes (intByte, endian));
        public static byte[] AppendInt32(this IEnumerable<byte> bs, int intByte, int offset, int count, Endian endian = Endian.LITTLE)
        {
            byte[] bytes = ByteConverter.GetBytes (intByte, endian);
            return bs.@bytes (bytes, offset, count);
        }
        public static byte[] AppendInt64(this byte b, long longByte, Endian endian = Endian.LITTLE) => b.@bytes (ByteConverter.GetBytes (longByte, endian));
        public static byte[] AppendInt64(this IEnumerable<byte> bs, long longByte, Endian endian = Endian.LITTLE) => bs.@bytes (ByteConverter.GetBytes (longByte, endian));
        public static byte[] AppendInt64(this IEnumerable<byte> bs, long longByte, int offset, int count, Endian endian = Endian.LITTLE)
        {
            byte[] bytes = ByteConverter.GetBytes (longByte, endian);
            return bs.@bytes (bytes, offset, count);
        }

        public static byte[] AppendUInt16(this byte b, ushort ushortByte, Endian endian = Endian.LITTLE) => b.@bytes (ByteConverter.GetBytes (ushortByte, endian));
        public static byte[] AppendUInt16(this IEnumerable<byte> bs, ushort ushortByte, Endian endian = Endian.LITTLE) => bs.@bytes (ByteConverter.GetBytes (ushortByte, endian));
        public static byte[] AppendUInt16(this IEnumerable<byte> bs, ushort ushortByte, int offset, int count, Endian endian = Endian.LITTLE)
        {
            byte[] bytes = ByteConverter.GetBytes (ushortByte, endian);
            return bs.@bytes (bytes, offset, count);
        }
        public static byte[] AppendUInt32(this byte b, uint uintByte, Endian endian = Endian.LITTLE) => b.@bytes (ByteConverter.GetBytes (uintByte, endian));
        public static byte[] AppendUInt32(this IEnumerable<byte> bs, uint uintByte, Endian endian = Endian.LITTLE) => bs.@bytes (ByteConverter.GetBytes (uintByte, endian));
        public static byte[] AppendUInt32(this IEnumerable<byte> bs, uint uintByte, int offset, int count, Endian endian = Endian.LITTLE)
        {
            byte[] bytes = ByteConverter.GetBytes (uintByte, endian);
            return bs.@bytes (bytes, offset, count);
        }
        public static byte[] AppendUInt64(this byte b, ulong ulongByte, Endian endian = Endian.LITTLE) => b.@bytes (ByteConverter.GetBytes (ulongByte, endian));
        public static byte[] AppendUInt64(this IEnumerable<byte> bs, ulong ulongByte, Endian endian = Endian.LITTLE) => bs.@bytes (ByteConverter.GetBytes (ulongByte, endian));
        public static byte[] AppendUInt64(this IEnumerable<byte> bs, ulong ulongByte, int offset, int count, Endian endian = Endian.LITTLE)
        {
            byte[] bytes = ByteConverter.GetBytes (ulongByte, endian);
            return bs.@bytes (bytes, offset, count);
        }
        public static byte[] AppendClass<TSource>(this byte b, TSource AppenClass) where TSource : class
        {
            byte[] result = new byte[] { b };
            return result.@bytes (PacketParse.Serialize (AppenClass));
        }

        public static byte[] AppendClass<TSource>(this IEnumerable<byte> b, TSource AppenClass) where TSource : class
        {
            var result = b;
            return result.@bytes (PacketParse.Serialize (AppenClass));
        }

        public static byte[] AppendPacketBuilder(this byte b, PacketBuilder packetBuilder)
        {
            return b.@bytes (packetBuilder.Build ());
        }

        public static byte[] AppendPacketBuilder(this IEnumerable<byte> bs, PacketBuilder packetBuilder)
        {
            return bs.@bytes (packetBuilder.Build ());
        }
    }
}
