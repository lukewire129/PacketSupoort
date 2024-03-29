using BytePacketSupport.Extentions;
using System;
using System.Buffers.Binary;
using System.Runtime.InteropServices;

namespace BytePacketSupport
{
    public interface IPacketWriter
    {
        public static IPacketWriter LittleEndian =>
        BitConverter.IsLittleEndian ? (IPacketWriter)PacketWriter.Instance : ReversePacketWriter.Instance;

        public static IPacketWriter BigEndian =>
            BitConverter.IsLittleEndian ? (IPacketWriter)ReversePacketWriter.Instance : PacketWriter.Instance;

        public static IPacketWriter LittleEndianSwap =>
            BitConverter.IsLittleEndian ? (IPacketWriter)SwapPacketWriter.Instance : ReverseSwapPacketWriter.Instance;

        public static IPacketWriter BigEndianSwap =>
            BitConverter.IsLittleEndian ? (IPacketWriter)ReverseSwapPacketWriter.Instance : SwapPacketWriter.Instance;
        void @short(ReservedSpan span, short value);
        void @int(ReservedSpan span, int value);
        void @long(ReservedSpan span, long value);
        void @ushort(ReservedSpan span, ushort value);
        void @uint(ReservedSpan span, uint value);
        void @ulong(ReservedSpan span, ulong value);
    }

    public class PacketWriter : IPacketWriter
    {
        public static PacketWriter Instance { get; } = new PacketWriter ();

        public void @short(ReservedSpan span, short value)
        {
            MemoryMarshal.Write (span, ref value);
        }

        public void @int(ReservedSpan span, int value)
        {
            MemoryMarshal.Write (span, ref value);
        }

        public void @long(ReservedSpan span, long value)
        {
            MemoryMarshal.Write (span, ref value);
        }

        public void @ushort(ReservedSpan span, ushort value)
        {
            MemoryMarshal.Write (span, ref value);
        }

        public void @uint(ReservedSpan span, uint value)
        {
            MemoryMarshal.Write (span, ref value);
        }

        public void @ulong(ReservedSpan span, ulong value)
        {
            MemoryMarshal.Write (span, ref value);
        }
    }

    public class ReversePacketWriter : IPacketWriter
    {
        public static ReversePacketWriter Instance { get; } = new ReversePacketWriter ();
        public void @short(ReservedSpan span, short value)
        {
            value = BinaryPrimitives.ReverseEndianness (value);
            MemoryMarshal.Write (span, ref value);
        }

        public void @int(ReservedSpan span, int value)
        {
            value = BinaryPrimitives.ReverseEndianness (value);
            MemoryMarshal.Write (span, ref value);
        }

        public void @long(ReservedSpan span, long value)
        {
            value = BinaryPrimitives.ReverseEndianness (value);
            MemoryMarshal.Write (span, ref value);
        }

        public void @ushort(ReservedSpan span, ushort value)
        {
            value = BinaryPrimitives.ReverseEndianness (value);
            MemoryMarshal.Write (span, ref value);
        }

        public void @uint(ReservedSpan span, uint value)
        {
            value = BinaryPrimitives.ReverseEndianness (value);
            MemoryMarshal.Write (span, ref value);
        }

        public void @ulong(ReservedSpan span, ulong value)
        {
            value = BinaryPrimitives.ReverseEndianness (value);
            MemoryMarshal.Write (span, ref value);
        }
    }
    public class SwapPacketWriter : IPacketWriter
    {
        public static SwapPacketWriter Instance { get; } = new SwapPacketWriter ();

        public void @short(ReservedSpan span, short value)
        {
            value = Swap (value);
            MemoryMarshal.Write (span, ref value);
        }

        public void @int(ReservedSpan span, int value)
        {
            value = Swap (value);
            MemoryMarshal.Write (span, ref value);
        }

        public void @long(ReservedSpan span, long value)
        {
            value = Swap (value);
            MemoryMarshal.Write (span, ref value);
        }

        public void @ushort(ReservedSpan span, ushort value)
        {
            value = Swap (value);
            MemoryMarshal.Write (span, ref value);
        }

        public void @uint(ReservedSpan span, uint value)
        {
            value = Swap (value);
            MemoryMarshal.Write (span, ref value);
        }

        public void @ulong(ReservedSpan span, ulong value)
        {
            value = Swap (value);
            MemoryMarshal.Write (span, ref value);
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
        public static ReverseSwapPacketWriter Instance { get; } = new ReverseSwapPacketWriter ();

        public void @short(ReservedSpan span, short value)
        {
            value = ReverseSwap (value);
            MemoryMarshal.Write (span, ref value);
        }

        public void @int(ReservedSpan span, int value)
        {
            value = ReverseSwap (value);
            MemoryMarshal.Write (span, ref value);
        }

        public void @long(ReservedSpan span, long value)
        {
            value = ReverseSwap (value);
            MemoryMarshal.Write (span, ref value);
        }
        public void @ushort(ReservedSpan span, ushort value)
        {
            value = ReverseSwap (value);
            MemoryMarshal.Write (span, ref value);
        }

        public void @uint(ReservedSpan span, uint value)
        {
            value = ReverseSwap (value);
            MemoryMarshal.Write (span, ref value);
        }

        public void @ulong(ReservedSpan span, ulong value)
        {
            value = ReverseSwap (value);
            MemoryMarshal.Write (span, ref value);
        }

        public static short ReverseSwap(short value)
        {
            return value;
        }

        public static ushort ReverseSwap(ushort value)
        {
            return value;
        }

        public static int ReverseSwap(int value)
        {
            return (value << 16) | (value >> 16);
        }

        public static uint ReverseSwap(uint value)
        {
            return (value << 16) | (value >> 16);
        }

        public static long ReverseSwap(long value)
        {
            return BinaryPrimitives.ReverseEndianness (unchecked(((value & (long)0xFF00FF00FF00FF00) >> 8) + ((value & 0x00FF00FF00FF00FF) << 8)));
        }

        public static ulong ReverseSwap(ulong value)
        {
            return BinaryPrimitives.ReverseEndianness (unchecked(((value & 0xFF00FF00FF00FF00) >> 8) + ((value & 0x00FF00FF00FF00FF) << 8)));
        }
    }
}
