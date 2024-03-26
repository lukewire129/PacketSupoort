﻿using BytePacketSupport.Converter;
using BytePacketSupport.Enums;

namespace BytePacketSupport
{
    public static partial class AppendHelper
    {
        public static byte[] Append(this byte b, int intByte, bool isLittleEndian = true) => b.Append (ByteConverter.GetBytes (intByte, isLittleEndian));
        public static byte[] Append(this byte[] bs, int intByte, bool isLittleEndian = true) => bs.Append (ByteConverter.GetBytes (intByte, isLittleEndian));
        public static byte[] Append(this byte[] bs, int intByte, int offset, int count, bool isLittleEndian = true)
        {
            byte[] bytes = ByteConverter.GetBytes (intByte, isLittleEndian);
            return bs.Append (bytes, offset, count);
        }
    }
} 
