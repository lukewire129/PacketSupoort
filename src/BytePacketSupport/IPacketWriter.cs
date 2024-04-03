using BytePacketSupport.Extentions;
using System;
using System.Buffers.Binary;

namespace BytePacketSupport
{
    public interface IPacketWriter
    {
        void @short(ReservedSpan span, short value);
        void @int(ReservedSpan span, int value);
        void @long(ReservedSpan span, long value);
        void @ushort(ReservedSpan span, ushort value);
        void @uint(ReservedSpan span, uint value);
        void @ulong(ReservedSpan span, ulong value);
    }

    public class PacketWriter : IPacketWriter
    {
        public void @short(ReservedSpan span, short value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteInt16LittleEndian (span, value);
            }
            else
            {
                BinaryPrimitives.WriteInt16BigEndian (span, value);
            }
        }

        public void @int(ReservedSpan span, int value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteInt32LittleEndian (span, value);
            }
            else
            {
                BinaryPrimitives.WriteInt32BigEndian (span, value);
            }
        }

        public void @long(ReservedSpan span, long value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteInt64LittleEndian (span, value);
            }
            else
            {
                BinaryPrimitives.WriteInt64BigEndian (span, value);
            }
        }

        public void @ushort(ReservedSpan span, ushort value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteUInt16LittleEndian (span, value);
            }
            else
            {
                BinaryPrimitives.WriteUInt16BigEndian (span, value);
            }
        }

        public void @uint(ReservedSpan span, uint value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteUInt32LittleEndian (span, value);
            }
            else
            {
                BinaryPrimitives.WriteUInt32BigEndian (span, value);
            }
        }

        public void @ulong(ReservedSpan span, ulong value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteUInt64LittleEndian (span, value);
            }
            else
            {
                BinaryPrimitives.WriteUInt64BigEndian (span, value);
            }
        }
    }

    public class ReversePacketWriter : IPacketWriter
    {
        public void @short(ReservedSpan span, short value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteInt16LittleEndian (span, BinaryPrimitives.ReverseEndianness (value));
            }
            else
            {
                BinaryPrimitives.WriteInt16BigEndian (span, BinaryPrimitives.ReverseEndianness (value));
            }
        }

        public void @int(ReservedSpan span, int value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteInt32LittleEndian (span, BinaryPrimitives.ReverseEndianness (value));
            }
            else
            {
                BinaryPrimitives.WriteInt32BigEndian (span, BinaryPrimitives.ReverseEndianness (value));
            }
        }

        public void @long(ReservedSpan span, long value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteInt64LittleEndian (span, BinaryPrimitives.ReverseEndianness (value));
            }
            else
            {
                BinaryPrimitives.WriteInt64BigEndian (span, BinaryPrimitives.ReverseEndianness (value));
            }
        }

        public void @ushort(ReservedSpan span, ushort value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteUInt16LittleEndian (span, BinaryPrimitives.ReverseEndianness (value));
            }
            else
            {
                BinaryPrimitives.WriteUInt16BigEndian (span, BinaryPrimitives.ReverseEndianness (value));
            }
        }

        public void @uint(ReservedSpan span, uint value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteUInt32LittleEndian (span, BinaryPrimitives.ReverseEndianness (value));
            }
            else
            {
                BinaryPrimitives.WriteUInt32BigEndian (span, BinaryPrimitives.ReverseEndianness (value));
            }
        }

        public void @ulong(ReservedSpan span, ulong value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteUInt64LittleEndian (span, BinaryPrimitives.ReverseEndianness (value));
            }
            else
            {
                BinaryPrimitives.WriteUInt64BigEndian (span, BinaryPrimitives.ReverseEndianness (value));
            }
        }
    }
    public class SwapPacketWriter : IPacketWriter
    {
        public void @short(ReservedSpan span, short value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteInt16LittleEndian (span, Swap (value));
            }
            else
            {
                BinaryPrimitives.WriteInt16BigEndian (span, Swap (value));
            }
        }

        public void @int(ReservedSpan span, int value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteInt32LittleEndian (span, Swap (value));
            }
            else
            {
                BinaryPrimitives.WriteInt32BigEndian (span, Swap (value));
            }
        }

        public void @long(ReservedSpan span, long value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteInt64LittleEndian (span, Swap (value));
            }
            else
            {
                BinaryPrimitives.WriteInt64BigEndian (span, Swap (value));
            }
        }

        public void @ushort(ReservedSpan span, ushort value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteUInt16LittleEndian (span, Swap (value));
            }
            else
            {
                BinaryPrimitives.WriteUInt16BigEndian (span, Swap (value));
            }
        }

        public void @uint(ReservedSpan span, uint value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteUInt32LittleEndian (span, Swap (value));
            }
            else
            {
                BinaryPrimitives.WriteUInt32BigEndian (span, Swap (value));
            }
        }

        public void @ulong(ReservedSpan span, ulong value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteUInt64LittleEndian (span, Swap (value));
            }
            else
            {
                BinaryPrimitives.WriteUInt64BigEndian (span, Swap (value));
            }
        }

        public static short Swap(short value)
        {
            return BinaryPrimitives.ReverseEndianness (value);
        }
        public static ushort Swap(ushort value)
        {
            return BinaryPrimitives.ReverseEndianness (value);
        }

        public static int Swap(int value)
        {
            return unchecked(((value & (int)0xFF00FF00) >> 8) + ((value & 0x00FF00FF) << 8));
        }
        public static uint Swap(uint value)
        {
            return unchecked(((value & (uint)0xFF00FF00) >> 8) + ((value & 0x00FF00FF) << 8));
        }
        public static long Swap(long value)
        {
            return unchecked(((value & (long)0xFF00FF00FF00FF00) >> 8) + ((value & 0x00FF00FF00FF00FF) << 8));
        }

        public static ulong Swap(ulong value)
        {
            return unchecked(((value & (ulong)0xFF00FF00FF00FF00) >> 8) + ((value & 0x00FF00FF00FF00FF) << 8));
        }
    }

    public class ReverseSwapPacketWriter : IPacketWriter
    {
        public void @short(ReservedSpan span, short value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteInt16LittleEndian (span, ReverseSwap (value));
            }
            else
            {
                BinaryPrimitives.WriteInt16BigEndian (span, ReverseSwap (value));
            }
        }

        public void @int(ReservedSpan span, int value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteInt32LittleEndian (span, ReverseSwap (value));
            }
            else
            {
                BinaryPrimitives.WriteInt32BigEndian (span, ReverseSwap (value));
            }
        }

        public void @long(ReservedSpan span, long value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteInt64LittleEndian (span, ReverseSwap (value));
            }
            else
            {
                BinaryPrimitives.WriteInt64BigEndian (span, ReverseSwap (value));
            }
        }

        public static short ReverseSwap(short value)
        {
            return value;
        }

        public static int ReverseSwap(int value)
        {
            return (int)RotateLeft ((uint)value, 16);
        }

        public static long ReverseSwap(long value)
        {
            return ((long)RotateLeft ((uint)value, 16) << 32) + RotateLeft ((uint)(value >> 32), 16);
        }

        public static ushort ReverseSwap(ushort value)
        {
            return value;
        }

        public static uint ReverseSwap(uint value)
        {
            return (uint)RotateLeft ((uint)value, 16);
        }

        public static ulong ReverseSwap(ulong value)
        {
            return ((ulong)RotateLeft ((uint)value, 16) << 32) + RotateLeft ((uint)(value >> 32), 16);
        }

        public static uint RotateLeft(uint value, int offset)
          => (value << offset) | (value >> (32 - offset));

        public void @ushort(ReservedSpan span, ushort value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteUInt16LittleEndian (span, ReverseSwap (value));
            }
            else
            {
                BinaryPrimitives.WriteUInt16BigEndian (span, ReverseSwap (value));
            }
        }

        public void @uint(ReservedSpan span, uint value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteUInt32LittleEndian (span, ReverseSwap (value));
            }
            else
            {
                BinaryPrimitives.WriteUInt32BigEndian (span, ReverseSwap (value));
            }
        }

        public void @ulong(ReservedSpan span, ulong value)
        {
            if (BitConverter.IsLittleEndian == true)
            {
                BinaryPrimitives.WriteUInt64LittleEndian (span, ReverseSwap (value));
            }
            else
            {
                BinaryPrimitives.WriteUInt64BigEndian (span, ReverseSwap (value));
            }
        }
    }
}
